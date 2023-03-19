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
    private VoiceService voiceService;

    [SerializeField]
    private List<VoiceObject> voiceObjects;

    private void Start()
    {
        voiceService.VoiceActionEvent.AddListener(HandleOnVoiceActionEvent);
    }

    private void OnDestroy()
    {
        voiceService.VoiceActionEvent.RemoveListener(HandleOnVoiceActionEvent);    
    }

    public void HandleOnVoiceActionEvent(VoiceAction voiceAction)
    {
        foreach (VoiceObject voiceObject in voiceObjects)
        {
            voiceObject.SetVoiceAction(voiceAction);
        }
    }
}
