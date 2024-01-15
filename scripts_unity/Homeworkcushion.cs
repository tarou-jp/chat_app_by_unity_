using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class Homeworkcushion : MonoBehaviour
{
    public static Homeworkcushion instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        sch = ScriptableObject.CreateInstance("Schedule") as Schedule;
    }

    private Schedule sch;

    private void Extractdaydate(string pre)
    {
        sch.year = int.Parse(pre.Substring(0, 4));
        sch.month = int.Parse(pre.Substring(5, 2));
        sch.day = int.Parse(pre.Substring(8, 2));
        sch.hour = int.Parse(pre.Substring(11, 2));
        sch.minutes = int.Parse(pre.Substring(14, 2));
        sch.memo = pre.Substring(17);
    }

    public void PassHomework(string work)
    {
        Debug.Log(work);
        bool result = Regex.IsMatch(work, "20[2-9][0-9]-[0-1][0-9]-[0-3][0-9] [0-9][0-9]:[0-9][0-9]");
        DateTime dt = DateTime.Now;
        ScheduleBox.instance.ClearScheduleBox();
        Debug.Log(result);
        if (result)
        {
            Extractdaydate(work);
            if (dt.Year == sch.year && dt.Month == sch.month && dt.Day == sch.day && dt.Hour == sch.day && dt.Minute == sch.minutes)
            {
                ScheduleBox.instance.PutTodaySchedule(sch);
            }
            else
            {
                ScheduleBox.instance.PutNextSchedule(sch);
            }
        }
    }
}
