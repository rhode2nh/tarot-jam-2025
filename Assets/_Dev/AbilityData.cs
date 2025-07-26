using UnityEngine;

[CreateAssetMenu(fileName = "AbilityData", menuName = "Card Content/Ability")]
public class AbilityData : CardContent
{
    [SerializeField] private Ability _ability;
    
    public override void Realize(GameObject player)
    {
        AbilityManager.Instance.UnlockAbility(_ability);
    }
}
