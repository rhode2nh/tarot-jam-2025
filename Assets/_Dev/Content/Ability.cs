using UnityEngine;
using UnityEngine.InputSystem;
using Wannabuh.FPSController;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public InputActionReference activationMap;
    
    public virtual void Initialize(GameObject player) {}
    public abstract void Activate(InputAction.CallbackContext ctx, GameObject player);
    public virtual void Deactivate(GameObject player) {}
}
