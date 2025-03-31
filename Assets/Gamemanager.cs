using UnityEngine;
using DG.Tweening;

public class Gamemanager : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject[] Spawners;



    public void Start()
    {
    
    }
    public void SpawnTowers(int idTower, int IdPoints)
    {
        SpawnTowers(idTower, 0, IdPoints);   
    }  
    public void SpawnTowers(int idTower, int Upgrade, int IdPoints)
    {
        if (Spawners[IdPoints].GetComponent<SpawnPoint>().TowerPlaced) return;
        Instantiate(towers[idTower], Spawners[IdPoints].transform.position, Quaternion.identity);
        Spawners[IdPoints].GetComponent<SpawnPoint>().TowerPlaced = true;
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
    
}
