using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;
using DG.Tweening;
using UnityEngine.Rendering;
public class EnemyBase : MonoBehaviour
{
    [Header("Components")]
    public HealthBar healthBar;
    [HideInInspector] public Transform target;
    [HideInInspector] public WayPointManager wayPointManager;
    private Rigidbody2D rb;
    private int wayPointIndex = 0;
    public int fromWaveID;

    [HideInInspector] public Vector2 direction;

    [Header("Stats")]
    [SerializeField] private int maxHealth;
    [HideInInspector] public float currentHealth;
    public float physicalResistance;
    public float elementalResistance;
    public float moveSpeed;
    [SerializeField] private int damage;
    [SerializeField] private float AttackRate;
    public int currencyValue;
    [SerializeField] private float distanceToWayPointThreshold;
    private bool reachedEndPoint;

    public float distanceTraveled = 0f;
    private Vector2 lastPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {
        if (!reachedEndPoint) { Move(); }

        TrackDistance();
        CheckProgress();
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

    void TrackDistance()
    {
        float frameDistance = Vector2.Distance(lastPosition, transform.position);
        distanceTraveled += frameDistance;
        lastPosition = transform.position;
    }

    void CheckProgress()
    {
        float progress = distanceTraveled / wayPointManager.totalDistance;
    }

    private void AttackBase()
    {
        
    }
}
