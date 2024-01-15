using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using SpeechIO;

public class Mic : MonoBehaviour
{

    SpeechOut speechOut = new SpeechOut();
    //SpeechIn speechIn = new SpeechIn(OnRecognized);

    //void Start()
    //{
    //    Dialog();
    //}

    //async void Dialog()
    //{
    //    await speechOut.Speak("Hello!");
    //    await speechIn.Listen(new string[] { "Hello", "Hi", "Hey" });
    //    await speechOut.Speak("How are you doing?");
    //    await speechIn.Listen(new string[] { "I'm fine", "Nah", "I'm Sick" });
    //    //...
    //}

    //[SerializeField]
    //private Text m_Hypotheses;

    //[SerializeField]
    //private Text m_Recognitions;

    //private DictationRecognizer m_DictationRecognizer;

    //void Start()
    //{
    //    m_DictationRecognizer = new DictationRecognizer();

    //    m_DictationRecognizer.DictationResult += (text, confidence) =>
    //    {
    //        Debug.LogFormat("Dictation result: {0}", text);
    //        m_Recognitions.text += text + "\n";
    //    };

    //    m_DictationRecognizer.DictationHypothesis += (text) =>
    //    {
    //        Debug.LogFormat("Dictation hypothesis: {0}", text);
    //        m_Hypotheses.text += text;
    //    };

    //    m_DictationRecognizer.DictationComplete += (completionCause) =>
    //    {
    //        if (completionCause != DictationCompletionCause.Complete)
    //            Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
    //    };

    //    m_DictationRecognizer.DictationError += (error, hresult) =>
    //    {
    //        Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
    //    };

    //    m_DictationRecognizer.Start();
    //}
}