using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[SerializeField]
public class ScheduleDB : ScriptableObject
{
    public List<Schedule> ScheduleList = new List<Schedule>();
}
