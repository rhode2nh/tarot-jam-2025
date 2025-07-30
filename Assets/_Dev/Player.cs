using UnityEngine;

public class Player : MonoBehaviour, IHittable
{
    public void TakeDamage(float damage)
    {
        PlayerManager.Instance.TakeDamage(damage);
        if (PlayerManager.Instance.Health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player is dead");
    }
}
