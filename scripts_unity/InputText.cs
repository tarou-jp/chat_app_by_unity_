using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour
{
    public InputField inputField;
    //public string text_;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Return))
    //    {
    //        text_ = inputField.text;
    //        if (text_ == "")
    //        {
    //            ClientExample.instance.SendMessage(text_);
    //            text_ = "";
    //        }
    //    }
    //}

    public void SubmitText()
    {
        if (inputField.text != "")
        {
            ClientExample.instance.WSsend(inputField.text);
            inputField.text = "";
        }
    }
}
