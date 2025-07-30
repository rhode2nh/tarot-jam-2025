using System;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    [SerializeField] private Transform _resetPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.transform.position = _resetPoint.transform.position;
        }
    }
}
