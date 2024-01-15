using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cushion : MonoBehaviour
{
    public string user_chat = "None";
    public string anser_chat = "None";
    public string schedule_memo = "None";
    public string homework = "None"; 
    public string joy ;
    public string fun ;
    public string ang ;
    public string sad ;
    public bool joy_s = false;
    public bool fun_s = false;
    public bool ang_s = false;
    public bool sad_s = false;
    public bool tv = false;
    public bool air = false;
    public bool light_ = false;
    public EmoCushion[] emo_cushion;
    public string identifier;

    public static cushion instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Cushion_(string message)
    {
        identifier = message.Substring(0, 3);
        Debug.Log(identifier);
        if (identifier == "cli")
        {
            user_chat = message.Substring(3);
        }
        else if (identifier == "ans")
        {
            anser_chat = message.Substring(3);
        }
        else if (identifier == "joy")
        {
            //Debug.Log("kita");
            joy_s = true;
            //Debug.Log(message.Substring(-2, -1));
            joy = message;
        }
        else if (identifier == "fun")
        {
            fun_s = true;
            fun = message;
        }
        else if (identifier == "ang")
        {
            ang_s = true;
            ang = message;
        }
        else if (identifier == "sad")
        {
            sad_s = true;
            sad = message;
        }
        else if (identifier == "sch")
        {
            schedule_memo = message.Substring(3);
        }
        else if (identifier == "man")
        {
            homework = message.Substring(3);
        }
        else if (identifier == "TVC")
        {
            tv = true;
        }
        else if (identifier == "Air")
        {
            air = true;
        }
        else if (identifier == "Lig")
        {
            light_ = true;
        }
    }

    void Update()
    {
        if (user_chat != "None")
        {
            Message.instance.AdjustmentMessage(user_chat);
            user_chat = "None";
            LogBox.instance.ClearLog();
            LogBox.instance.PutLogText("user_chat_recption complete!");
        }

        if (anser_chat != "None")
        {
            if (anser_chat == "『undefined』")
            {
                Message.instance.AdjustmentMessage("音声が認識できませんでした！");
                PreparedVoice.instance.PlayPreparedAudioClip(0);
                anser_chat = "None";
                LogBox.instance.PutLogText("error anser_chat_recption");
            }
            else
            {
                Message.instance.AdjustmentMessage(anser_chat);
                Voice.instance.CreateVoice(anser_chat);
                anser_chat = "None";
                LogBox.instance.PutLogText("anser_chat_recption complete!");
            }

        }

        if (homework != "None")
        {
            Homeworkcushion.instance.PassHomework(homework);
            homework = "None";
        }

        if (schedule_memo != "None")
        {
            //メッセージ送信はscheduleextractでやる
            ScheduleCushion.instance.ScheduleExtract(schedule_memo);
            schedule_memo = "None";

        }

        if (joy_s)
        {
            joy_s = false;
            emo_cushion[0].passemo(joy);
        }
        if (fun_s)
        {
            fun_s = false;
            emo_cushion[3].passemo(fun);
        }
        if (ang_s)
        {
            ang_s = false;
            emo_cushion[1].passemo(ang);
        }
        if (sad_s)
        {
            sad_s = false;
            emo_cushion[2].passemo(sad + ",");
        }

        if (tv)
        {
            ChatBox.instance.PutChat("テレビを操作しました",true);
            PreparedVoice.instance.PlayPreparedAudioClip(3);
            tv = false;
        }
        if (air)
        {
            ChatBox.instance.PutChat("エアコンを操作しました", true);
            PreparedVoice.instance.PlayPreparedAudioClip(4);
            air = false;
        }
        if (light_)
        {
            ChatBox.instance.PutChat("電気を操作しました", true);
            PreparedVoice.instance.PlayPreparedAudioClip(5);
            light_ = false;
        }
    }
}
