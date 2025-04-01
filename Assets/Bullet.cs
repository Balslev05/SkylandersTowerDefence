using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Hit");
            collision.GetComponent<Target>().TakeDamage(damage);

        }
    }

}
