using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleButon : MonoBehaviour
{
    public Text text_;
    [SerializeField] ButtonsColor button_color;

    public void ToSchedule()
    {
        DBManeger.instance.UpdateScheduleBox();
        text_.text = "スケジュール";
        button_color.ChangeColor(0,false);
    }
}
