using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Wannabuh.FPSController;

public class Interact : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _hitMask;
    [SerializeField] private FPSController _fpsController;
    private FPSActions _fpsActions;
    private IInteractable _interactable;

    private void Awake()
    {
        _fpsActions = InputManager.Instance.FPSActions;
    }

    private void OnEnable()
    {
        _fpsActions.Player.Interact.performed += OnInteract;
        _fpsActions.Player.Interact.Enable();
    }
    
    private void OnDisable()
    {
        _fpsActions.Player.Interact.performed -= OnInteract;
        _fpsActions.Player.Interact.Disable();
    }
    
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (!Physics.Raycast(ray, out var raycastHit, _hitMask)) return;
        _interactable = raycastHit.transform.gameObject.TryGetComponent<IInteractable>(out var interactable) ? interactable : null;
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        _interactable?.Interact(_fpsController);
    }
}
