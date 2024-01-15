using UnityEngine;
using WebSocketSharp;
using System.Collections;
//using UnityEngine.UI;

public class ClientExample : MonoBehaviour
{
	private WebSocket ws_;
	public static ClientExample instance;
	public void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		ConectServer();

		//ws_ = new WebSocket("ws://127.0.0.1:12002");
		//ws_.OnMessage += (sender, e) => {
		//	Debug.Log(e.Data); // 認識結果
		//	cushion.instance.Cushion_(e.Data);
		//};
		//ws_.Connect();
	}

	public void ConectServer()
    {
		ws_ = new WebSocket("ws://127.0.0.1:12002");
		ws_.OnMessage += (sender, e) => {
			Debug.Log(e.Data); // 認識結果
			cushion.instance.Cushion_(e.Data);
		};
		ws_.Connect();
	}

	//void Awake()
	//{
	//	ws_ = new WebSocket("ws://127.0.0.1:12002");
	//	ws_.OnMessage += (sender, e) => {
	//		Debug.Log(e.Data); // 認識結果
	//		cushion.instance.Cushion_(e.Data);
 //           //Message.instance.AdjustmentMessage(e.Data.ToString());
 //           //obj.GetComponent<Text>().text = e.Data;
 //       };
	//	ws_.Connect();

	//	//ws_.Send("start");
	//}

	//public void WSmanaba()
 //   {
	//	ws_.Send("manaba");
 //   }

	public void WSsend(string message)
    {
		ws_.Send(message);
    }

	void OnApplicationQuit()
	{
		ws_.Close();
	}
}