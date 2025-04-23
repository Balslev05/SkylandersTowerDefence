using UnityEngine;

public class NFCReceiver : MonoBehaviour
{
    public SerialController serialController;
    TowerIDMaker towerInfoID;
    public int towerID, upgradeLevel, placementID;

    void Start()
    {
        //serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        towerInfoID = GetComponent<TowerIDMaker>();
    }

    void Update()
    {
        string message = serialController.ReadSerialMessage();

        if (message != null)
        {
            Debug.Log("Raw NFC Data: " + message);

            string[] parts = message.Split('#');

            if (parts.Length == 2)
            {
               TowerIdentity towerIdentityTemp = towerInfoID.GetTower(parts[1]);
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
    }

    void ProcessNFCData(int tower, int upgrade, int placement)
    {
        Debug.Log($"Processing Tower: {tower}, Upgrade: {upgrade}, Placement: {placement}");

        if (upgrade == 1)
        {
            Debug.Log($"Upgrading Tower {tower} at Placement {placement}");
        }
        else if (upgrade == 2)
        {
            Debug.Log($"Boosting Tower {tower} at Placement {placement}");
        }
    }
}