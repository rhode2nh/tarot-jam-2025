using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableCard : MonoBehaviour, IHoverInteractable
{
    [NonSerialized] private Card card;
    private CardSelector _cardSelector;
    [SerializeField] private CardAnimator _cardAnimator;

    private void Awake()
    {
        _cardSelector = GetComponentInParent<CardSelector>();
        _cardAnimator = GetComponentInChildren<CardAnimator>();
        _cardAnimator.gameObject.SetActive(false);
    }

    public void SetCard(Card card)
    {
        this.card = card;
        _cardAnimator.gameObject.SetActive(true);
    }

    public void ClearCard()
    {
        card = null;
        _cardAnimator.gameObject.SetActive(false);
    }
    
    public void OnPointerEnter()
    {
        if (card == null)
        {
            Debug.Log("Card Not Present");
            return;
        }
        
        _cardAnimator.Hover();
        if (!card.isRevealed)
        {
            Debug.Log("Hovering over Tarot Card (Unrevealed)");
            return;
        }
        
        Debug.Log("Hovering over " + card.data.name);
    }

    public void OnPointerExit()
    {
        if (card == null) return;
        
        _cardAnimator.Unhover();
    }

    public void OnPointerClick()
    {
        if (card == null)
        {
            Debug.Log("Card Not Present");
            return;
        }
        
        Debug.Log("Here");
        
        if (!_cardSelector.CardsReadyToReveal()) return;
        
        Debug.Log("Also Here");
        
        if (!card.isRevealed)
        {
            _cardAnimator.Flip();
        }
        
        Debug.Log("Card Revealed: " + card?.data.name);
        UIManager.Instance.SetCardName(card?.data.name);
        card.isRevealed = true;
        card.isApplied = true;
        _cardSelector.TriggerReveal();
    }
}
