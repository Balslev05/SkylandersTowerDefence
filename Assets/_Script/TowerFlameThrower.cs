using UnityEngine;
using DG.Tweening;
public class TowerFlameThrower : TowerBase
{
    [Header("TowerStats")]
    public float FlameLifeTime = 0.5f;
    [SerializeField] private float offsetScale = 1;
    public Gradient FlameGradient;
    public float SpreadAngle = 10f;
    public int numProjectiles = 5; 
    public float randomSpeed = 5f;

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
        for (int i = 0; i < numProjectiles; i++)
        {   
            Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, transform.rotation).transform;
            bullet.GetComponent<Bullet>().physicalDamage = physicalDamage;
            bullet.GetComponent<Bullet>().elementalDamage = elementalDamage;
            bullet.GetComponent<Bullet>().bulletSpeed = Random.Range(0.010f, randomSpeed + 0.1f);
            Vector3 startScale = bullet.localScale;

            SpriteRenderer bulletRenderer = bullet.GetComponent<SpriteRenderer>();
            StartGradient(bulletRenderer);
            // Apply random spread but maintain the target direction
            float angleOffset = Random.Range(-SpreadAngle, SpreadAngle);
            Quaternion spreadRotation = Quaternion.Euler(0, 0, angleOffset);
            bullet.rotation = transform.rotation * spreadRotation;

            bullet.DOScale(startScale * offsetScale, DistanceToTarget()).SetEase(Ease.OutCubic);

            bulletRenderer.DOFade(0, FlameLifeTime).OnComplete(() => Destroy(bullet.gameObject));
            // Set direction properly so bullets move correctly
            bullet.GetComponent<Bullet>().SetDirection(bullet.up);

            Destroy(bullet.gameObject, 2.5f);
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
        if (OnHitSpawn != null)
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }
}
