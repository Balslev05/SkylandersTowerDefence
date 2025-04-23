using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] wayPoints;

    public Vector2 spawnPoint;

    public float totalDistance = 0;

    void Awake()
    {
        spawnPoint = this.transform.position;

        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }

    public void FindDistanceWalked()
    {
        totalDistance = 0;
        for (int i = 0; i < wayPoints.Length - 1; i++)
        {
            totalDistance += Vector2.Distance(wayPoints[i].position, wayPoints[i + 1].position);
        }
    }

}
