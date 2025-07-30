using System;
using UnityEngine;
using Wannabuh.FPSController;

public class Enemy : MonoBehaviour, IHittable
{
    [SerializeField] private EnemyData _enemyData;
    private EnemySpawn _enemySpawn;
    
    public LineOfSight _lineOfSight;
    
    private float _health;

    private void Awake()
    {
        _lineOfSight = GetComponentInChildren<LineOfSight>();
        _health = _enemyData.Health;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Hit(Player player)
    {
        player.TakeDamage(_enemyData.Damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
