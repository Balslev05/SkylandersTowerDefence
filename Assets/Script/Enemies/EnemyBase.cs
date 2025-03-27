using DG.Tweening;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    public WayPointManager wayPointManager;
    public Transform target;
    private int wayPointIndex = 0;

    private Vector2 direction;

    [Header("Stats")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private bool reachedEndPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!reachedEndPoint) { Move(); }
    }

    private void Move()
    {
        direction = target.position - transform.position;
        //rb.MovePosition(transform.position + transform.forward * direction.normalized.magnitude * moveSpeed * Time.deltaTime);
        transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.2f)
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

    private void Spawn()
    {
        // liste af enemies 
        // instanitate Shit here
        // Get Random / or not waypoint left or right 
        // wave controller
    }
}
