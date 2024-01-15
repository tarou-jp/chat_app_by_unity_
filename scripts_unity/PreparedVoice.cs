using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparedVoice : MonoBehaviour
{
    //public AudioClip undefined;
    //public AudioClip schedule;
    //public AudioClip miss_schedule;
    //public AudioClip TV;
    public AudioClip[] audioclips;
    public GameObject audio_source;

    public static PreparedVoice instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    //public void UndefinedAudioClipPlay()
    //{
    //    audio_source.GetComponent<AudioSource>().clip = undefined;
    //    audio_source.GetComponent<AudioSource>().Play();
    //}

    //public void ScheduleAudioClipPlay()
    //{
    //    audio_source.GetComponent<AudioSource>().clip = schedule;
    //    audio_source.GetComponent<AudioSource>().Play();
    //}

    //public void MissScheduleAudioClipPlay()
    //{
    //    audio_source.GetComponent<AudioSource>().clip = miss_schedule;
    //    audio_source.GetComponent<AudioSource>().Play();
    //}

    //public void TVAudioClipPlay()
    //{
    //    audio_source.GetComponent<AudioSource>().clip = TV;
    //    audio_source.GetComponent<AudioSource>().Play();
    //}

    public void PlayPreparedAudioClip(int i)
    {
        audio_source.GetComponent<AudioSource>().clip = audioclips[i];
        audio_source.GetComponent<AudioSource>().Play();
        if (Mic_Status.instance.mic_statu)
        {
            Invoke(nameof(sendWPA), audioclips[i].length + 2.5f);
        }
    }

    private void sendWPA()
    {
        ClientExample.instance.WSsend("WSA");
        Debug.Log("ok");
    }
}
