using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Telekinesis", menuName = "Abilities/Telekinesis")]
public class Telekinesis : Ability
{
    public override void Activate(InputAction.CallbackContext ctx, GameObject player)
    {
        if (PlayerManager.Instance.Mana < ManaCost) return;
        var isPressed = Math.Abs(ctx.ReadValue<float>() - 1.0f) < 0.01f;
        var abilityManager = AbilityManager.Instance;
        if (abilityManager == null) return;
        
        if (isPressed)
        {
            abilityManager._telePos.Grab();
        }
        else
        {
            abilityManager._telePos.Release();
        }
    }
}
