using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] Spawners;



    public void Start()
    {
        SpawnTowers(1,6);
    }
    public void SpawnTowers(int idTower, int IdPoints)
    {
        Instantiate(towers[idTower], Spawners[IdPoints].transform.position, Quaternion.identity);
    }  
}
