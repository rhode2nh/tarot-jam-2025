using System;
using UnityEngine;

public class TelePos : MonoBehaviour
{
    [SerializeField] private float _rayLength;
    [SerializeField] private LayerMask _hitMask;

    [SerializeField] private Throwable _currentThrowable;
    
    private void Update()
    {
        if (_currentThrowable != null)
        {
            _currentThrowable.UpdatePosition(transform.position + transform.forward * _rayLength);
        }

    }

    public void Grab()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out var raycastHit, _hitMask))
        {
            if (raycastHit.transform.gameObject.TryGetComponent<Throwable>(out var throwable))
            {
                _currentThrowable = throwable;
                _currentThrowable.PickUp();
            }
        }
    }

    public void Release()
    {
        if (!_currentThrowable) return;
     
        _currentThrowable.Release();
        _currentThrowable = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Debug.DrawRay(transform.position, transform.forward * _rayLength, Color.green);
    }
}
