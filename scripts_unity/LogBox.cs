using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBox : MonoBehaviour
{
    [SerializeField] LogText[] logtexts;

    public static LogBox instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PutLogText(string text)
    {
        foreach(LogText logtext in logtexts)
        {
            if (logtext.is_empty == true)
            {
                logtext.ShiftLogText(text);
                return;
            }
        }
        if (logtexts[5].is_empty == false)
        {
            for (int i = 0; i< 5; i++)
            {
                logtexts[i].ShiftLogText(logtexts[i + 1].text_);
            }
            logtexts[5].ShiftLogText(text);
            return;
        }
    }

    public void ClearLog()
    {
        foreach(LogText logtext in logtexts)
        {
            logtext.ClearLogText();
        }
    }
}
