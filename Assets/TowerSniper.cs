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
        Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, transform.rotation).transform;
        Vector3 startScale = bullet.localScale;

        bullet.DOScale(bullet.localScale * offsetScale, DistanceToTarget() / 2).SetEase(Ease.OutCubic).OnComplete(() =>
        bullet.DOScale(startScale*0.8f, DistanceToTarget() / 2).SetEase(Ease.InQuint));  

        bullet.transform.LookAt(target.position);
        bullet.DOMove(target.position, DistanceToTarget()).OnComplete(() => OnHit(bullet.gameObject));
        
        StartCoroutine(reloade());
    }
    

    public override void OnHit(GameObject Bullet)
    {
        Destroy(Bullet);
      // target.GetComponent<Health>().TakeDamage(damage);
      // POP UP EFFEKT HERE
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }
}
