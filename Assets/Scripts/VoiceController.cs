using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UI;

#if UNITY_STANDALONE_WIN
using UnityEngine.Windows.Speech;
#endif

public class VoiceController : MonoBehaviour
{
    [SerializeField]
    private List<VoiceObject> voiceObjects;
    private KeywordRecognizer speech;
    [SerializeField]
    private Text textVoice;

    private void Start()
    {
        VoiceService.VoiceActionEvent.AddListener(HandleOnVoiceActionEvent);
    }

    private void OnDestroy()
    {
        VoiceService.VoiceActionEvent.RemoveListener(HandleOnVoiceActionEvent);    
    }

    private void HandleOnVoiceActionEvent(VoiceActionType voiceActionType)
    {
        foreach (VoiceObject voiceObject in voiceObjects)
        {
            voiceObject.PerformVoiceAction(voiceActionType);
        }
    }
}
