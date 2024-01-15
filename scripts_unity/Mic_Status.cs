using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic_Status : MonoBehaviour
{

    public static Mic_Status instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool mic_statu = false;

    public void mic_true()
    {
        mic_statu = true;
    }

    public void mic_false()
    {
        mic_statu = false;
    }
}
