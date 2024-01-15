# switch-botを用いて家電操作を行うソースコード

import requests
import json
import sys

# prompt = str(sys.argv[1])
prompt = "Light_off"
auth_key = "610dde5fdc00be8d64df41096222e319bb946579b55893bb974e2eb1ce5f9859ff526f1592d3baa00eb28c9e8f13e852"

if prompt == "TV":
   device_id = "02-202303221704-11553908"
   on_off = "turnOff" 
elif prompt == "Air_on":
   device_id = "02-202303270945-10346308"
   on_off = "turnOn"
elif prompt == "Air_off":
   device_id = "02-202303270945-10346308"
   on_off = "turnOff"
elif prompt == "Light_on":
   device_id = "02-202303270948-11814560"
   on_off = "turnOn"
elif prompt == "Light_off":
   device_id = "02-202303270948-11814560"
   on_off = "turnOff"
    
url = "https://api.switch-bot.com/v1.0/devices/" +device_id+ "/commands"
headers = {
   "Authorization": auth_key,
   "Content-Type" : "application/json; charset=utf8"
}
params = {
   "command": on_off,
   "parameter": "default",
   "commandType": "command"
}

r = requests.post(url, headers=headers, data=json.dumps(params))
print(r.text)
json_data = r.json()
print(json.dumps(json_data, indent=2))