using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogObject : VoiceObject
{
    public override VoiceObjectType voiceObjectType { get; } = VoiceObjectType.Dog;
    private const float DOG_SPEED = 3f;

    public override void PerformStop()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 210, 0);
        currentSpeed = 0;
        animator.SetInteger("movement", 0);
    }

    public override void PerformWalk()
    {
        currentSpeed = 1;
        animator.SetInteger("movement", 6);
    }

    public override void PerformBounce()
    {
        animator.SetInteger("movement", 1);
    }

    public override void PerformRoll()
    {
        currentSpeed = 5;
        animator.SetInteger("movement", 2);
    }

    public override void PerformJump()
    {
        animator.SetInteger("movement", 3);
    }

    public override void PerformSpin()
    {
        animator.SetInteger("movement", 5);
    }

    public override void PerformLeft()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);

        if (animator.GetInteger("movement") == 0)
        {
            PerformWalk();
        }
    }

    public override void PerformRight()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);

        if (animator.GetInteger("movement") == 0)
        {
            PerformWalk();
        }
    }

    public override void PerformBackward()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (animator.GetInteger("movement") == 0)
        {
            PerformWalk();
        }
    }

    public override void PerformForward()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

        if (animator.GetInteger("movement") == 0)
        {
            PerformWalk();
        }
    }

    public override void PerformBark()
    {
        voiceSource.Play();
    }
}
