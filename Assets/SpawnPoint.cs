using UnityEngine;
using DG.Tweening;
public class SpawnPoint : MonoBehaviour
{
    public Gamemanager gameManager;
    public bool isSelected = false;
    public bool TowerPlaced = false;
    
    void Start()
    {

    }

    void Update()
    {  
        if (isSelected && TowerPlaced && ReadUpgradeInput() != -1)
        {
            gameManager.FindUpgradeTower(gameObject, ReadUpgradeInput());
            GetComponent<SpriteRenderer>().color = Color.white;
        }

      if (isSelected && ReadInputSpawnInput() != -1)
      {
        gameManager.SpawnTowers(ReadInputSpawnInput(), 0, transform.GetSiblingIndex());
        isSelected = false;
        transform.DOScale(new Vector3(1f, 1f, 1f),0.5f);
      }
    }

    public int ReadInputSpawnInput()
    {
        string input = UnityEngine.Input.inputString; 
        int result;

        if (int.TryParse(input, out result) && gameManager.Spawners.Length > result) 
        {
            return result-1;
        }
        
        return -1; // Return -1 as an error indicator
    }
     public int ReadUpgradeInput()
    {
        string input = UnityEngine.Input.inputString; 
        int result;

        if (int.TryParse(input, out result) && result > 0 && result < 3) 
        {
            return result;
        }
        
        return -1; // Return -1 as an error indicator
    }

    

    public void Selected(){
        if (TowerPlaced == false)
        {
            gameManager.SelectTower(this.gameObject);
        }

        if (TowerPlaced)
        {
            gameManager.SelectTower(this.gameObject);
            this.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }   
    
    public void Deselcted(GameObject Spawner)
    {
        gameManager.DeselecTower(Spawner);
    }
}
