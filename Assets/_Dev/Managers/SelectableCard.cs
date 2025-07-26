using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [NonSerialized] private Card card = null;
    private CardSelector _cardSelector;

    private void Awake()
    {
        _cardSelector = GetComponentInParent<CardSelector>();
    }

    public void SetCard(Card card)
    {
        this.card = card;
    }

    public void ClearCard()
    {
        card = null;
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (card == null)
        {
            Debug.Log("Card Not Present");
            return;
        }
        
        if (!card.isRevealed)
        {
            Debug.Log("Hovering over Tarot Card (Unrevealed)");
            return;
        }
        
        Debug.Log("Hovering over " + card.data.name);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer is out " + gameObject.name);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (card == null)
        {
            Debug.Log("Card Not Present");
            return;
        }
        
        if (!_cardSelector.CardsReadyToReveal()) return;
        
        Debug.Log("Card Revealed: " + card?.data.name);
        card.isRevealed = true;
        card.isApplied = true;
        _cardSelector.TriggerReveal();
    }
}
