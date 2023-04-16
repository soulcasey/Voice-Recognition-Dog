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
}

public abstract class VoiceAction
{
    public abstract VoiceActionType GetVoiceActionType();
    public abstract string GetVoiceActionCommand();
    public abstract void PerformVoiceAction(VoiceObject voiceObject);
    public virtual void OnEnter(VoiceObject previousVoiceObject) { }
    public virtual void OnExit(VoiceObject currentVoiceObject) { }
}

public class NoAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.None;
    }

    public override string GetVoiceActionCommand()
    {
        return "Error... Hmm";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(210);
        voiceObject.SetSpeed(0);
        voiceObject.SetAnimator(0);
    }
}

public class StopAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Stop;
    }

    public override string GetVoiceActionCommand()
    {
        return "STOP";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(210);
        voiceObject.SetSpeed(0);
        voiceObject.SetAnimator(0);
    }
}

public class WalkAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Walk;
    }

    public override string GetVoiceActionCommand()
    {
        return "WALK";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetSpeed(1);
        voiceObject.SetAnimator(6);
    }
}

public class BounceAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Bounce;
    }

    public override string GetVoiceActionCommand()
    {
        return "BOUNCE";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetSpeed(1);
        voiceObject.SetAnimator(1);
    }
}

public class RollAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Roll;
    }

    public override string GetVoiceActionCommand()
    {
        return "ROLL";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetSpeed(5);
        voiceObject.SetAnimator(2);
    }
}

public class JumpAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Jump;
    }

    public override string GetVoiceActionCommand()
    {
        return "JUMP";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetSpeed(1);
        voiceObject.SetAnimator(3);
    }
}

public class SpinAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Spin;
    }

    public override string GetVoiceActionCommand()
    {
        return "SPIN";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetSpeed(1);
        voiceObject.SetAnimator(5);
    }
}

public class LeftAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Left;
    }

    public override string GetVoiceActionCommand()
    {
        return "LEFT";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(270);
    }
}

public class RightAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Right;
    }

    public override string GetVoiceActionCommand()
    {
        return "RIGHT";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(90);
    }
}

public class BackwardAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Backward;
    }

    public override string GetVoiceActionCommand()
    {
        return "BACKWARD";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(0);
    }
}

public class ForwardAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Forward;
    }

    public override string GetVoiceActionCommand()
    {
        return "FORWARD";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.SetRotation(180);
    }
}

public class BarkAction : VoiceAction
{
    public override VoiceActionType GetVoiceActionType()
    {
        return VoiceActionType.Bark;
    }

    public override string GetVoiceActionCommand()
    {
        return "BARK";
    }

    public override void PerformVoiceAction(VoiceObject voiceObject)
    {
        voiceObject.PlaySound();
    }
}