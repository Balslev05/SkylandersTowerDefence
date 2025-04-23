using UnityEngine;

public class NFCReceiver : MonoBehaviour
{
    public SerialController serialController;
    TowerIDMaker towerInfoID;
    public int towerID, upgradeLevel, placementID;
    public Gamemanager gameManager;

    void Start()
    {
        //serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        towerInfoID = GetComponent<TowerIDMaker>();
    }

   /*  void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message != null)
        {
            Debug.Log("Raw NFC Data: " + message);

            string[] parts = message.Split('#');

            Debug.Log("Parts: " + parts.Length);

            if (parts.Length == 2)
            {
               TowerIdentity towerIdentityTemp = towerInfoID.GetTower(parts[1]);
               Debug.Log("Tower Identity: " + towerIdentityTemp);
                if (towerIdentityTemp != null)
                {
                    towerID = towerIdentityTemp.towerType;
                    upgradeLevel = towerIdentityTemp.towerUpgrade;
                    placementID = int.Parse(parts[0]);
                    Debug.Log($"Tower: {towerID}, Upgrade: {upgradeLevel}, Placement: {placementID}");

                    ProcessNFCData(towerID, upgradeLevel, placementID);
                }
                else
                {
                    Debug.LogWarning("invaild NFC Chip");
                }

            }
            else
            {
                Debug.Log("Invalid NFC data received: " + message);
            }
        }
    } */

    public void GetMessege(string message)
    {
        Debug.Log("Got Messege");
         if (message != null)
        {
            string[] parts = message.Split('#');
                            Debug.Log("Does the shit work111111");
             if (parts.Length == 2)
            {
               TowerIdentity towerIdentityTemp = towerInfoID.GetTower(parts[1]);
                Debug.Log("Does the shit work 222222");
                Debug.Log("Part0" +towerInfoID.GetTower(parts[0]));
                Debug.Log("Part1" +towerInfoID.GetTower(parts[1]));
              
                if (towerIdentityTemp != null)
                {
                    Debug.Log("Does the shit work 333333");
                    towerID = towerIdentityTemp.towerType;
                    upgradeLevel = towerIdentityTemp.towerUpgrade;
                    placementID = int.Parse(parts[0]);
                    ProcessNFCData(towerID, upgradeLevel, placementID);
                }
                else
                {
                    Debug.LogWarning("invaild NFC Chip");
                } 
            }
            else
            {
                Debug.Log("Invalid NFC data received: " + message);
            } 
        } 
    }

    void ProcessNFCData(int tower, int upgrade, int placement)
    {
        Debug.Log($"Processing Tower: {tower}, Upgrade: {upgrade}, Placement: {placement}");
        gameManager.SpawnTowers(tower, upgrade, placement);
        Debug.Log("The Shit Works");
    }
}