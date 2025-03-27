using UnityEngine;

public class Target : MonoBehaviour
{
    private EnemyBase enemy;

    private void Start()
    {
        enemy = GetComponent<EnemyBase>();
    }

    public void TakeDamage(float damage)
    {
        enemy.currentHealth -= damage;

        if (enemy.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }


}
