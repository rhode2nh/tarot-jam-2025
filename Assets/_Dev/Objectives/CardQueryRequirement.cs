using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CardQueryRequirement", menuName = "Quests/Requirements/Card Query Requirement")]
public class CardQueryRequirement : RequirementData
{
    [field: SerializeField] public int Count { get; private set; }
    [field: SerializeField] public CardColor CardColor { get; private set; }
    [field: SerializeField] public CardType CardType { get; private set; }

    public override bool IsCompleted()
    {
        var cardTypes = CardManager.Instance.GetCards();
        var cardColors = CardManager.Instance.GetCards();

        if (CardType != CardType.ANY)
        {
            cardTypes = cardTypes.Where(x => x.data.CardType == CardType).ToList();
        }
        
        if (CardColor != CardColor.ANY)
        {
            cardColors = cardColors.Where(x => x.data.CardColor == CardColor).ToList();
        }
        
        return cardTypes.Intersect(cardColors).Count() >= Count;
    }
}
