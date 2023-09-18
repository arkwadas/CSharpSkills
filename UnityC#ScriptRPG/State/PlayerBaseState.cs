using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerState stateMachine;

    public PlayerBaseState(PlayerState stateMachine)
    {
        this.stateMachine = stateMachine;
    }
}
