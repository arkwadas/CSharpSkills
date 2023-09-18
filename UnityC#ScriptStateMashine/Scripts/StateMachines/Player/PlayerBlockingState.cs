using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlockingState : PlayerBaseState
{
    public PlayerBlockingState(PlayerStateMachine stateMachine) : base(stateMachine){    }

    private readonly int BlockHash = Animator.StringToHash("Blocking");

    private const float CrossFadeDuration = 0.1f;

    public override void Enter()
    {
        stateMachine.Health.SetInvunerable(true); // zebby blokowac obrazenia i w exicie dajemy na false
        stateMachine.Animator.CrossFadeInFixedTime(BlockHash, CrossFadeDuration);
    }

    

    public override void Tick(float deltaTime)
    {
        Move(deltaTime);//nie pozwalamy sie poruszac poniewaz vestor3.zero

        //je�el nie odczytamy stanu maszyny w input Read
        //a dok��dnie is blocking to si� stanie...
        if (!stateMachine.InputRead.IsBlocking) 
        {
            stateMachine.SwitchState(new PlayerTargetingState(stateMachine));
            //to statemachin zmien na nowy stan maszyny player targetingstate w (staniemachiny)
            //czyli mozemy przeniesc ten stan na inny stan maszyny
            return;
        }
        /*if(stateMachine.Targeter.CurrentTarget == null) //je�elu z celem co� si� stanie - wynik r�wny zero to..
        {  
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            // ...to zmie� na stan playerfreelookstate
            return;
        }//*/
        
    }

    public override void Exit()
    {
        stateMachine.Health.SetInvunerable(false); //�eby zako�czy� tenstan bo on trwa
    }
}
