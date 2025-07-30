using UnityEngine;

[CreateAssetMenu(fileName = "WeaponEffect", menuName = "Card Effects/Weapon")]
public class WeaponEffectData : EffectData
{
    [field: SerializeField] public float FireRateMultiplier { get; private set; }
    
    public override void Realize(GameObject player)
    {
        PlayerManager.Instance.ApplyWeaponStats(FireRateMultiplier);
    }
}
