using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{
    //[SerializeField] string[] messages;

    public static Message instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SubmitChat(string message , bool time_exist)
    {
        ChatBox.instance.PutChat(message,time_exist);
    }

    public void AdjustmentMessage(string message)
    {
        int string_len = message.Length;
        int number_of_line = (string_len / 21); //行数
        string str;
        if (number_of_line > 0)
        {
            for (int i = 0; i <= number_of_line - 1; i++)
            {
                //messages[i] = message.Substring(24 * i, 24 * (i + 1));
                str = message.Substring(21*i,21);
                if (i == 0)
                {
                    SubmitChat(str,true);
                }
                else
                {
                    SubmitChat(str, false);
                }

            }
            //messages[number_of_line - 1] = message.Substring(24 * (number_of_line - 1));
            str = message.Substring(21 * (number_of_line));
            SubmitChat(str,false);
        }
        else
        {
            //SubmitChat(message);
            //messages[0] = message;
            str = message;
            SubmitChat(str,true);
        }

        //SubmitChat(messages);

    }

}
