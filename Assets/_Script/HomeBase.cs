using UnityEngine;

public class HomeBase : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        Debug.Log("Base is destroyed D:");
        Destroy(this.gameObject);
    }
}
