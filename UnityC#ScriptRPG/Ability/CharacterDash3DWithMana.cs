using MoreMountains.Tools;
using MoreMountains.TopDownEngine;
using RPG.Combat;
using RPG.Stats;
using System.Collections;
using UnityEngine;

public class CharacterDash3DWithMana : CharacterDash3D
{
    [Header("Mana")]
    public Mana manaScript;
    public float manaCost;

    protected override void HandleInput()
    {
        base.HandleInput();
        if (!AbilityAuthorized
            || (!Cooldown.Ready())
            || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal))
        {
            return;
        }

        if (!AllowDashWhenJumping && (_movement.CurrentState == CharacterStates.MovementStates.Jumping))
        {
            return;
        }

        if (_inputManager.DashButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
        {
            if (manaScript.UseMana(manaCost))
            {
                DashStart();
                return;
            }
        }

    }
}
