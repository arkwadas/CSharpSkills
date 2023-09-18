using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFreeLookState : PlayerBaseState
{
    private Vector2 rollDirectionInput;
    private float remainingRollTime;

    private readonly int FreeLookBlendTreeHash = Animator.StringToHash("FreeLookBlendTree");
    private readonly int FreeLookSpeedHash = Animator.StringToHash("FreeLookSpeed");

    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;

    private bool shouldFade;

    public PlayerFreeLookState(PlayerStateMachine stateMachine , bool shouldFade = true) : base(stateMachine) 
    { 
        this.shouldFade = shouldFade;
    }

    public override void Enter()
    {
        stateMachine.InputRead.TargetEvent += OnTarget;
        

        stateMachine.InputRead.RollEvent += OnRoll; //próba dodania uniku do stanu freelookstate
        stateMachine.InputRead.JumpEvent += OnJump;

        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0f);

        if(shouldFade)
        {
            stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTreeHash, CrossFadeDuration);
        }
        else
        {
            stateMachine.Animator.Play(FreeLookBlendTreeHash);
        }
        


    }

    public override void Tick(float deltaTime)
    {
        
        if (stateMachine.InputRead.IsAttacking)
        {
            stateMachine.SwitchState(new PlayerAttackingState(stateMachine, 0));
            return;
        }
        if (stateMachine.InputRead.IsBlocking)
        {
            stateMachine.SwitchState(new PlayerBlockingState(stateMachine));
            return;
        }

        Vector3 movment = CalculateMovement(deltaTime);
        //Vector3 rol = RollZ(deltaTime);
        //Move(rol * stateMachine.FreeLookMovmentSpeed, deltaTime);
        Move(movment * stateMachine.FreeLookMovmentSpeed, deltaTime);


        if (stateMachine.InputRead.MovementValue == Vector2.zero)
        {
            stateMachine.Animator.SetFloat(FreeLookSpeedHash, 0, AnimatorDampTime, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat(FreeLookSpeedHash, 1, AnimatorDampTime, deltaTime);
        
        FaceMovementDirection(movment, deltaTime);
       

    }

    

    public override void Exit()
    {
        stateMachine.InputRead.TargetEvent -= OnTarget;
        stateMachine.InputRead.RollEvent -= OnRoll;
        stateMachine.InputRead.JumpEvent -= OnJump;
    }
    private void OnJump()
    {
        stateMachine.SwitchState(new PlayerJumpingState(stateMachine));
    }
    private void OnRoll()
    {
        if(stateMachine.InputRead.MovementValue == Vector2.zero) { return; }

        stateMachine.SwitchState(new PlayerRollFreeState(stateMachine, stateMachine.InputRead.MovementValue));
        /*if (Time.time - stateMachine.PreviusDodgeTime < stateMachine.DodgeCooldown) { return; }


    stateMachine.SetDodgeTime(Time.time);
    rollDirectionInput = stateMachine.InputRead.MovementValue;
    remainingRollTime = stateMachine.RolDuration;

    stateMachine.Animator.CrossFadeInFixedTime(RollHash, CrossFadeDuration);
    stateMachine.Health.SetInvunerable(true);*/





    }

    private void OnTarget()
    {
        if (!stateMachine.Targeter.SelectTarget()) { return; }

        stateMachine.SwitchState(new PlayerTargetingState(stateMachine));

    }


    private Vector3 CalculateMovement(float deltaTime)
    {
        Vector3 forward = stateMachine.MainCameraTransform.forward;
        Vector3 right = stateMachine.MainCameraTransform.right;

        

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * stateMachine.InputRead.MovementValue.y +
            right * stateMachine.InputRead.MovementValue.x;

    }
        private Vector3 RollZ (float deltaTime)
    {
        Vector3 rol = new Vector3();

        if (remainingRollTime > 0f)
        {
            //rol += stateMachine.transform.right * rollDirectionInput.x * stateMachine.RolLength / stateMachine.RolDuration;
            rol += stateMachine.transform.forward * rollDirectionInput.magnitude * stateMachine.RolLength / stateMachine.RolDuration;
            


            remainingRollTime = Mathf.Max(remainingRollTime - deltaTime, 0f); // w ifie jest zawarta logika dodge / roll

        }
        
       /* else
        {
            rol += stateMachine.transform.right * stateMachine.InputRead.MovementValue.x;
            rol += stateMachine.transform.forward * stateMachine.InputRead.MovementValue.y;
        }*/


        return rol;
    }
    
   

    private void FaceMovementDirection(Vector3 movment, float deltaTime)
    {
        stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            Quaternion.LookRotation(movment),
            deltaTime * stateMachine.RotationSmoothValue); // kod do rotacji, wy³¹czenie go sprawi ¿e nie bêdzie
        // smoofe ratacji, za to animacje stan¹ sie statyczne, bez potrzeby obrotu ca³ej postaci po w³¹snej osi
    }
    
}

