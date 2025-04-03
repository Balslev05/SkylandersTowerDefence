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

    private Manager Manager;



    public void Start()
    {
        Manager = GameObject.FindWithTag("Manager").GetComponent<Manager>();
    }
    public void SpawnTowers(int idTower, int SpawnerID)
    {
        SpawnTowers(idTower, 0, SpawnerID);   
    }  
    public void SpawnTowers(int idTower, int Upgrade, int SpawnerID)
    {
        CurrencyManager currencyManager = Manager.currencyManager;

        if (Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced && currencyManager.currency > towers[idTower].GetComponent<TowerBase>().TowerPrice) return;
        
        GameObject tower = Instantiate(towers[idTower], Spawners[SpawnerID].transform.position, Quaternion.identity);
        Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced = true;
        SpawnedTowers.Add(tower);
        UsedSpawners.Add(Spawners[SpawnerID]);

        currencyManager.LoseMoney(tower.GetComponent<TowerBase>().TowerPrice);
    }  

    public void SelectTower(GameObject Spawner)
    {
        for (int i = 0; i < Spawners.Length; i++)
        {
            if (Spawners[i] == Spawner)
            {
                Spawners[i].GetComponent<SpawnPoint>().isSelected = true;
                Spawners[i].transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.5f);

            } 
            else
            {
                Spawners[i].GetComponent<SpawnPoint>().isSelected = false;
                Spawners[i].transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
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
                Spawners[i].transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
                
                SpawnedTowers.Remove(SpawnedTowers[i]);
                UsedSpawners.Remove(UsedSpawners[i]);
                Destroy(TowerTemp);
            }
        }
    }
}
