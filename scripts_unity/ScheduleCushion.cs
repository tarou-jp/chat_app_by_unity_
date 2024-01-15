using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System;

public class ScheduleCushion : MonoBehaviour
{
    public static ScheduleCushion instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //private int to ToInt()
    private DateTime TodayNow;

    public void ScheduleExtract(string sch)
    {
        //int year_i = 0;
        //int month_i = 0;
        //int day_i = 0;
        //int hour_i = 0;
        //int minutes_i = 0;
        string row_month = "0";
        string row_day = "0";
        string row_hour = "0";
        string row_minutes = "0";
        string memo = "";

        Debug.Log(sch);

        TodayNow = DateTime.Now;
        int year_i = TodayNow.Year;
        Debug.Log(year_i);

        if (Regex.IsMatch(sch, "([1-9]|1[0-2])月")) row_month = Regex.Match(sch, "([1-9]|1[0-2])月").Value;
        string month = row_month.Replace("月", "");
        int month_i = int.Parse(month);
        Debug.Log(month_i);

        if (Regex.IsMatch(sch, "([1-9]|[12][0-9]|3[01])日")) row_day = Regex.Match(sch, "([1-9]|[12][0-9]|3[01])日").Value;
        string day = row_day.Replace("日", "");
        int day_i = int.Parse(day);
        Debug.Log(day_i);

        if (Regex.IsMatch(sch, "([0-9]|[12][0-9])時")) row_hour = Regex.Match(sch, "([0-9]|[12][0-9])時").Value;
        string hour = row_hour.Replace("時", "");
        int hour_i = int.Parse(hour);
        Debug.Log(hour_i);

        if (Regex.IsMatch(sch, "([0-9]|[1-5][0-9])分")) row_minutes = Regex.Match(sch, "([0-9]|[1-5][0-9])分").Value;
        string minutes = row_minutes.Replace("分", "");
        int minutes_i = int.Parse(minutes);
        Debug.Log(minutes_i);

        memo = sch.Replace("スケジュール追加", "");
        Debug.Log(memo);
        memo = memo.Replace(row_month, "");
        Debug.Log(memo);
        memo = memo.Replace(row_day, "");
        Debug.Log(memo);
        Debug.Log(row_hour);
        memo = memo.Replace(row_hour, "");
        Debug.Log(memo);
        memo = memo.Replace(row_minutes, "");

        bool check_bool = DBManeger.instance.checkschedule(year_i,month_i,day_i,hour_i,minutes_i);

        if (!check_bool)
        {
            Message.instance.AdjustmentMessage("スケジュール追加に失敗しました...");
            PreparedVoice.instance.PlayPreparedAudioClip(2);
            LogBox.instance.PutLogText("error duplicate time in schedule");
        }
        else if (memo == "")
        {
            Message.instance.AdjustmentMessage("スケジュール追加に失敗しました...");
            PreparedVoice.instance.PlayPreparedAudioClip(2);
            LogBox.instance.PutLogText("error lack content data in schedule");
        }
        else if (month_i == 0)
        {
            Message.instance.AdjustmentMessage("スケジュール追加に失敗しました...");
            PreparedVoice.instance.PlayPreparedAudioClip(2);
            LogBox.instance.PutLogText("error lack month data in schedule");
        }
        else if (day_i == 0)
        {
            Message.instance.AdjustmentMessage("スケジュール追加に失敗しました...");
            PreparedVoice.instance.PlayPreparedAudioClip(2);
            LogBox.instance.PutLogText("error lack day data in schedule");
        }
        else
        {
            Debug.Log("year" + year_i + "month" + month_i + "day" +day_i + "hour" + hour_i + "minutes" + minutes_i + "memo" + memo);
            CreateSchedule.instance.CreateSchedule_(year_i, month_i,day_i,hour_i,minutes_i, memo);
            Message.instance.AdjustmentMessage("スケジュールを追加しました！");
            LogBox.instance.PutLogText("add schedule complete!");
            //DBManeger.instance.UpdateScheduleBox();
            PreparedVoice.instance.PlayPreparedAudioClip(1);
        }

    }
}
