using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class DBManeger : MonoBehaviour
{
    [SerializeField] private ScheduleDB ScheduleDataBase;
    //public bool schedule_update = false;

    public static DBManeger instance; 
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    public void UpdateScheduleBox()
    {
        var dic = new Dictionary<int, Schedule>();
        Debug.Log("aaskdfjs");
        int count = ScheduleDataBase.ScheduleList.Count;
        ScheduleBox.instance.ClearScheduleBox();

        for (int i = 0; i < count; i++)
        {
            Schedule sch = ScriptableObject.CreateInstance("Schedule") as Schedule;
            sch = ScheduleDataBase.ScheduleList[i];
            int id = ((sch.day + sch.month*31)*24 + sch.hour)*60 + sch.minutes ;
            //Debug.Log(id);

            dic.Add(id, sch);
        }

        foreach(var n in dic.OrderBy(c => c.Key)){
            DateTime dt = DateTime.Now;
            if (n.Value.year == dt.Year && n.Value.month == dt.Month && n.Value.day == dt.Day)
            {
                ScheduleBox.instance.PutTodaySchedule(n.Value);
            }
            else
            {
                if (n.Value.year == dt.Year)
                {
                    if (n.Value.month == dt.Month)
                    {
                        if (n.Value.day > dt.Day)
                        {
                            ScheduleBox.instance.PutNextSchedule(n.Value);
                        }
                    }
                    else if (n.Value.month > dt.Month)
                    {
                        ScheduleBox.instance.PutNextSchedule(n.Value);
                    }
                }
                else if (n.Value.year > dt.Year)
                {
                    ScheduleBox.instance.PutNextSchedule(n.Value);
                }
            }
            
        }

    }

    public void AddScheduleData(Schedule schedule_)
    {
        //schedule_update = true;
        ScheduleDataBase.ScheduleList.Add(schedule_);
        UpdateScheduleBox();
    }

    public bool checkschedule(int year , int month , int day , int hour , int minutes)
    {
        bool res = true;
        int count = ScheduleDataBase.ScheduleList.Count;
        for (int i = 0; i < count; i++)
        {
            Schedule sch = ScriptableObject.CreateInstance("Schedule") as Schedule;
            sch = ScheduleDataBase.ScheduleList[i];
            if (year == sch.year && month == sch.month && day == sch.day && hour == sch.hour && minutes == sch.minutes)
            {
                res = false;
            }
        }

        return res;
    }
    //private void Update()
    //{
    //    if (schedule_update)
    //    {
    //        UpdateScheduleBox();
    //        //schedule_update = false;
    //    }
    //}

    //０時になったらスケジュールボックス更新
    //同じ時間帯にスケジュール追加禁止
    //スケジュールのネクスト
}
