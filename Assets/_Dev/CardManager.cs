using System;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;
    [SerializeField] private List<Card> _cards = new();

    private void Awake()
    {
        Instance = this;
    }

    public void AddCard(TarotCardData card)
    {
        _cards.Add(new Card(card));
    }

    public List<Card> GetCards()
    {
        return _cards;
    }
}
