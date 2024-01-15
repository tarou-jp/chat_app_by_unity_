using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEditor;
using UnityEngine.Networking;
using System;
//using WavUtility;

public class Voice : MonoBehaviour
{

    private string url = "http://localhost:50031";
    //private string MA_url = "http://localhost:50031/synthesis";
    private string my_query;
    public AudioClip audioClip;
    public GameObject audio_source;
    //private float[] samples;
    //public AudioClip audio_;

    public static Voice instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    [System.Serializable]
    public class JsonClass
    {

        [SerializeField]
        private int value;
        public int Value { get { return value; } }

        [SerializeField]
        private string text;
        public string Text { get { return text; } }

    }

    public IEnumerator Post_RequestMQ(string message)
    {

        WWWForm form = new WWWForm();

        using (UnityWebRequest MQrequest = UnityWebRequest.Post($"{url}/audio_query?text={message}&speaker={0}",form))
        {

            yield return MQrequest.SendWebRequest();

            if (MQrequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(MQrequest.error);
            }
            else
            {
                //Debug.Log("Form upload complete!");
                LogBox.instance.PutLogText("MQ form uplode complete!");
                my_query = MQrequest.downloadHandler.text;
                Debug.Log(my_query);
            }
            MQrequest.Dispose();
        }

        StartCoroutine(Post_requestMA());
    }


    public IEnumerator Post_requestMA()
    {

        byte[] bodyRaw = Encoding.UTF8.GetBytes(my_query);

        using (UnityWebRequest MArequest = new UnityWebRequest($"{url}/synthesis?speaker={0}", "POST")) 
        {

            MArequest.SetRequestHeader("Content-Type", "application/json");
            MArequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            MArequest.downloadHandler = new DownloadHandlerBuffer();


            yield return MArequest.SendWebRequest();

            if (MArequest.result != UnityWebRequest.Result.Success)
            {
                //Debug.Log(MArequest.error);
            }
            else
            {
                LogBox.instance.PutLogText("MA Form upload complete!");
                //Debug.Log("Form upload complete!");
                audioClip = ToAudioClip(MArequest.downloadHandler.data);
                audio_source.GetComponent<AudioSource>().clip = audioClip;
                audio_source.GetComponent<AudioSource>().Play();
                Debug.Log(Mic_Status.instance.mic_statu);
                if (Mic_Status.instance.mic_statu)
                {
                    Invoke(nameof(sendWPA), audioClip.length + 2.5f);
                }
                //ClientExample.instance.WSsend("WSA");
            }

            MArequest.Dispose();
        }
    }

    public static AudioClip ToAudioClip(byte[] data)
    {
        // ヘッダー解析
        int channels = data[22];
        int frequency = BitConverter.ToInt32(data, 24);
        int length = data.Length - 44;
        float[] samples = new float[length / 2];

        // 波形データ解析
        for (int i = 0; i < length / 2; i++)
        {
            short value = BitConverter.ToInt16(data, i * 2 + 44);
            //Debug.Log(value);
            //samples[i] = value / 32768f;
            samples[i] = value / 32768f;
            //Debug.Log(samples[i]);
            //Debug.Log(value);

        }

        // AudioClipを作成
        AudioClip audioClip_ = AudioClip.Create("AudioClip", samples.Length, channels, frequency, false);
        audioClip_.SetData(samples,0);
        //audioClip.
        //audioClip_.play
        //audioClip = audioCli
        return audioClip_;
    }

    public void CreateVoice(string message)
    {
        StartCoroutine(Post_RequestMQ(message));
    }

    private void sendWPA()
    {
        ClientExample.instance.WSsend("WSA");
        Debug.Log("ok");
    }
}
