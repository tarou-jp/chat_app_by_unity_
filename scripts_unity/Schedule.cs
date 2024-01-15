using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
[SerializeField]
public class Schedule : ScriptableObject
{
    public int year;
    public int month;
    public int day;
    public int hour;
    public int minutes;
    public string memo;
}
