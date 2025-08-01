using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using Wannabuh.FPSController;

public class CardSelector : MonoBehaviour, IInteractable
{
    [SerializeField] private CinemachineCamera _cinemachineCamera;
    [SerializeField] public FPSController _fpsController;
    [SerializeField] private int revealThreshold;

    private FPSActions _fpsActions;
    private List<Card> _cards;
    private List<SelectableCard> _selectableCards = new();
    private bool revealTriggered;

    private void Awake()
    {
        _fpsActions = InputManager.Instance.FPSActions;
        _selectableCards = GetComponentsInChildren<SelectableCard>().ToList();
    }

    private void OnEnable()
    {
        _fpsActions.CardSelector.ExitCardSelect.performed += ExitCardSelect;
        // _fpsActions.CardSelector.ExitCardSelect.Enable();
    }

    private void OnDisable()
    {
        _fpsActions.CardSelector.ExitCardSelect.performed -= ExitCardSelect;
        _fpsActions.CardSelector.ExitCardSelect.Disable();
    }

    public void Interact(FPSController fpsController)
    {
        _fpsController = fpsController;
        _fpsActions.Player.Disable();
        _fpsActions.CardSelector.Enable();
        _cinemachineCamera.Priority = fpsController.Camera.Priority + 1;
        _cards = CardManager.Instance.GetCards();
        _cards = _cards.Where(x => !x.isRevealed).Take(3).ToList();
        Debug.Log(_cards.Count);
        UIManager.Instance.OpenCardPanel();
        for (int i = 0; i < _cards.Count; i++)
        {
            _selectableCards[i].SetCard(_cards[i]);
            Debug.Log(_cards[i].data.name);
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ExitCardSelect(InputAction.CallbackContext ctx)
    {
        UIManager.Instance.CloseCardPanel();
        _fpsActions.CardSelector.Disable();
        _fpsActions.Player.Enable();
        _cinemachineCamera.Priority = 1;

        foreach (var card in _cards)
        {
            if (!card.isRevealed) continue; 
            
            Debug.Log("Here");
            
            card.Activate(_fpsController.gameObject);
        }
        
        _cards = new List<Card>();
        foreach (var selectableCard in _selectableCards)
        {
            selectableCard.ClearCard();
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TriggerReveal()
    {
        revealTriggered = true;
    }

    public bool CardsReadyToReveal()
    {
        return true;
        // return _cards.Count(card => !card.isRevealed) >= revealThreshold || revealTriggered;
    }
}
