using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public InputActionReference activationMap;
    public bool Stackable;
    [field: SerializeField] public float ManaCost { get; private set; }
    
    public virtual void Initialize(GameObject player) {}
    public abstract void Activate(InputAction.CallbackContext ctx, GameObject player);
    public virtual void Deactivate(GameObject player) {}
}
