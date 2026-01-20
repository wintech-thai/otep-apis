#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env("./.env")

orgId = ENV['API_ORG']
id = "0163790e-618a-4be7-810a-ae96d454e20c" #"e6c21fac-4490-4632-9667-0eaca208c0e3"
param = nil

### GetForgotPasswordLink
apiUrl = "api/OrganizationUser/org/#{orgId}/action/GetForgotPasswordLink/#{id}"
result = make_request(:get, apiUrl, param)
puts(result)
