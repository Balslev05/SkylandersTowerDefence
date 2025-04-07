using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.Rendering;
public class EnemyBase : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    public Transform target;
    public WayPointManager wayPointManager;
    private int wayPointIndex = 0;
    public HealthBar healthBar;

    [HideInInspector] public Vector2 direction;

    [Header("Stats")]
    [SerializeField] private int maxHealth;
    [HideInInspector] public float currentHealth;
    public float moveSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float distanceToWayPointThreshold;
    public int currencyValue;






    public int fromWave;
    private bool reachedEndPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (!reachedEndPoint) { Move(); }
    }

    private void Move()
    {
        direction = target.position - transform.position;

        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (Vector2.Distance(transform.position, target.position) <= distanceToWayPointThreshold)
        {
            GetNextWayPoint();
        }

    }

    private void GetNextWayPoint()
    {
        if (wayPointIndex >= wayPointManager.wayPoints.Length - 1)
        {
            reachedEndPoint = true;
            return;
        }

        wayPointIndex++;
        target = wayPointManager.wayPoints[wayPointIndex];
    }

    private void AttackBase()
    {
        
    }
}
