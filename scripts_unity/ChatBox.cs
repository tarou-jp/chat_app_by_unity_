using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour
{

    [SerializeField] Chat[] chats;

    public static ChatBox instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PutChat(string message,bool time_exist)
    {
        //Debug.Log(message);
        //1~11行の空いてるところに挿入

        //chats[0].ChatTextShift(message);

        foreach (Chat chat in chats)
        {
            //Debug.Log("3");
            if (chat.is_empty == true)
            {
                chat.ChatTextShift(message,time_exist);
                return;
            }
        }
        //全ての行が埋まっていたら1行繰り上げて11行目挿入に
        if (chats[20].is_empty == false)
        {
            for (int i = 0; i <= 19; i++)
            {
                chats[i].ChatTextUpdate(chats[i+1].chat);
                //chats[i].ChatTextShift(chats[i].chat,chats[i].time_exist);
                //chats[i].
            }
            chats[20].ChatTextShift(message,time_exist);
        }
    }
}
