using UnityEngine;
using DG.Tweening;
public class TowerFlameThrower : TowerBase
{
    [Header("TowerStats")]
    [SerializeField] private float offsetScale = 1;
    public Gradient FlameGradient;
    public int fireSpreadAngele = 0;

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
    int numProjectiles = 5; 
    float baseSpread = fireSpreadAngele; 

    for (int i = 0; i < numProjectiles; i++)
    {
        float angleOffset = Random.Range(-baseSpread, baseSpread);
        Quaternion rotation = Quaternion.Euler(0, 0, angleOffset);

        Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, rotation).transform;
        Vector3 startScale = bullet.localScale;

        SpriteRenderer bulletRenderer = bullet.GetComponent<SpriteRenderer>();
        StartGradient(bulletRenderer);

        Vector3 targetPosition = target.position + (Vector3)(Random.insideUnitCircle * 1.5f); 

        bullet.DOScale(startScale * offsetScale, DistanceToTarget()).SetEase(Ease.OutCubic);
        bullet.DOMove(targetPosition, DistanceToTarget()).OnComplete(() => 
        {
            bulletRenderer.DOFade(0, 0.5f).OnComplete(() => Destroy(bullet.gameObject));
           // OnHit(bullet.gameObject);

        });
    }

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
