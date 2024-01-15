using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPSlider : MonoBehaviour
{
    [SerializeField] Slider NPslider;
    public float NP_val = 0;

    public static NPSlider instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void addnum(int num)
    {
        NP_val += num;
    }

    public void NPsliderShift()
    {
        NPslider.value = NP_val / 5;
    }
}
