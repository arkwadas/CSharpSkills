using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollFreeState : PlayerBaseState
{
    private readonly int RollFreeTreeHash = Animator.StringToHash("RollFreeTree");
    private readonly int RollForwardHash = Animator.StringToHash("RollForward");

    private Vector3 rollDirectionInput;
    private Vector3 movement;
    
    private float remainingRollTime;

    private const float CrossFadeDuration = 0.1f;
    public PlayerRollFreeState(PlayerStateMachine stateMachine, Vector3 rollDirectionInput) : base(stateMachine)
    {
        this.rollDirectionInput = rollDirectionInput;
    }

    public override void Enter()
    {
        

        remainingRollTime = stateMachine.RolDuration;
        movement += stateMachine.transform.forward * rollDirectionInput.magnitude * stateMachine.RolLength / stateMachine.RolDuration;


        stateMachine.Animator.SetFloat(RollForwardHash, rollDirectionInput.y);
        stateMachine.Animator.SetFloat(RollForwardHash, rollDirectionInput.x);
        stateMachine.Animator.CrossFadeInFixedTime(RollFreeTreeHash, CrossFadeDuration);

        stateMachine.Health.SetInvunerable(true);
    }



    public override void Tick(float deltaTime)
    {
        Move(movement, deltaTime);
        if (stateMachine.Controller.velocity.magnitude <= 0f)
        {
            stateMachine.SwitchState(new PlayerFallingState(stateMachine));
            return;
        }

        FaceTarget();

        remainingRollTime -= deltaTime;

        if (remainingRollTime <= 0f)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine)); //do zmiany ten kod
        }
        
    }
    public override void Exit()
    {
        stateMachine.Health.SetInvunerable(false);
    }
    
}