using UnityEngine;

public class HomeBase : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    public float currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetCurrentHealth(Mathf.FloorToInt(currentHealth));

        if (currentHealth <= 0) { Die(); }
    }

    public void Die()
    {
        Debug.Log("Base is destroyed D:");
        Destroy(this.gameObject);
    }
}
