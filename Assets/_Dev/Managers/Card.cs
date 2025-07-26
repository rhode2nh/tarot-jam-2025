using UnityEngine;

[System.Serializable]
public class Card
{
    public bool isRevealed;
    public bool isApplied;
    [SerializeField] public TarotCardData data;
    public Card(TarotCardData data)
    {
        this.data = data;
        isRevealed = false;
        isApplied = false;
    }

    public void Activate(GameObject player)
    {
        data.Content.Realize(player);
    }
}
