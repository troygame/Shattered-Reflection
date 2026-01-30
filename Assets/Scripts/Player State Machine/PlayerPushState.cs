using UnityEngine;

public class PlayerPushState : PlayerState
{
    public PlayerPushState (Player player, StateMachine stateMachine) : base(player, stateMachine)
    {

    }

    public override Enter() 
    {
        base.Enter();

        if (player.animator != null)
        {
            player.animator.Play("Push"); // placeholder
        }

        ApplyGravityMultiplier(false);
    }

    if (player.JumpPressed && player.IsGrounded)
    {
        stateMachine.ChangeState(PlayerState.JumpState);
    }
    else if (Mathf.Abs(player.MoveInput) <= 0.01f)
    {
        stateMachine.ChangeState(player.IdleState);
    }
    else if (!player.IsGrounded)
    {
        stateMachine.ChangeState(player.FallState);
    }

}
