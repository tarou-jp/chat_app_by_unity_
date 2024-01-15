using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmoCushion : MonoBehaviour
{

    public EmoSlider emo_s;
    public int emo_p;
    public int adjust_i;
    //public bool emo_b = false;

    private int ToInt(string str)
    {
        int num;
        if (str == "0,") num = 0;
        else if (str == "1,") num = 1;
        else if (str == "2,") num = 2;
        else if (str == "3,") num = 3;
        else if (str == "4,") num = 4;
        else if (str == "5,") num = 5;
        else if (str == "0") num = 0;
        else if (str == "1") num = 1;
        else if (str == "2") num = 2;
        else if (str == "3") num = 3;
        else if (str == "4") num = 4;
        else if (str == "5") num = 5;
        else
        {
            num = 0;
            LogBox.instance.PutLogText("emotion_anc is not defined");
        }
        return num;
    }

    public void passemo(string emo)
    {
        int len = emo.Length;
        emo_p = ToInt(emo.Substring(len - 2));
        int num = emo_p - 3;
        emo_s.ShiftEmo(emo_p);
        NPSlider.instance.addnum(num*adjust_i);
        NPSlider.instance.NPsliderShift();
    }

    //private void Update()
    //{
    //    if (emo_b)
    //    {
    //        emo_s.ShiftEmo(emo_p);
    //    }
    //}
}
