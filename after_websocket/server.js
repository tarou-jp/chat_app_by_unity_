// cjs
const Buffer = require('buffer/').Buffer;
let {PythonShell} = require('python-shell')

var https = require('https'); 
var fs    = require('fs');
var ws    = require('ws').Server;
var mic_status = false;

var CHROME_PORT = 12001; 
var UNITY_PORT  = 12002; 
var chats = ["テスト","テスト","テスト","テスト","テスト","テスト","テスト","テスト","テスト","テスト"];


// WebSpeech API を Chrome で走らせるための HTTPS サーバ オレオレ証明書使用
var server = https.createServer({
	key: fs.readFileSync('keys/server.key'), // サーバ秘密鍵
	cert: fs.readFileSync('keys/server.crt') // サーバ証明書(CA証明書含む)
}, function(req, res) {
	fs.readFile('index.html', function(err, data) {
		if (err) {
			res.writeHead(500);
			res.end('Internal Server Error');
		} else {
			res.writeHead(200);
			res.end(data.toString().replace('{CHROME_PORT}', CHROME_PORT));
		};
	});
}).listen(CHROME_PORT);

// Unity と WebSocket によるコネクションをはる
var unityWebSockets = [];
var unityServer = new ws({port: UNITY_PORT});
unityServer.on('connection', function(ws) {
	console.log('Unity connected!');
	// chromeVoiceSet();
	unityWebSockets.push(ws);
	ws.on("message", function(word){
		console.log(word.toString() + "by Unity");
		if (word.toString() == "manaba"){
			PythonShell.run('manaba.py',null).then(messages=>{
				unityWebSockets.forEach(function(unityWebSocket){
					messages.forEach(function(message){
						unityWebSocket.send("man" + message);
						console.log(message);
					});
				});
			});
		} else if (word.toString() == "WSA"){
			mic_status = true;
			console.log(mic_status);
			// chromeVoiceSet()
			console.log("mic set");
		} else if (word.toString() == "WSA_Stop"){
			mic_status = false;
		}else{
			chatgpt(word);
		};
	});
	ws.on('close', function() {
		console.log('Unity disconnected...');
		unityWebSockets.splice(unityWebSockets.indexOf(ws), 1);
	});
});

// Web Speech API の結果を取ってくる
var chromeVoiceRecogServer = new ws({server: server});
chromeVoiceRecogServer.on('connection', function(ws) {
	console.log('Chrome connected!');
		// pythonファイルを実行してUnityに送信
		ws.on('message', function(word) {
			iden = word.toString().indexOf("アクア")
			console.log(iden);
			if (iden == -1){
				if (mic_status){
					console.log('recognized:', word.toString());
					chatgpt(word)
					mic_status = false;
				}
			} else {
				console.log("akua");
				chatgpt(word);
			};
		}).on('close', function() {
			console.log('Chrome disconnected...');
		});
});

function chatgpt(word){
	PythonShell.run("concept_extraptor.py",{args:word}).then(messages=>{
		console.log(messages);
		if (messages[0] == "TV_on"){
			var Mode_ID = 2;
		}else if (messages[0] == "TV_off"){
			var Mode_ID = 3;
		}else if (messages[0] == "Air_on"){
			var Mode_ID = 4;
		}else if (messages[0] == "Air_off"){
			var Mode_ID = 5;
		}else if (messages[0] == "Light_on"){
			var Mode_ID = 6;
			console.log("kawa")
		}else if (messages[0] == "Light_off"){
			var Mode_ID = 7;
		}else{
			var Mode_ID = 0;
		};
		console.log("Mode_ID" + ":" + Mode_ID);
		if (Mode_ID == 0){
			console.log("通常");
			add_chats(word.toString())
			PythonShell.run('chatgpt.py',{args:chats}).then(messages=>{
				console.log(messages);
				console.log("1" + messages[1]);
				console.log("2" + messages[2]);
				console.log("3" + messages[3]);
				console.log("4" + messages[4]);
				console.log("6" + messages[6]);
				var id = 6;
				for (let i = 0 ; i <= 5 ; i ++){
					if (typeof messages[i] != "undefined"){
						var message = messages[i].replace(" ","");
						if (message.indexOf(":") == -1 && message.indexOf("{") == -1 && message.indexOf("}") == -1){
							id = i;
						};
					};
				};
				add_chats(messages[id])
				unityWebSockets.forEach(function(unityWebSocket) {
					unityWebSocket.send("cli" + "「"+ word.toString() + "」");
					unityWebSocket.send("ans" + "『" + messages[id] + "』");
					unityWebSocket.send("joy" + messages[1]);
					unityWebSocket.send("fun" + messages[2]);
					unityWebSocket.send("ang" + messages[3]);
					unityWebSocket.send("sad" + messages[4]);
				});
			});
		} else if (Mode_ID == 1){
	
			console.log("スケジュール");
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("sch" + word.toString())
			});
		} else if (Mode_ID == 2){
			PythonShell.run('SwitchBot.py',{args:"TV"});
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("TVC");
			});
		} else if (Mode_ID == 3){
			PythonShell.run('SwitchBot.py',{args:"TV"})
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("TVC")
			});
		} else if (Mode_ID == 4){
			PythonShell.run('SwitchBot.py',{args:"Air_on"})
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("Air")
			});
		} else if (Mode_ID == 5){
			PythonShell.run('SwitchBot.py',{args:"Air_off"})
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("Air")
			});
		} else if (Mode_ID == 6){
			PythonShell.run('SwitchBot.py',{args:"Light_on"})
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("Lig")
			});
		} else if (Mode_ID == 7){
			PythonShell.run('SwitchBot.py',{args:"Light_off"})
			unityWebSockets.forEach(function(unityWebSocket) {
				unityWebSocket.send("Lig")
			});
		};
	})
};

function add_chats(chat){
	console.log(chats.length)
	if (chats.length != 11){
		chats.push(chat)
	}else{
		chats.splice(0,1)
		chats.push(chat)
	};
}

function web_speach_api(){
	PythonShell.run("web_speach.py",null).then(messages=>{
		chatgpt(messages);
	});
}
