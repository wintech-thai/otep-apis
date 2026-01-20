#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env("./.env")

orgId = ENV['API_ORG']
keyFile = ".token"

userName = 'seubpong.mon'

apiUrl = "api/OnlyUser/org/#{orgId}/action/UpdateUserByUserName/#{userName}"

param =  {
  Name: 'NameTest1',
  LastName: 'LastNameTest1',
  PhoneNumber: '+660989776650',
  SecondaryEmail: 'xxxx1234@gmail.com'
}

token = File.read(keyFile)

ENV['API_KEY'] = nil # ถ้าไม่ใช้ API KEY ก็เซ็ตเป็น nil
ENV['ACCESS_TOKEN'] = token

result = make_request(:post, apiUrl, param)

json = result.to_json
puts(json)
