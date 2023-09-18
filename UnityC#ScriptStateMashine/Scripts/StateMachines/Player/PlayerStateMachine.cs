using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    // W PlayerStateMachine dodajemy stany maszyny i ich zmiany np.
    // metoda otrzymania obra¿eñ, zmieniamy stan 


    // krok pierwszy dodaj tutaj kod
    // krok drugi.... przeciagnij kod np Inpud Read do Input Read w playerze 
    // jest to koncepcja state Machine
    [field: SerializeField] public InputRead InputRead { get; private set; }
    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public Animator Animator { get; private set; }
    [field: SerializeField] public Targeter Targeter { get; private set; }
    [field: SerializeField] public ForceReceiver ForceReceiver { get; private set; }
    [field: SerializeField] public WaeponDamage Weapon { get; private set; }
    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public Ragdoll Ragdoll { get; private set; }
    [field: SerializeField] public LedgeDetection LedgeDetector { get; private set; }
    [field: SerializeField] public float FreeLookMovmentSpeed { get; private set; }
    [field: SerializeField] public float TargetingMovmentSpeed { get; private set; }
    [field: SerializeField] public float RotationSmoothValue { get; private set; }
    [field: SerializeField] public float RolDuration { get; private set; } // odpowiednik dodge
    [field: SerializeField] public float RolLength { get; private set; }
    //[field: SerializeField] public float DodgeCooldown { get; private set; } // do rola
    [field: SerializeField] public float JumpForce { get; private set; }
    [field: SerializeField] public Attack[] Attacks { get; private set; }

    public float PreviusDodgeTime { get; private set; } = Mathf.NegativeInfinity; //do cooldownu

    public Transform MainCameraTransform { get; private set; }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        MainCameraTransform = Camera.main.transform;

        SwitchState(new PlayerFreeLookState(this));
    }
    private void OnEnable()
    {
        Health.OnTakeDamage += HandleTakeDamage;
        Health.OnDie += HandleDie;
    }
    private void OnDisable()
    {
        Health.OnTakeDamage -= HandleTakeDamage;
        Health.OnDie -= HandleDie;
    }

    private void HandleTakeDamage()
    {
        SwitchState(new PlayerImpactState(this));
    }
    private void HandleDie()
    {
        SwitchState(new PlayerDeadState(this));
    }
    /*public void SetDodgeTime(float dodgeTime)
    {
        PreviusDodgeTime = dodgeTime;
    }*/
}

