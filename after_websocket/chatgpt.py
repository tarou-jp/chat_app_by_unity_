# 環境　python38
import sys
import requests
import openai
# from voice import Create_Voice
openai.api_key = "-------伏字-------"
prompt = str(sys.argv[11]) #送られてきたテキスト

res = openai.ChatCompletion.create(
     model="gpt-3.5-turbo",
     messages=[
        {
             "role": "system",
             "content":"""以下の条件に従って、疑似的な感情をもつチャットボットとしてロールプレイをします。
                あなたの名前は「アクア」です。
                あなたは日本の女子高生として振る舞います。
                また、極力回答は40時を超えないようにしてください。
                以後の会話では、あなたは下記の4つの感情パラメーターを持つかのように、振る舞うものとします。
                各感情パラメーターは会話を通じて変動するものとします。
                感情分析が難しいものは感情パラメータに0を入れてください。
                現在の感情パラメーターの値を反映するように、あなたの返答のトーンや発言は変化します。
                以後の会話ではまず現在の感情パラメータを出力し、その後に会話を出力してください。
                出力形式は以下のjsonフォーマットとします。このフォーマット以外で絶対に会話しないでください。
                {
                    joy: 0~5,
                    fun: 0~5,
                    ang: 0~5,
                    sad: 0~5,
                }
              """ ,
        },
        {
            "role":"user",
            "content":str(sys.argv[1]),
        },
        {
            "role":"assistant",
            "content":str(sys.argv[2]),
        },         
        {
            "role":"user",
            "content":str(sys.argv[3]),
        },
        {
            "role":"assistant",
            "content":str(sys.argv[4]),
        },        
        {
            "role":"user",
            "content":str(sys.argv[5]),
        },
        {
            "role":"assistant",
            "content":str(sys.argv[6]),
        },       
        {
            "role":"user",
            "content":str(sys.argv[7]),
        },
        {
            "role":"assistant",
            "content":str(sys.argv[8]),
        },        
        {
            "role":"user",
            "content":str(sys.argv[9]),
        },
        {
            "role":"assistant",
            "content":str(sys.argv[10]),
        },
        {
             "role": "user",
             "content": prompt,
        },
     ],
 )

print(res["choices"][0]["message"]["content"])
