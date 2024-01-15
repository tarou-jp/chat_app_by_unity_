# coeiroinkを用いて音声を作成するソースコード(アプリ実装時にはunity側で記述したため未使用)

import requests
import json

url = 'http://localhost:50031/'
query_p = 'audio_query'
req_url = url + query_p
# enable_interrogative_upspeak = ''

v_name = "voice.wav"
v_dir = "voices/"
voice_pass = v_dir + v_name

# APIに送信する情報
def Params(message):
   speaker_id = 4
    #speaker_idには（重要）しゃべらせたいボイスのstyleIdを書いてください（上記はつくよみちゃんれいせいです）　
   my_text = message
#    headers = {'speaker':1}
   q_params = {'text' :my_text,'speaker': speaker_id,'core_version':'0.0.0'}
#    'speaker': speaker_id,
#    {"text":"今日もお疲れ","speaker":0,"core_version":"0.0.0"}
   a_params = {'speaker' :speaker_id,'core_version':'0.0.0','enable_interrogative_upspeak' : 'true'}
   return q_params , a_params
   
# 使わん
# #print(json.dumps(json_data))
# #GETリクエストを送る
# def Get_Request():
#    response = requests.get(
#    'http://localhost:50031/core_versions',
#    )
#    res_data = response.json()
# #    print(res_data)
# #    print(response.status_code)
   

#POSTリクエストを送る（クエリを作成）
def Post_RequestMQ(q_params):
#    pa = {"params",q_params}
   response = requests.post(req_url, params = q_params)
#    print(response)
   res_data = response.json()
#    print(response.status_code)
   return res_data
 

#POSTリクエストを送る(音声合成し、返ってきた音声ファイルを保存)
def Post_RequestMA(a_params,my_query):
#    pa = {"params",}
   response = requests.post('http://localhost:50031/synthesis',params = a_params,data= json.dumps(my_query))
   with open(voice_pass, 'wb') as saved_voice:
       saved_voice.write(response.content)
#    print(response.)


# my_query = Post_RequestMQ()

def Create_Voice(message):
   q_params , a_params = Params(message)
   my_query = Post_RequestMQ(q_params)
   Post_RequestMA(a_params,my_query)

Create_Voice("今日も1日お疲れ様でした。")