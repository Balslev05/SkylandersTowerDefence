using UnityEngine;

public class NFCReceiver : MonoBehaviour
{
    public Gamemanager gameManager;
    public SerialController serialController;
    public int towerID, upgradeLevel, placementID; 

    void Start()
    {
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        string message = serialController.ReadSerialMessage(); 

        if (message != null)
        {
            Debug.Log("Raw NFC Data: " + message);

            string[] parts = message.Split(','); 

            if (parts.Length == 3) 
            {
                towerID = int.Parse(parts[0]); 
                upgradeLevel = int.Parse(parts[1]);
                placementID = int.Parse(parts[2]);

                Debug.Log($"Tower: {towerID}, Upgrade: {upgradeLevel}, Placement: {placementID}");

                NFCData(towerID, upgradeLevel, placementID);
            }
            else
            {
                Debug.Log("Invalid NFC data received: " + message); 
            }
        }
    }

    void NFCData(int tower, int upgrade, int placement)
    {
        Debug.Log($"Processing Tower: {tower}, Upgrade: {upgrade}, Placement: {placement}");

        gameManager.SpawnTowers(tower,0, placement);
    }
}
