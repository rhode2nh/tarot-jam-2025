using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public CinemachineBrain Brain;

    private void Awake()
    {
        Instance = this;
        Brain = GetComponent<CinemachineBrain>();
    }
}
