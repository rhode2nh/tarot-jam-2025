using System;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Start()
    {
        var enemy = Instantiate(_enemy, transform);
        enemy._lineOfSight._moveTowards.target = transform;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + new Vector3(0.0f, 0.5f, 0.0f), 0.5f);
    }
}
