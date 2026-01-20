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

url = "https://web-dev.otep.triple-t.co/forgot-password/default/916d7535-a6d4-4848-8a2c-7e6e7e49c5ee?data=eyJFbWFpbCI6InBqYW1lLmZiM0BnbWFpbC5jb20iLCJVc2VyTmFtZSI6InNldWJwb25nLm1vbjMiLCJQYXNzd29yZCI6bnVsbCwiTmFtZSI6bnVsbCwiTGFzdG5hbWUiOm51bGwsIkludml0ZWRCeSI6bnVsbCwiT3JnVXNlcklkIjoiOTUzMGJjYjQtMDM5YS00ZWZhLWEyZWItYzdiODE4ZWFmNTY3In0%3d"
uri = URI.parse(url)

# แปลง query string เป็น hash
params = CGI.parse(uri.query)
data = params['data'].first

path = uri.path
parts = path.split('/').reject(&:empty?)

decoded = Base64.decode64(data)
dataObj = JSON.parse(decoded)

regType = parts[0]
orgId = parts[1]
token = parts[2]

api = "ConfirmForgotPasswordReset"

#puts(dataObj)
userName = dataObj['UserName']

param =  {
  Email: dataObj['Email'],
  UserName: "#{userName}",
  Password: "#{ENV['USER_PASSWORD']}",
  OrgUserId: dataObj['OrgUserId'],
}

#puts(param)
#puts(parts)

ENV['API_KEY'] = nil # ถ้าไม่ใช้ API KEY ก็เซ็ตเป็น nil

apiUrl = "api/Registration/org/#{orgId}/action/#{api}/#{token}/#{userName}"
#puts(apiUrl)
puts("DEBUG Email=[#{dataObj['Email']}], Username=[#{userName}], OrgUserId=[#{dataObj['OrgUserId']}]")
result = make_request(:post, apiUrl, param)
puts(result)
