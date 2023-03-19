using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public enum VoiceActionType
{
    None,
    Stop,
    Walk,
    Bounce,
    Roll,
    Jump,
    Spin,
    Left,
    Right,
    Backward,
    Forward,
    Bark,
    Fly,
}

public class VoiceService : MonoBehaviour
{
    public Dictionary<string, VoiceActionType> voiceActions = new Dictionary<string, VoiceActionType>()
    {
        {"Stop", VoiceActionType.Stop},
        {"Walk", VoiceActionType.Walk},
        {"Bounce", VoiceActionType.Bounce},
        {"Roll", VoiceActionType.Roll},
        {"Jump", VoiceActionType.Jump},
        {"Spin", VoiceActionType.Spin},
        {"Left", VoiceActionType.Left},
        {"Right", VoiceActionType.Right},
        {"Backward", VoiceActionType.Backward},
        {"Forward", VoiceActionType.Forward},
        {"Bark", VoiceActionType.Bark},
        {"Fly", VoiceActionType.Fly},
    };
    public UnityEvent<VoiceActionType> VoiceActionEvent = new UnityEvent<VoiceActionType>();

    private KeywordRecognizer keywordRecognizer;

    public Text voiceText;

    private void Start()
    {
        keywordRecognizer = new KeywordRecognizer(voiceActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += HandleOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void HandleOnPhraseRecognized(PhraseRecognizedEventArgs phraseRecognizedEventArgs)
    {
        VoiceActionType voiceActionType = VoiceActionType.None;

        voiceActions.TryGetValue(phraseRecognizedEventArgs.text, out voiceActionType);
        
        if (voiceActionType != VoiceActionType.None)
        {
            if (voiceText != null)
            {
                voiceText.text = phraseRecognizedEventArgs.text;
            }
            VoiceActionEvent?.Invoke(voiceActionType);
        }
    }
}
