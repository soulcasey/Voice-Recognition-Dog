using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleController : MonoBehaviour
{
    [SerializeField]
    private GameObject chatBubble;

    [SerializeField]
    private TMP_Text text;

    public const float CHAT_BUBBLE_DISPLAY_DURATION = 1.5f;

    private void Start()
    {
        VoiceService.Instance.VoiceActionEvent.AddListener(HandleOnVoiceActionEvent);
    }

    private void OnDestroy()
    {
        VoiceService.Instance.VoiceActionEvent.RemoveListener(HandleOnVoiceActionEvent);    
    }

    private void HandleOnVoiceActionEvent(VoiceAction voiceAction)
    {
        DisplayChatBubble(voiceAction.GetVoiceActionCommand());
    }

    public void DisplayChatBubble(string message)
    {
        StopAllCoroutines();
        StartCoroutine(ShowChatBubble(message));
    }

    private IEnumerator ShowChatBubble(string message)
    {
        text.text = message;
        chatBubble.SetActive(true);

        yield return new WaitForSeconds(CHAT_BUBBLE_DISPLAY_DURATION);

        chatBubble.SetActive(false);
        text.text = string.Empty;
    }
}
