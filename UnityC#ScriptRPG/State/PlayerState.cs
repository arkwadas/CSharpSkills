using RPG.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : StateMachine
{
    [field: SerializeField] public Animator Animator { get; private set; }
}
