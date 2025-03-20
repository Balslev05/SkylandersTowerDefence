using System.ComponentModel;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    public int range;
    public int damage;
    public int fireRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void FindEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                SetTarget(colliders[0].transform);
            }
        }
    }

    private void SetTarget(Transform target)
    {

    }
}
