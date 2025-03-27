using System.Collections;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
public abstract class TowerBase : MonoBehaviour
{
    [Header("Stats")]
    public GameObject Bulletprefab;
    public Transform ShootPoint;
    public int range = 6;
    public int damage = 10;
    public float fireRate = 1;
    public float BulletSpeed = 0.0f;
    public int buildTime = 2;
    public GameObject OnHitSpawn;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool canFire = false;
    [Header("UpgradePathWay 1")]
    public int upgrade1Price = 0;
    public GameObject upgrade1Prefab;
    [Header("UpgradePathWay 2")]
    public int upgrade2Price = 0;
    public GameObject upgrade2Prefab;

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
        return (distance/4 - BulletSpeed)+0.1f;
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
