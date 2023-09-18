using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodgingState : PlayerBaseState
{
    private readonly int RollTreeHash = Animator.StringToHash("RollTree");
    private readonly int RollForwardHash = Animator.StringToHash("RollForward");
    private readonly int RollRightHash = Animator.StringToHash("RollRight");

    private Vector3 rollDirectionInput;
    private float remainingRollTime;

    private const float CrossFadeDuration = 0.1f;
    public PlayerDodgingState(PlayerStateMachine stateMachine, Vector3 rollDirectionInput) : base(stateMachine)
    {
        this.rollDirectionInput = rollDirectionInput;
    }

    public override void Enter()
    {
        remainingRollTime = stateMachine.RolDuration;

        

        stateMachine.Animator.SetFloat(RollForwardHash, rollDirectionInput.y);
        stateMachine.Animator.SetFloat(RollRightHash, rollDirectionInput.x);
        stateMachine.Animator.CrossFadeInFixedTime(RollTreeHash, CrossFadeDuration);

        stateMachine.Health.SetInvunerable(true);

        /*if (Time.time - stateMachine.PreviusDodgeTime < stateMachine.DodgeCooldown) { return; }


        stateMachine.SetDodgeTime(Time.time);
        rollDirectionInput = stateMachine.InputRead.MovementValue;
        remainingRollTime = stateMachine.RolDuration;

        stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);
        stateMachine.Health.SetInvunerable(true);
         stateMachine.Animator.SetFloat(RollHash, rollDirectionInput.sqrMagnitude);
         stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);
         remainingRollTime = stateMachine.RolDuration;

         stateMachine.Health.SetInvunerable(true);
        // stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);*/
    }

    

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();
        movement += stateMachine.transform.right * rollDirectionInput.x * stateMachine.RolLength / stateMachine.RolDuration;
        movement += stateMachine.transform.forward * rollDirectionInput.y * stateMachine.RolLength / stateMachine.RolDuration;

        Move(movement, deltaTime);
        FaceTarget();

        remainingRollTime -= deltaTime;

        if(remainingRollTime <= 0f)
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine)); //do zmiany ten kod
        }
       /* else
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        }    */
    }
    public override void Exit()
    {
        stateMachine.Health.SetInvunerable(false);
    }
}
