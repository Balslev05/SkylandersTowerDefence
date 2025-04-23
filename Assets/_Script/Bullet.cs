using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector] public float physicalDamage;
    [HideInInspector] public float elementalDamage;
    [HideInInspector] public float bulletSpeed = 0;
    public bool destroyOnHit = false;
    private Vector2 moveDirection;
    

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void FixedUpdate()
    {
        transform.Translate(moveDirection * bulletSpeed, Space.World);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Target>().TakeDamage(physicalDamage, elementalDamage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }

}
