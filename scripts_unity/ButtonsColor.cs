using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsColor : MonoBehaviour
{
    public int Mode_Id = 0;
    public GameObject[] objs;
    //Schedule:0,homework:1

    //public static ButtonsColor instance;
    //public void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //}

    public void ChangeColor(int i,bool repetition)
    {
        if (repetition)
        {
            objs[i].GetComponent<Image>().color = new Color32(147, 147, 147, 255);
            objs[i].GetComponent<Image>().color = Color.white;

        }
        else
        {
            if (Mode_Id != i)
            {
                objs[i].GetComponent<Image>().color = Color.white;
                objs[Mode_Id].GetComponent<Image>().color = new Color32(147, 147, 147, 255);
                Mode_Id = i;
            }
        }
    }
}
