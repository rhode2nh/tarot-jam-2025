using System;
using Animancer;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAnimator : MonoBehaviour
{
    [SerializeField] private AnimationClip _idle;
    [SerializeField] private AnimationClip _left;
    [SerializeField] private AnimationClip _right;
    [SerializeField] private AnimationClip _up;
    [SerializeField] private AnimationClip _down;
    [SerializeField] private AnimationClip _walk;
    [SerializeField] private AnimationClip _shoot;
    [SerializeField] private float _blendSpeed;
    
    private AnimancerComponent _animancer;
    private FPSActions _fpsActions;
    private Weapon _weaponController;

    private AnimancerState _idleState;
    private AnimancerState _stateLeft;
    private AnimancerState _stateRight;
    private AnimancerState _stateUp;
    private AnimancerState _stateDown;

    private AnimancerState _walkState;
    private AnimancerState _shootState;

    private bool _isMoving;

    private void Awake()
    {
        _animancer = GetComponent<AnimancerComponent>();
        _fpsActions = InputManager.Instance.FPSActions;
        _weaponController = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        _fpsActions.Player.Move.performed += OnMove;
        _weaponController.Attack += OnAttack;
    }
    
    private void OnDisable()
    {
        _fpsActions.Player.Move.performed -= OnMove;
    }

    void Start()
    {
        _animancer.Layers[0].Weight = 1f;
        _animancer.Layers[1].IsAdditive = true;
        _animancer.Layers[2].IsAdditive = true;

        _idleState = _animancer.Play(_idle);
        _stateLeft = _animancer.Play(_left);
        _stateRight = _animancer.Play(_right);
        _stateUp = _animancer.Play(_up);
        _stateDown = _animancer.Play(_down);

        _walkState = _animancer.Play(_walk);
        _shootState = _animancer.Play(_shoot);
        _shootState.Weight = 1.0f;
        _shootState.LayerIndex = 2;
        
        _idleState.IsPlaying = true;
        _stateLeft.IsPlaying = true;
        _stateRight.IsPlaying = true;
        _stateUp.IsPlaying = true;
        _stateDown.IsPlaying = true;

        _walkState.IsPlaying = false;
        _walkState.IsPlaying = false;

        _stateLeft.LayerIndex = 1;
        _stateRight.LayerIndex = 1;
        _stateUp.LayerIndex = 1;
        _stateDown.LayerIndex = 1;
    }

    private void OnAnimationEnd()
    {
        _animancer.Layers[2].Stop();
        Debug.Log("Ended");
    }

    // Update is called once per frame
    void Update()
    {
        // === MOVEMENT ===
        if (_isMoving)
        {
            if (_animancer.Layers[0].CurrentState != _walkState)
            {
                _animancer.Layers[0].Play(_walkState, 0.2f);
            }
        }
        else
        {
            if (_animancer.Layers[0].CurrentState != _idleState)
            {
                _animancer.Layers[0].Play(_idleState, 0.2f);
            }
        }
        
        // === SWAY ===
        float mouseX = _fpsActions.Player.Look.ReadValue<Vector2>()[0];
        float mouseY = _fpsActions.Player.Look.ReadValue<Vector2>()[1];
        
        float targetSway = Mathf.Clamp01(Mathf.Abs(mouseX) + Mathf.Abs(mouseY));
        _animancer.Layers[1].Weight = Mathf.Lerp(_animancer.Layers[1].Weight, targetSway, Time.deltaTime * _blendSpeed);

        _stateLeft.Weight = Mathf.Lerp(_stateLeft.Weight, Mathf.Clamp01(-mouseX), Time.deltaTime * _blendSpeed);
        _stateRight.Weight = Mathf.Lerp(_stateRight.Weight, Mathf.Clamp01(mouseX), Time.deltaTime * _blendSpeed);
        _stateUp.Weight = Mathf.Lerp(_stateUp.Weight, Mathf.Clamp01(-mouseY), Time.deltaTime * _blendSpeed);
        _stateDown.Weight = Mathf.Lerp(_stateDown.Weight, Mathf.Clamp01(mouseY), Time.deltaTime * _blendSpeed);
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        Vector2 move = ctx.ReadValue<Vector2>();
        _isMoving = MathF.Abs(move.y) != 0.0f;
    }

    private void OnAttack()
    {
        _animancer.Layers[2].Stop();
        _animancer.Layers[2].Play(_shootState, 0.2f);
        _shootState.Speed = 2.0f;
        _shootState.Events(this).OnEnd ??= OnAnimationEnd;
    }
}
