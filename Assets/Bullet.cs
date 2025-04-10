using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float bulletSpeed = 0;
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
            Debug.Log("Hit");
            collision.GetComponent<Target>().TakeDamage(damage, damage);
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }

        }
    }

}
