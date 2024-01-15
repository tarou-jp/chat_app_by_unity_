using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public GameObject obj;

    public static test instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ClientExample.instance.ConectServer();
            //ScheduleCushion.instance.ScheduleExtract("スケジュール追加4月20日卒業式");

        }
    }
}