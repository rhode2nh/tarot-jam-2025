using UnityEngine;

[CreateAssetMenu(fileName = "TarotCardData", menuName = "Tarot Cards/TarotCardData")]
public class TarotCardData : ScriptableObject
{
    [SerializeReference] public CardContent Content;
    [SerializeField] public CardColor CardColor;
    [SerializeField] public CardType CardType;
}

public enum CardColor {
    RED,
    BLUE,
    GREEN,
}

public enum CardType
{
    WEAPON,
    ABILITY,
    EFFECT,
    ENEMY,
}
