using UnityEngine;

[CreateAssetMenu(fileName = "DamageMultiplier", menuName = "Card Effects/Damage Multiplier")]
public class DamageMultiplier : CardContent
{
    public float damageMultiplier = 1f;
    
    public override void Realize(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
