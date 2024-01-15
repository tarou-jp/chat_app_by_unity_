using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicButton : MonoBehaviour
{
    [SerializeField] GameObject obj;
    public bool mic_status = false;

    public void Mic_Start()
    {
        if (mic_status == false)
        {
            ClientExample.instance.WSsend("WSA");
            obj.GetComponent<Image>().color = new Color32(255,0,0, 255);
            mic_status = true;
            Mic_Status.instance.mic_true();
        }
        else
        {
            ClientExample.instance.WSsend("WSA_Stop");
            obj.GetComponent<Image>().color = Color.white;
            mic_status = false;
            Mic_Status.instance.mic_false();
        }
    }
}
