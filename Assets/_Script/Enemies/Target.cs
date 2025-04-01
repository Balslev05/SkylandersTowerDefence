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

    public void TakeDamage(float damage)
    {
        enemy.currentHealth -= damage;
        enemy.healthBar.SetCurrentHealth(Mathf.FloorToInt(enemy.currentHealth));


        if (enemy.currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        currencyManager.GetMoney(enemy.currencyValue);
        //currencyManager.currency += enemy.currencyValue;
        Destroy(this.gameObject);
    }


}
