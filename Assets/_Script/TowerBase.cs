using System.Collections;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;
using UnityEditor.Callbacks;
using System.Runtime.ExceptionServices;
public abstract class TowerBase : MonoBehaviour
{
    public Transform target;
    [Header("Assigenebels")]
    public GameObject LandEffectPrefab;
    public GameObject Bulletprefab;
    public Transform ShootPoint;
    public GameObject OnHitSpawn;
    [Header("Stats")]
    public int TowerPrice = 70;
    public int range = 6;
    public float damage = 0.1f;
    public float physicalDamage = 0.1f;
    public float elementalDamage = 0.1f;
    public float fireRate = 1;
    public float BulletSpeed = 0.0f;
    public int buildTime = 2;
    public float aimConst = 1.0f;
    public float turningSpeed = 0.4f;
    [Header("Bools")]
    public bool FinishBuilded = false;
    public bool canFire = false;
    public bool IsLooking = false;
    [Header("UpgradePathWay 1")]
    public int upgrade1Price = 0;
    public GameObject upgrade1Prefab;
    [Header("UpgradePathWay 2")]
    public int upgrade2Price = 0;
    public GameObject upgrade2Prefab;

    protected Manager manager;
    public abstract void Fire();
    public abstract void OnHit(GameObject Bullet);

    void Start()
    {
       
    }

    public void CheckForEnemies()
    {
        if (target != null) return;
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
        SortTargets(colliders);
    }

    public void SortTargets(Collider2D[] colliders)
    {
        Transform longestDistanceEnemy = null;
        float maxDistanceTraveled = float.MinValue;

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                EnemyBase enemy = collider.GetComponent<EnemyBase>();
                if (enemy.distanceTraveled > maxDistanceTraveled)
                {
                    maxDistanceTraveled = enemy.distanceTraveled;
                    longestDistanceEnemy = collider.transform;   
                }
            }
        }
        SetTarget(longestDistanceEnemy);
    }
    public void CheckTargetStatus()
    {
        if (target == null)
        {
            IsLooking = false;
            return;
        } 

        if (Vector2.Distance(transform.position, target.position) > range)
        {
            SetTarget(null);
            IsLooking = false;
        }
    }
    

    public void TurnToTarget()
    {
        if (target == null || !FinishBuilded)
        {
            return;
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.DORotate(angle - 90f, turningSpeed).onComplete += () => IsLooking = true;
    }

    public void LookAtTarget()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; 
        rb.rotation = angle-90;
    }


    public Vector2 FindTarget()
    {
    Vector2 targetVelocity = target.GetComponent<EnemyBase>().direction.normalized;
    Vector2 predictedPosition = (Vector2)target.position + targetVelocity * aimConst;

    if (Vector2.Distance(transform.position, predictedPosition) < DistanceToTarget())
    {
        return Vector2.Lerp(transform.position, predictedPosition, DistanceToTarget() / Vector2.Distance(transform.position, predictedPosition));
    }
    return predictedPosition;
    }


    public IEnumerator Build()
    {
        this.transform.localScale = new Vector3(10, 10, 10);
        this.transform.DOScale(1, buildTime).SetEase(Ease.Linear);
        yield return new WaitForSeconds(buildTime);
        FinishBuilded = true;
        canFire = true;
        CameraShake.Shake(0.5f, 0.5f);
        GameObject t = Instantiate(LandEffectPrefab, transform.position, Quaternion.identity);
        Destroy(t, 0.5f);
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
        return Mathf.Ceil(distance/3 -BulletSpeed)+0.5f;
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
    public void UpgradeTower(int idUpgradePathWay, Transform SpawnerID,GameObject towerToreplace)
    {        
        if (idUpgradePathWay == 1)
        {
            GameObject tower = Instantiate(upgrade1Prefab, SpawnerID.position, Quaternion.identity);
            manager.currencyManager.LoseMoney(upgrade1Price);
            SpawnerID.GetComponent<SpawnPoint>().TowerPlaced = true;
            manager.gamemanager.ReplaceTowers(towerToreplace, tower);
        }
        else if (idUpgradePathWay == 2)
        {
            Debug.Log("Upgrade 2");
            SpawnerID.GetComponent<SpawnPoint>().TowerPlaced = true;
        }
    }
}
