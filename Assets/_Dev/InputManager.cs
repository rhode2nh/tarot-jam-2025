using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public FPSActions FPSActions;

    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
        FPSActions = new FPSActions();
    }
}
