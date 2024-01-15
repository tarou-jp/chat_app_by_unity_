using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOTButton : MonoBehaviour
{
    public int IOT_ID;
    public string message_on;
    public string message_off;
    public bool Status = false;
    [SerializeField] ButtonsColor buttons_color;

    public void IOT_Action()
    {
        buttons_color.ChangeColor(IOT_ID,true);
        if (Status)
        {
            ClientExample.instance.WSsend(message_off);
            Status = false;
        }
        else
        {
            ClientExample.instance.WSsend(message_on);
            Status = true;
        }

    }

}
