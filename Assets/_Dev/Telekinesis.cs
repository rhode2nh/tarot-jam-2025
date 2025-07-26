using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "Telekinesis", menuName = "Abilities/Telekinesis")]
public class Telekinesis : Ability
{
    public override void Activate(InputAction.CallbackContext ctx, GameObject player)
    {
        var isPressed = Math.Abs(ctx.ReadValue<float>() - 1.0f) < 0.01f ? true : false;
        // var abilityManager = player.GetComponent<AbilityManager>();
        var abilityManager = AbilityManager.Instance;
        if (abilityManager != null)
        {
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
}
