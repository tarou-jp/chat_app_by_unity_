using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleIndex : MonoBehaviour
{
    public bool Is_empty = true;
    public Text text_;

    void Start()
    {
        text_ = this.GetComponent<Text>();
    }

    public void ScheduleTextShift(Schedule sch)
    {
        text_.text = sch.hour + ":" + sch.minutes + " " + sch.memo;
        Is_empty = false;
    }

    public void ClearScheduleIndex()
    {
        text_.text = "";
        Is_empty = true;
    }
}
