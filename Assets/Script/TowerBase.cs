using System.Collections;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
public abstract class TowerBase : MonoBehaviour
{
    public string ID;
    [Header("Stats")]
    public int range = 6;
    public int damage = 10;
    public int fireRate = 1;
    public int buildTime = 2;
    public GameObject OnHitSpawn;
    [HideInInspector] public Transform target;
    
    [HideInInspector] public bool canFire = false;

    public abstract void Fire();
    public abstract void OnHit(GameObject Bullet);

    public void CheckForEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range);
        Transform t = null;
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                t = collider.transform;
                break;
            }
        }
        SetTarget(t);
    }

    public IEnumerator Build()
    {
        this.transform.localScale = new Vector3(0, 0, 0);
        this.transform.DOScale(1, buildTime);
        yield return new WaitForSeconds(buildTime);
        canFire = true;
    }

    public IEnumerator reloade()
    {
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
    public float DistanceToTarget()
    {
        float distance = Vector2.Distance(transform.position, target.position);
        return distance/4 + 0.5f;
    }

    private void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
