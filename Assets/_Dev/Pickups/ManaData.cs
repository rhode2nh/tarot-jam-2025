using UnityEngine;

[CreateAssetMenu(fileName = "PickupData", menuName = "Pickups/ItemPickupData")]
public class ItemPickupData : ScriptableObject
{
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float Mana { get; private set; }

    public void Apply()
    {
        PlayerManager.Instance.Heal(Health);
        PlayerManager.Instance.ReplenishMana(Mana);
    }
}
