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
      if (isSelected && ReadInput() != -1)
      {
        gameManager.SpawnTowers(ReadInput(), 0, transform.GetSiblingIndex());
        isSelected = false;
        transform.DOScale(new Vector3(1f, 1f, 1f),0.5f);
      }
    }

    public int ReadInput()
    {
        string input = UnityEngine.Input.inputString; 
        int result;

        if (int.TryParse(input, out result) && gameManager.Spawners.Length > result) 
        {
            return result-1;
        }
        
        return -1; // Return -1 as an error indicator
    }

    

    public void Selected(){
        if (TowerPlaced == false)
        {
            gameManager.SelectTower(this.gameObject);
        }
    }   
    
    public void Deselcted(GameObject Spawner)
    {
        gameManager.DeselecTower(Spawner);
    }
}
