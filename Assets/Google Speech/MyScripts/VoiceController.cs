using System.Collections;
using System.Collections.Generic;
using TextSpeech;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class VoiceController : MonoBehaviour
{
    const string LANG_CODE = "en-US";

    //gameObject
    public GameObject cube;

    [SerializeField]
    Text uiText;

    void Update()
    {
        Setup(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;
        TextToSpeech.instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.instance.onDoneCallback = OnSpeakStop;

        //activate and deactivate gameObject
        if ((uiText.text == "Cube") || (uiText.text == "cube"))
        {
            cube.SetActive(true);
        }
        if ((uiText.text == "Remove") || (uiText.text == "remove"))
        {
            cube.SetActive(false);
        }

        CheckPermission();
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if(!Permission.HasUserAuthorizedPermission(Permission.Microphone)){
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }

#region Text to Speech

    public void StartSpeaking(string message){
        TextToSpeech.instance.StartSpeak(message);
    }

    public void StopSpeaking(string message)
    {
        TextToSpeech.instance.StopSpeak();
    }

    void OnSpeakStart(){
        Debug.Log("Talking Started...");
    }
    void OnSpeakStop()
    {
        Debug.Log("Talking Stop...");
    }
#endregion

#region Speech to Text

    public void StartListening(){
        SpeechToText.instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.instance.StopRecording();
    }

    void OnFinalSpeechResult(string result){
        uiText.text = result;
    }

    void OnPartialSpeechResult(string result)
    {
        uiText.text = result;
    }


#endregion
    void Setup(string code){
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
