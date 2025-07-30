using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // === GENERAL DATA ===
    [field: SerializeField] public float Health { get; private set; }
    [field: SerializeField] public float MaxHealth { get; private set; }
    [field: SerializeField] public float MaxMana { get; private set; }
    [field: SerializeField] public float Mana { get; private set; }
    [field: SerializeField] public float Damage { get; set; }
    
    // === WEAPON DATA ==
    [field: SerializeField] public Weapon CurrentWeapon { get; set; }
    [field: SerializeField] public float FireRateMultiplier { get; private set; } = 1.0f;

    public static PlayerManager Instance;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Heal(float amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
    }

    public void ReplenishMana(float amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, MaxHealth);
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        
    }

    public void UseMana(float amount)
    {
        if (amount > Mana) return;
        
        Mana -= amount;
    }

    public void ApplyWeaponStats(float fireRateMultiplier)
    {
        FireRateMultiplier += fireRateMultiplier;
        if (FireRateMultiplier <= 0.0f)
        {
            FireRateMultiplier = 1.0f;
        }
    }

    public float CalculatedFireRate()
    {
        return CurrentWeapon.WeaponData.fireRate / FireRateMultiplier;
    }
}
