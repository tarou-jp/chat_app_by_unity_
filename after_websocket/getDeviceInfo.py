# switch-botのデバイスIDを取得するソースコード

import requests
import json

url = "https://api.switch-bot.com/v1.0/devices"
headers = {"Authorization": "-------伏字-------"}
r = requests.get(url, headers=headers)
print("status=", r.status_code)

json_data = r.json()
s = json.dumps(json_data, indent=2) #jsonデータを整形
print(s)
