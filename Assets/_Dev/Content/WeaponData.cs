using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Card Content/Weapon")]
public class WeaponData : CardContent
{
    [SerializeField] public float fireRate;
    [SerializeField] public float damage;
    [SerializeField] public GameObject weapon;
    
    public override void Realize(GameObject player)
    {
        throw new System.NotImplementedException();
    }
}
