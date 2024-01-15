using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoSlider : MonoBehaviour
{
    public float emo_now;
    Slider emo_slider;


    public void Start()
    {
        emo_slider = this.GetComponent<Slider>();
    }

    public void ShiftEmo(int emo)
    {
        //Debug.Log(emo);
        emo_now = emo;
        emo_now = emo_now /5;
        emo_slider.value = emo_now;
        //Debug.Log("koko");
    }
}
