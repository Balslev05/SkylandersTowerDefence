using UnityEngine;
using DG.Tweening;

public class TowerSniper : TowerBase
{
   [Header("TowerStats")]
    [SerializeField] private float offsetScale = 1;

    void Start()
    {
        StartCoroutine(Build());
    }
    void Update()
    {
        CheckForEnemies();

        if (target != null && canFire)
        {
            Fire();
        }
    }

    public override void Fire()
    {
        Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, Quaternion.identity).transform;
        
        // Compute the direction to the target
        Vector3 direction = (target.position - bullet.position).normalized;
        
        // Adjust rotation to match 2D orientation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.rotation = Quaternion.Euler(0, 0, (angle-90));
        
        // Move towards the target
        bullet.DOMove(CalculateTarget(), DistanceToTarget()).SetEase(Ease.OutQuint).OnComplete(() => OnHit(bullet.gameObject));

        StartCoroutine(reloade());
    }

    public override void OnHit(GameObject Bullet)
    {
        Destroy(Bullet);
        target.GetComponent<Target>().TakeDamage(damage);
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }
}
