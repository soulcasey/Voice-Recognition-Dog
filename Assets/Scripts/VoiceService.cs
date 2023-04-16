using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
using UnityEngine.Windows.Speech;
#endif

public class VoiceService : MonoBehaviour
{
    public static VoiceService Instance = null;

    private List<VoiceAction> availableVoiceActions = new List<VoiceAction>()
    {
        new StopAction(),
        new WalkAction(),
        new BounceAction(),
        new RollAction(),
        new JumpAction(),
        new SpinAction(),
        new LeftAction(),
        new RightAction(),
        new BackwardAction(),
        new ForwardAction(),
        new BarkAction(),
    };
    public UnityEvent<VoiceAction> VoiceActionEvent = new UnityEvent<VoiceAction>();

    private void Awake()
    {
        Instance = this;
        Setup();
    }

    private void InvokeVoiceActionEvent(string speech)
    {
        VoiceAction recognizedVoiceAction = availableVoiceActions.Find(voiceAction => voiceAction.GetVoiceActionCommand() == speech.ToUpper());

        if (recognizedVoiceAction != null)
        {
            VoiceActionEvent?.Invoke(recognizedVoiceAction);
        }
    }

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN

    private UnityEngine.Windows.Speech.KeywordRecognizer keywordRecognizer;

    public void Setup()
    {

        string[] voiceActionCommands = availableVoiceActions.Select(voiceAction => voiceAction.GetVoiceActionCommand()).ToArray();

        keywordRecognizer = new KeywordRecognizer(voiceActionCommands);
        keywordRecognizer.OnPhraseRecognized += HandleOnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void HandleOnPhraseRecognized(PhraseRecognizedEventArgs phraseRecognizedEventArgs)
    {
        string speech = phraseRecognizedEventArgs.text;

        InvokeVoiceActionEvent(speech);
    }

#else
    
    private AndroidJavaClass javaClass = null;
    private AndroidJavaObject instance = null;
    private const string JAVA_CLASS_PACKAGE_NAME = "com.example.eric.unityspeechrecognizerplugin.SpeechRecognizerFragment";
    private const bool IS_CONTINUOUS = true;
    private const string LANGAUGE_CODE = "en-US";
    private const int MAX_RESULTS = 1;

    public void Setup()
    {
        javaClass = new AndroidJavaClass(JAVA_CLASS_PACKAGE_NAME);
        javaClass.CallStatic("SetUp", this.gameObject.name);
        instance = javaClass.GetStatic<AndroidJavaObject>("instance");

        instance.Call("StartListening", IS_CONTINUOUS, LANGAUGE_CODE, MAX_RESULTS);
    }

    public void OnResult(string recognizedResult)
    {
        char[] delimiterChars = { '~' };
        string[] results = recognizedResult.Split(delimiterChars);

        for (int i = 0; i < results.Length; i ++)
        {
            Debug.Log(results[i]);

            InvokeVoiceActionEvent(results[i]);
        }
    }

    public void OnError(string recognizedError)
    {
        VoiceActionEvent?.Invoke(new NoAction());
    }

#endif
}