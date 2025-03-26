using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    public Transform[] wayPoints;

    void Awake()
    {
        wayPoints = new Transform[transform.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i);
        }
    }
}
