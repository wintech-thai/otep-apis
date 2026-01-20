#!/usr/bin/env ruby

require 'net/http'
require 'uri'
require 'json'
require './utils'

$stdout.sync = true

################### Main #######################
load_env("./.env")

orgId = ENV['API_ORG']
id = 
param = nil

### GetForgotPasswordLink
apiUrl = "api/OrganizationUser/org/#{orgId}/action/GetForgotPasswordLink/#{id}"
result = make_request(:post, apiUrl, param)
puts(result)
