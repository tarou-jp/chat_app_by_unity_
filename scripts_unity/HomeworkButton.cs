using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeworkButton : MonoBehaviour
{
    public Text text_;
    [SerializeField] ButtonsColor button_color;


    public void ToHomework()
    {
        ClientExample.instance.WSsend("manaba");
        text_.text = "未提出課題";
        button_color.ChangeColor(1,false);
    }
}
