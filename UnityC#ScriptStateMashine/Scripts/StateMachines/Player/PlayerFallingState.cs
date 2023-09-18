using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerBaseState

    
{
    public PlayerFallingState(PlayerStateMachine stateMachine) : base(stateMachine) { }
    private readonly int FallHash = Animator.StringToHash("Fall2");

    private Vector3 momentum;

    private const float CrossFadeDuration = 0.1f;
    public override void Enter()
    {
        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f;

        stateMachine.Animator.CrossFadeInFixedTime(FallHash, CrossFadeDuration);

        stateMachine.LedgeDetector.OnLedgeDetect += HandleLedgeDetect;
        //stateMachine.InputRead.JumpEvent += OnJump;
    }



    public override void Tick(float deltaTime)
    {
        Move(momentum, deltaTime);

        if(stateMachine.Controller.isGrounded)
        {
            ReturnToLocomotion();
        }

        FaceTarget();

    }

    public override void Exit()
    {
        stateMachine.LedgeDetector.OnLedgeDetect -= HandleLedgeDetect;
        //stateMachine.InputRead.JumpEvent -= OnJump;
    }

    private void HandleLedgeDetect(Vector3 ledgeForward, Vector3 closestPoint)
    {
        stateMachine.SwitchState(new PlayerHangingState(stateMachine, ledgeForward, closestPoint));
    }

   /* private void OnJump()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }*/
}
