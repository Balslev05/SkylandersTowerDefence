using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] Spawners;



    public void Start()
    {
        /* SpawnTowers(2,6);
        SpawnTowers(1,5);
        SpawnTowers(0,4); */

    }
    public void SpawnTowers(int idTower, int IdPoints)
    {
        SpawnTowers(idTower, 0, IdPoints);   
    }  
    public void SpawnTowers(int idTower, int Upgrade, int IdPoints)
    {
        if (Spawners[IdPoints] == null) return;
        Instantiate(towers[idTower], Spawners[IdPoints].transform.position, Quaternion.identity);
        Spawners[IdPoints] = null;
    }  
}
