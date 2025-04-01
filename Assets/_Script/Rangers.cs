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
        CheckForEnemies();

        if (target != null && canFire)
        {
            Fire();
        } 
    }

    public void LookAtTarget()
{
    Vector2 direction = (target.transform.position - transform.position).normalized;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    rb.rotation = angle - 90f; // Subtract 90 degrees if your sprite's "up" is not aligned with the default forward direction
}


   public override void Fire()
{
    LookAtTarget();

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
}
