using UnityEngine;

public class Target : MonoBehaviour
{
    private EnemyBase enemy;
    private Manager Manager;
    private CurrencyManager currencyManager;

    private void Start()
    {
        enemy = GetComponent<EnemyBase>();
        Manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        currencyManager = Manager.currencyManager;
        
    }

    public void TakeDamage(float physicalDamage, float elementalDamage)
    {
        // Reducer skade baseret p� enemy resistans
        float physicalDamageReduction = enemy.physicalResistance / 100;
        float reducedPhysicalDamage = physicalDamage * (1 - physicalDamageReduction);

        float elementalDamageReduction = enemy.elementalResistance / 100;
        float reducedElementalDamage = elementalDamage * (1 - elementalDamageReduction);

        float totalDamage = reducedPhysicalDamage + reducedElementalDamage;

        enemy.currentHealth -= totalDamage;
        enemy.healthBar.SetCurrentHealth(Mathf.FloorToInt(enemy.currentHealth));

        if (enemy.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        currencyManager.GetMoney(enemy.bounty);
        Destroy(this.gameObject);
    }


}
