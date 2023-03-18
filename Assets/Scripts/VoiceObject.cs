using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VoiceObjectType
{
    Dog,
}

public abstract class VoiceObject : MonoBehaviour
{
    public abstract VoiceObjectType voiceObjectType { get; }
    public VoiceActionType currentVoiceActionType { get; protected set; } = VoiceActionType.Stop;

    [SerializeField]
    protected AudioSource voiceSource;

    [SerializeField]
    protected Dictionary<string, AudioClip> voiceClips;

    [SerializeField]
    protected Animator animator;

    [SerializeField]
    protected Rigidbody objectRigidbody;

    public void PerformVoiceAction(VoiceActionType voiceActionType)
    {
        currentVoiceActionType = voiceActionType;

        switch (voiceActionType)
        {
            case (VoiceActionType.Stop):
            {
                PerformStop();
                break;
            }
            case (VoiceActionType.Walk):
            {
                PerformWalk();
                break;
            }
            case (VoiceActionType.Bounce):
            {
                PerformBounce();
                break;
            }
            case (VoiceActionType.Roll):
            {
                PerformRoll();
                break;
            }
            case (VoiceActionType.Spin):
            {
                PerformSpin();
                break;
            }
            case (VoiceActionType.Left):
            {
                PerformLeft();
                break;
            }
            case (VoiceActionType.Right):
            {
                PerformRight();
                break;
            }
            case (VoiceActionType.Backward):
            {
                PerformBackward();
                break;
            }
            case (VoiceActionType.Forward):
            {
                PerformForward();
                break;
            }
            case (VoiceActionType.Bark):
            {
                PerformBark();
                break;
            }
            case (VoiceActionType.Fly):
            {
                PerformFly();
                break;
            }
        }
    }

    public virtual void PerformStop()
    {

    }

    public virtual void PerformWalk()
    {

    }

    public virtual void PerformBounce()
    {

    }

    public virtual void PerformRoll()
    {

    }

    public virtual void PerformSpin()
    {

    }

    public virtual void PerformLeft()
    {

    }

    public virtual void PerformRight()
    {

    }

    public virtual void PerformBackward()
    {

    }

    public virtual void PerformForward()
    {

    }

    public virtual void PerformBark()
    {

    }

    public virtual void PerformFly()
    {

    }
}
