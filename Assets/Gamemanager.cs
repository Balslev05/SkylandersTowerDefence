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


    public void ReplaceTowers(GameObject TowerOld, GameObject TowerNew)
    {
        for (int i = 0; i < SpawnedTowers.Count; i++)
        {
            if (SpawnedTowers[i] == TowerOld)
            {
                SpawnedTowers[i] = TowerNew;
            }
        }
    }

    void Update()
    {
        //fastForward
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = 5;
        }
        else if (Input.GetKeyUp("space"))
        {
            Time.timeScale = 1;
        }
    }


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

        if (Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced|| currencyManager.currency < towers[idTower].GetComponent<TowerBase>().TowerPrice)
        {
            //Spawners[SpawnerID].GetComponent<SpawnPoint>().TowerPlaced = false;
        return; }

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
                Spawners[i].GetComponent<SpriteRenderer>().color = Color.white;
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


                //sSpawners[i].GetComponent<SpawnPoint>().TowerPlaced = false;
                Spawners[i].GetComponent<SpawnPoint>().isSelected = false;
                Spawners[i].GetComponent<SpriteRenderer>().color = Color.white;
                Spawners[i].transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
                
                SpawnedTowers.Remove(SpawnedTowers[i]);
                UsedSpawners.Remove(UsedSpawners[i]);
                Destroy(TowerTemp);
            }
        }
    }
    
    public void FindUpgradeTower(GameObject Spawner, int Upgrade)
    {
        for (int i = 0; i < UsedSpawners.Count; i++)
        {
            if (UsedSpawners[i] == Spawner)
            {
                Debug.Log("Found the spawner");
                GameObject TowerTemp = SpawnedTowers[i];
                Debug.Log("Found the tower");
                TowerTemp.GetComponent<TowerBase>().UpgradeTower(Upgrade, Spawner.transform,TowerTemp);
                Spawners[i].transform.DOScale(new Vector3(1f, 1f, 1f), 0.5f);
                Destroy(TowerTemp); 
            }
        }
    }
}
