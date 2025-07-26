using UnityEngine;
using UnityEngine.InputSystem;
using Wannabuh.FPSController;

[CreateAssetMenu(fileName = "Jump", menuName = "Abilities/Jump")]
public class Jump : Ability
{
    public int jumps;
    
    public override void Activate(InputAction.CallbackContext ctx, GameObject player)
    {
        if (player.TryGetComponent<FPSController>(out var fpsController))
        {
            fpsController.SetExtraJumps(jumps);
        }
    }
}
