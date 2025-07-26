using UnityEngine;

[CreateAssetMenu(fileName = "ItemRequirement", menuName = "Quests/New Card Requirement")]
public class CardRequirement : RequirementData
{
    [SerializeField] private TarotCardData _cardData;
    
    public override bool IsCompleted()
    {
        return false;
    }
}
