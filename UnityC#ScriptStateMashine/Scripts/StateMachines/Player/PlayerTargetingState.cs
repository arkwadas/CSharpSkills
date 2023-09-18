using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTargetingState : PlayerBaseState
{
    //private Vector2 rollDirectionInput;
    //private float remainingRollTime;

    private readonly int TargetingBlendTreeHash = Animator.StringToHash("TargetingBlendTree");
    private readonly int TargetingForwardHash = Animator.StringToHash("TargetingForward");
    private readonly int TargetingRightHash = Animator.StringToHash("TargetingRight");
    private const float CrossFadeDuration = 0.1f;
    public PlayerTargetingState(PlayerStateMachine stateMachine) : base(stateMachine) { }


    public override void Enter()
    {
        stateMachine.InputRead.TargetEvent += OnTarget;
        

        stateMachine.Animator.CrossFadeInFixedTime(TargetingBlendTreeHash, CrossFadeDuration);
        stateMachine.InputRead.JumpEvent += OnJump;
        stateMachine.InputRead.RollEvent += OnRoll; // stan maszyny przy robirniu dodge

    }



    public override void Tick(float deltaTime)
    {
        if(stateMachine.InputRead.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }
        if(stateMachine.InputRead.IsBlocking)
        {
            stateMachine.SwitchState(new PlayerBlockingState(stateMachine));
            return;
        }

        if(stateMachine.Targeter.CurrentTarget == null)
        {
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }

        Vector3 movement = CalculateMovement(deltaTime);

        Move(movement * stateMachine.TargetingMovmentSpeed, deltaTime);
        UpdateAnimator(deltaTime);
        FaceTarget();
    }

    public override void Exit()
    {
        stateMachine.InputRead.TargetEvent -= OnTarget;
        stateMachine.InputRead.RollEvent -= OnRoll; // wyjscie z tego
        stateMachine.InputRead.JumpEvent -= OnJump;
    }
    private void OnTarget()
    {
        stateMachine.Targeter.Cancel();

        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }
    private Vector3 CalculateMovement(float deltaTime)
    {
        Vector3 movement = new Vector3();

        
            movement += stateMachine.transform.right * stateMachine.InputRead.MovementValue.x;
            movement += stateMachine.transform.forward * stateMachine.InputRead.MovementValue.y;
        


        return movement;


        //OD DODGE stare
        /* if(remainingRollTime > 0f)
         {
             movement += stateMachine.transform.right * rollDirectionInput.x * stateMachine.RolLength / stateMachine.RolDuration;
             movement += stateMachine.transform.forward * rollDirectionInput.y * stateMachine.RolLength / stateMachine.RolDuration;

             remainingRollTime = Mathf.Max(remainingRollTime - deltaTime, 0f); // w ifie jest zawarta logika dodge / roll

         }
         else
         {
             movement += stateMachine.transform.right * stateMachine.InputRead.MovementValue.x;
             movement += stateMachine.transform.forward * stateMachine.InputRead.MovementValue.y;
         }


         return movement;*/
    }
    private void UpdateAnimator(float deltaTime)
    {
        if (stateMachine.InputRead.MovementValue.y == 0)
        {
            stateMachine.Animator.SetFloat(TargetingForwardHash, 0, 0.1f, deltaTime);
        }
        else
        {
            float value = stateMachine.InputRead.MovementValue.y > 0 ? 1f : -1f;
            stateMachine.Animator.SetFloat(TargetingForwardHash, value, 0.1f, deltaTime);
        }

        if (stateMachine.InputRead.MovementValue.x == 0)
        {
            stateMachine.Animator.SetFloat(TargetingRightHash, 0, 0.1f, deltaTime);
        }
        else
        {
            float value = stateMachine.InputRead.MovementValue.x > 0 ? 1f : -1f;
            stateMachine.Animator.SetFloat(TargetingRightHash, value, 0.1f, deltaTime);
        }
    }
    private void OnRoll()
    {
        if (stateMachine.InputRead.MovementValue == Vector2.zero) { return; };
        stateMachine.SwitchState(new PlayerDodgingState(stateMachine, stateMachine.InputRead.MovementValue));

        /*if(Time.time - stateMachine.PreviusDodgeTime < stateMachine.DodgeCooldown) { return; }

        stateMachine.SetDodgeTime(Time.time);
        rollDirectionInput = stateMachine.InputRead.MovementValue;
        remainingRollTime = stateMachine.RolDuration;*/
    }

    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }
}
