using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void PickUp()
    {
        _rb.isKinematic = true;
    }

    public void Throw(Vector3 direction, float force)
    {
        _rb.isKinematic = false;
        _rb.AddForce(direction * force, ForceMode.Impulse);
    }

    public void Release()
    {
        _rb.isKinematic = false;
    }

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }
}
