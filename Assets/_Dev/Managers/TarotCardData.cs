using UnityEngine;

[CreateAssetMenu(fileName = "TarotCardData", menuName = "Tarot Cards/TarotCardData")]
public class TarotCardData : ScriptableObject
{
    [SerializeReference] public CardContent Content;
    [SerializeField] public CardColor CardColor;
    [SerializeField] public CardType CardType;
}

public enum CardColor {
    ANY,
    RED,
    BLUE,
    GREEN,
    GOLD,
}

public enum CardType
{
    ANY,
    WEAPON,
    ABILITY,
    EFFECT,
    ENEMY,
}
