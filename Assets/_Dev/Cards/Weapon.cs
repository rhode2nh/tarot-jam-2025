using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    public Action Attack;
    
    [field: SerializeField] public WeaponData WeaponData { get; private set; }
    [SerializeField] private float _fireRate;

    private FPSActions _fpsActions;
    
    private bool _isFiring;
    private bool _isPressed;

    private void Awake()
    {
        _fpsActions = InputManager.Instance.FPSActions;
    }

    private void OnEnable()
    {
        _fpsActions.Player.Attack.performed += OnAttack;
        _fpsActions.Player.Attack.Enable();
    }

    private void OnDisable()
    {
        _fpsActions.Player.Attack.performed -= OnAttack;
        _fpsActions.Player.Attack.Disable();
    }

    private void Update()
    {
        if (!_isPressed || _isFiring) return;
        
        StartCoroutine(Fire());
    }

    private void OnAttack(InputAction.CallbackContext ctx)
    {
        _isPressed = Math.Abs(ctx.ReadValue<float>() - 1.0f) < 0.001f;
    }

    private IEnumerator Fire()
    {
        _isFiring = true;
        Attack?.Invoke();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, float.MaxValue, 1, QueryTriggerInteraction.Ignore))
        {
            if (hit.transform.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(10f);
            }
        }
        Debug.Log(PlayerManager.Instance.CalculatedFireRate());
        yield return new WaitForSeconds(PlayerManager.Instance.CalculatedFireRate());
        _isFiring = false;
    }
}
