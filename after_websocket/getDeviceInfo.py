# switch-botのデバイスIDを取得するソースコード

import requests
import json

url = "https://api.switch-bot.com/v1.0/devices"
headers = {"Authorization": "610dde5fdc00be8d64df41096222e319bb946579b55893bb974e2eb1ce5f9859ff526f1592d3baa00eb28c9e8f13e852"}
r = requests.get(url, headers=headers)
print("status=", r.status_code)

json_data = r.json()
s = json.dumps(json_data, indent=2) #jsonデータを整形
print(s)