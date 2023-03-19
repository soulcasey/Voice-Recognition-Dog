using System;
using System.Collections.Generic;
using UnityEngine;

public enum VoiceObjectType
{
    Dog,
}

public enum VoiceSoundType
{
    Bark,
}

public abstract class VoiceObject : MonoBehaviour
{
    public abstract VoiceObjectType voiceObjectType { get; }
    public VoiceActionType VoiceActionType { get; protected set; } = VoiceActionType.Stop;
    public VoiceActionType currentVoiceActionType { get; protected set; } = VoiceActionType.Stop;

    [SerializeField]
    protected AudioSource voiceSource;

    [SerializeField]
    protected Animator animator;
    protected int currentSpeed = 0;

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

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * currentSpeed;

        if (transform.position.y < -5) // If the object falls off
        {
            transform.position = new Vector3(0, 5, 0);
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

    public virtual void PerformJump()
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
