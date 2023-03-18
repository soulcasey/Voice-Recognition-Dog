using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogObject : VoiceObject
{
    public override VoiceObjectType voiceObjectType { get; } = VoiceObjectType.Dog;
    private const float DOG_SPEED = 3f;

    public override void PerformStop()
    {
        if (objectRigidbody != null)
        {
            objectRigidbody.velocity = Vector3.zero;
        }
    }

    public override void PerformWalk()
    {
        if (objectRigidbody != null)
        {
            objectRigidbody.velocity = transform.forward * DOG_SPEED;
        }
    }

    public override void PerformBounce()
    {

    }

    public override void PerformRoll()
    {

    }

    public override void PerformSpin()
    {

    }

    public override void PerformLeft()
    {

    }

    public override void PerformRight()
    {

    }

    public override void PerformBackward()
    {

    }

    public override void PerformForward()
    {

    }

    public override void PerformBark()
    {

    }
}
