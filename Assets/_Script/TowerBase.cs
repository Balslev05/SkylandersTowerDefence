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
    public float damage = 0.1f;
    public float fireRate = 1;
    public float BulletSpeed = 0.0f;
    public int buildTime = 2;
    public GameObject OnHitSpawn;
    public float aimConst = 1.0f;
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
    public void damageTarget(GameObject target)
    {
        // DO SHIT HERE I THINK :=
    }
    
   public Vector2 CalculateTarget()
{
    Vector2 targetVelocity = target.GetComponent<EnemyBase>().direction.normalized;
    Vector2 predictedPosition = (Vector2)target.position + targetVelocity * aimConst;

    // Only use Lerp if the target is moving unpredictably
    if (Vector2.Distance(transform.position, predictedPosition) < DistanceToTarget())
    {
        return Vector2.Lerp(transform.position, predictedPosition, DistanceToTarget() / Vector2.Distance(transform.position, predictedPosition));
    }
    
    return predictedPosition;
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
        return Mathf.Ceil(distance/3- BulletSpeed)+0.5f;
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
