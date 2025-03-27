using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] wayPoints;

    public Vector2 spawnPoint;

    void Awake()
    {
        spawnPoint = this.transform.position;

        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }
}
