using UnityEngine;
using DG.Tweening;
public class TowerFlameThrower : TowerBase
{
    [Header("TowerStats")]
    [SerializeField] private float offsetScale = 1;
    public Gradient FlameGradient;

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

        StartGradient(bullet.GetComponent<SpriteRenderer>());

        bullet.DOScale(bullet.localScale * offsetScale, DistanceToTarget()).SetEase(Ease.OutCubic);

        bullet.DOMove(target.position, DistanceToTarget()).OnComplete(() => OnHit(bullet.gameObject));
        
        StartCoroutine(reloade());
    }
    public void StartGradient(SpriteRenderer bulletMaterial)
    {
        DOTween.To(() => bulletMaterial.color, x => bulletMaterial.color = x, FlameGradient.Evaluate(1), 0.5f);
    }
    

    public override void OnHit(GameObject Bullet)
    {
        Destroy(Bullet);
      // target.GetComponent<Health>().TakeDamage(damage);
      // POP UP EFFEKT HERE
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }
}
