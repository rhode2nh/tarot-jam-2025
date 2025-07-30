using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PointerRaycaster : MonoBehaviour
{
    private GameObject currentHovered;
    private FPSActions _fpsActions;

    private void Awake()
    {
        _fpsActions = InputManager.Instance.FPSActions;
    }

    private void OnEnable()
    {
        _fpsActions.CardSelector.SelectCard.performed += OnClick;
        _fpsActions.CardSelector.SelectCard.Enable();
    }

    private void OnClick(InputAction.CallbackContext ctx)
    {
        if (currentHovered == null) return;
        
        currentHovered.GetComponent<IHoverInteractable>()?.OnPointerClick();
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject hitObject = null;

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hitObject = hit.collider.gameObject;

            if (hitObject != currentHovered)
            {
                if (currentHovered != null)
                {
                    currentHovered.GetComponent<IHoverInteractable>()?.OnPointerExit();
                }

                currentHovered = hitObject;
                currentHovered.GetComponent<IHoverInteractable>()?.OnPointerEnter();
            }

        }
        else
        {
            if (currentHovered != null)
            {
                currentHovered.GetComponent<IHoverInteractable>()?.OnPointerExit();
                currentHovered = null;
            }
        }
    }
}
