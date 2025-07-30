using System;
using System.Collections;
using UnityEngine;
using Wannabuh.FPSController;

public class LineOfSight : MonoBehaviour
{
    [field: SerializeField] public bool IsPlayerInTrigger { get; private set; }
    
    [SerializeField] private float _distanceToHit;
    [SerializeField] private float _attackInterval = 1.0f;
    
    public MoveTowards _moveTowards;
    private Player _player;
    private Coroutine _attackCoroutine;

    private void Awake()
    {
        _moveTowards = GetComponentInParent<MoveTowards>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent(out Player player)) return;

        IsPlayerInTrigger = true;
        _player = player;
        _moveTowards.target = player.gameObject.transform;
        _attackCoroutine = StartCoroutine(Attack());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<Player>(out var player)) return;
        
        StopCoroutine(_attackCoroutine);
        IsPlayerInTrigger = false;
        _player = null;
        _moveTowards.target = _moveTowards.initialTarget;
        Debug.Log("Player out of Trigger!");
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (Vector3.Distance(_player.transform.position, transform.position) <= _distanceToHit)
            {
                Debug.Log("Hit player");
                _player.TakeDamage(10f);
            }
            
            yield return new WaitForSeconds(_attackInterval);
        }
    }
}
