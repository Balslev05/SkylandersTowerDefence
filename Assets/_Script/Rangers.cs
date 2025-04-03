using UnityEngine;
using DG.Tweening;
public class Rangers : TowerBase
{
    [Header("Specific to Rangers")]
    public float SpreadAngle = 10f;
    public int AmountOfBullets;
    public float randomSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    for (int i = 0; i < AmountOfBullets; i++)
    {   
        Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, transform.rotation).transform;
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().bulletSpeed = Random.Range(1, randomSpeed + 1);

        // Apply random spread but maintain the target direction
        float angleOffset = Random.Range(-SpreadAngle, SpreadAngle);
        Quaternion spreadRotation = Quaternion.Euler(0, 0, angleOffset);
        bullet.rotation = transform.rotation * spreadRotation;

        // Set direction properly so bullets move correctly
        bullet.GetComponent<Bullet>().SetDirection(bullet.up);
    }
    
    StartCoroutine(reloade());
}

    
    public override void OnHit(GameObject Bullet)
    {
        Destroy(Bullet);
        if (OnHitSpawn != null)
        Instantiate(OnHitSpawn, Bullet.transform.position, Quaternion.identity);
    }


    public void secondaryFire(){
        Transform bullet = Instantiate(Bulletprefab, ShootPoint.position, transform.rotation).transform;
        bullet.GetComponent<Bullet>().damage = damage;
        bullet.GetComponent<Bullet>().bulletSpeed = Random.Range(1, randomSpeed + 1);
        bullet.GetComponent<Bullet>().SetDirection(bullet.up);
    }
}
