using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using System.Collections.Generic;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] Spawners;

    public List<GameObject> SpawnedTowers;
    public List<GameObject> UsedSpawners;



    public void Start()
    {
    
    }
    public void SpawnTowers(int idTower, int SpawnerID)
    {
        SpawnTowers(idTower, 0, SpawnerID);   
    }  
    public void SpawnTowers(int idTower, int Upgrade, int SpawnerID)
    {
        if (Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced) return;
       GameObject tower = Instantiate(towers[idTower], Spawners[SpawnerID].transform.position, Quaternion.identity);
        Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced = true;
        SpawnedTowers.Add(tower);
        UsedSpawners.Add(Spawners[SpawnerID]);
    }  

    public void SelectTower(GameObject Spawner)
    {
        for (int i = 0; i < Spawners.Length; i++)
        {
            if (Spawners[i] == Spawner)
            {
                Spawners[i].GetComponent<SpawnPoint>().isSelected = true;
                Spawners[i].GetComponent<SpriteRenderer>().color = Color.green;
                Spawners[i].transform.DOScale(new Vector3(2.2f, 2.2f, 2.2f), 0.5f);

            } 
            else
            {
                Spawners[i].GetComponent<SpawnPoint>().isSelected = false;
                Spawners[i].GetComponent<SpriteRenderer>().color = Color.red;
                Spawners[i].transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.5f);
            } 
        }
    }

    public void DeselecTower(GameObject Spawner)
    {
        for (int i = 0; i < UsedSpawners.Count; i++)
        {
            if (UsedSpawners[i] == Spawner)
            {
                GameObject TowerTemp = SpawnedTowers[i];


                Spawners[i].GetComponent<SpawnPoint>().TowerPlaced = false;
                Spawners[i].GetComponent<SpawnPoint>().isSelected = false;
                Spawners[i].GetComponent<SpriteRenderer>().color = Color.red;
                Spawners[i].transform.DOScale(new Vector3(1.7f, 1.7f, 1.7f), 0.5f);
                
                SpawnedTowers.Remove(SpawnedTowers[i]);
                UsedSpawners.Remove(UsedSpawners[i]);
                Destroy(TowerTemp);
            }
        }
    }
}
