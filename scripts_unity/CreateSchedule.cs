using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSchedule : MonoBehaviour
{
    public static CreateSchedule instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CreateSchedule_(int year, int month, int day, int hour, int minutes, string text)
    {
        //Schedule schedule = new Schedule();
        Schedule schedule = ScriptableObject.CreateInstance("Schedule") as Schedule;
        schedule.year = year;
        schedule.month = month;
        schedule.day = day;
        schedule.hour = hour;
        schedule.minutes = minutes;
        schedule.memo = text;
        DBManeger.instance.AddScheduleData(schedule);
    }
}
