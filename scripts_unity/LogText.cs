using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour
{
    public bool is_empty;
    public string text_;

    public void ShiftLogText(string text)
    {
        this.GetComponent<Text>().text = text;
        is_empty = false;
        text_ = text;
    }

    public void ClearLogText()
    {
        this.GetComponent<Text>().text = "";
        is_empty = true;
        text_ = "";
    }
}
