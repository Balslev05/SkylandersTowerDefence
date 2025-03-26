using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] Spawners;



    public void Start()
    {
        SpawnTowers(2,6);
        SpawnTowers(1,5);
        SpawnTowers(0,4);

    }
    public void SpawnTowers(int idTower, int IdPoints)
    {
        Instantiate(towers[idTower], Spawners[IdPoints].transform.position, Quaternion.identity);
    }  
}
