using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public int chat_id;
    public string chat;
    public bool is_empty = true;
    public bool time_exist = true;
    private Text text_;



    public void Start()
    {
        text_ = GetComponent<Text>();
    }

    public void ChatTextShift(string message,bool time_exist_)  
    {
        time_exist = time_exist_;
        is_empty = false;
        DateTime dt = DateTime.Now;
        if (time_exist)
        {
            chat = dt.ToString("HH:mm ") + message;
            text_.text = dt.ToString("HH:mm ") + message;
        }
        else
        {
            chat = dt.ToString("          ") + message;
            text_.text = dt.ToString("          ") + message;
        }
        //MM / dd HH mm ss
    }

    public void ChatTextUpdate(string str)
    {
        text_.text = str;
        chat = str;
    }

}
