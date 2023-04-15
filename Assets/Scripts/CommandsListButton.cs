using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandsListButton : MonoBehaviour
{
    [SerializeField]
    private Button button;

    [SerializeField]
    private Text buttonText;


    [SerializeField]
    private GameObject commandsList;

    private const string SHOW_COMMANDS_TEXT = "Show\n Commands";
    private const string HIDE_COMMANDS_TEXT = "Hide\n Commands";

    private void Start()
    {
        button.onClick.AddListener(HandleOnCommandsListButtonClick);
    }

    private void HandleOnCommandsListButtonClick()
    {
        bool isDisplayList = commandsList.activeSelf == false;

        commandsList.SetActive(isDisplayList);
        buttonText.text = isDisplayList ? HIDE_COMMANDS_TEXT : SHOW_COMMANDS_TEXT;
    }
}
