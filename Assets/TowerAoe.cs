using UnityEngine;
using DG.Tweening;
public class TowerAoe : TowerBase
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
    
        bullet.DORotate(Vector3.forward * 360, 0.5f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear).SetLoops(-1);

        bullet.DOMove(FindTarget(), DistanceToTarget()).OnComplete(() => OnHit(bullet.gameObject));
        
        StartCoroutine(reloade());
    }


    public override void OnHit(GameObject Bullet)
    {
        Destroy(Bullet);
        target.GetComponent<Target>().TakeDamage(damage);
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }



}
