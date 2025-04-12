using UnityEngine;
using DG.Tweening;

public class Flames : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Target>().TakeDamage(0.0005f, 1);
            Debug.Log("BURN!!!");
        }
    }
}
