using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Time_ : MonoBehaviour
{
    [SerializeField] GameObject minutes;
    [SerializeField] GameObject day;

    // Update is called once per frame
    void Update()
    {
        DateTime dt = DateTime.Now;
        minutes.GetComponent<Text>().text = dt.ToString("HH:mm");
        day.GetComponent<Text>().text = dt.ToString("MM/dd");
        if (dt.Hour == 0 && dt.Minute == 0)
        {
            DBManeger.instance.UpdateScheduleBox();
        }
    }
}
