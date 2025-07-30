using System;
using System.Collections.Generic;
using UnityEngine;
using Wannabuh.FPSController;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private List<Ability> _abilities;
    [SerializeField] private FPSController _fpsController;
    [SerializeField] public TelePos _telePos;

    public static AbilityManager Instance;
    
    private List<Ability> _activeAbilties = new();

    private void Awake()
    {
        Instance = this;
    }
    
    private void Start()
    {
        foreach (var ability in _abilities)
        {
            ability.Initialize(gameObject);
            UnlockAbility(ability);
        }
    }

    public void UnlockAbility(Ability ability)
    {
        if (_activeAbilties.Contains(ability) && !ability.Stackable) return;
        
        _activeAbilties.Add(ability);
        
        if (ability.activationMap == null) return;
        var action = ability.activationMap.action;
        action.performed += ctx => ability.Activate(ctx, _fpsController.gameObject);
        action.Enable();
    }
}
