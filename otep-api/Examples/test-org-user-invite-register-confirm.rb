#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require 'cgi'
require 'base64'
require './utils'

$stdout.sync = true

################### Main #######################
load_env("./.env")

url = "https://register-dev.otep.triple-t.co/default/user-signup-confirm/e102b131-5fa6-4524-9907-6a5e723b6e24?data=eyJFbWFpbCI6InNvdGhvbkBnbWFpbC5jb20iLCJVc2VyTmFtZSI6InNvdGhvbiIsIlBhc3N3b3JkIjpudWxsLCJOYW1lIjpudWxsLCJMYXN0bmFtZSI6bnVsbCwiSW52aXRlZEJ5IjoiYXBpIiwiT3JnVXNlcklkIjoiZGFlZmIxNzAtOTc1Ny00OTNkLTk1M2YtNmFkNWFkZmNlYTM5In0%3d"
uri = URI.parse(url)

# แปลง query string เป็น hash
params = CGI.parse(uri.query)
data = params['data'].first

path = uri.path
parts = path.split('/').reject(&:empty?)

decoded = Base64.decode64(data)
dataObj = JSON.parse(decoded)

orgId = parts[0]
regType = parts[1]
token = parts[2]

api = "ConfirmNewUserInvitation"
if (regType != 'user-signup-confirm')
  api = "ConfirmExistingUserInvitation"
end

#puts(dataObj)
userName = dataObj['UserName']

param =  {
  Email: dataObj['Email'],
  UserName: "#{userName}",
  Password: "Abc12345$343#1",
  Name: "Sothon",
  LastName: "TripleT",
  OrgUserId: dataObj['OrgUserId'],
}

#puts(param)
#puts(parts)

ENV['API_KEY'] = nil # ถ้าไม่ใช้ API KEY ก็เซ็ตเป็น nil

apiUrl = "api/Registration/org/#{orgId}/action/#{api}/#{token}/#{userName}"
#puts(apiUrl)

result = make_request(:post, apiUrl, param)
puts(result)
