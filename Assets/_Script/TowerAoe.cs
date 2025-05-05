using UnityEngine;
using DG.Tweening;
public class TowerAoe : TowerBase
{
    [Header("TowerStats")]
    [SerializeField] private float offsetScale = 1;

    void Start()
    {
        manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
        StartCoroutine(Build());
    }
    void Update()
    {
        CheckTargetStatus();

        if (target != null && IsLooking) LookAtTarget();

        CheckForEnemies();

        if (target != null) TurnToTarget();


        if (target != null && canFire && IsLooking)
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
        Eksplosion OnHit = Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity).GetComponent<Eksplosion>();
        OnHit.physicalDamage = physicalDamage;
        OnHit.elementalDamage = elementalDamage;
    }



}
