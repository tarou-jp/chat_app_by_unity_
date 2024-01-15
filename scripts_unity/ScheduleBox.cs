using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleBox : MonoBehaviour
{
    public ScheduleIndex[] today_scheduleindexs;
    public ScheduleIndex[] next_scheduleindexs;


    public static ScheduleBox instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PutTodaySchedule(Schedule sch)
    {
        foreach (ScheduleIndex today_scheduleindex in today_scheduleindexs)
        {
            if (today_scheduleindex.Is_empty)
            {
                today_scheduleindex.ScheduleTextShift(sch);
                return;
            }
        }
    }

    public void PutNextSchedule(Schedule sch)
    {
        foreach (ScheduleIndex next_scheduleindex in next_scheduleindexs)
        {
            if (next_scheduleindex.Is_empty)
            {
                next_scheduleindex.ScheduleTextShift(sch);
                return;
            }
        }

    }

    public void ClearScheduleBox()
    {
        foreach (ScheduleIndex today_scheduleindex in today_scheduleindexs)
        {
            today_scheduleindex.ClearScheduleIndex();
        }
        foreach (ScheduleIndex next_scheduleindex in next_scheduleindexs)
        {
            next_scheduleindex.ClearScheduleIndex();
        }

    }
}
