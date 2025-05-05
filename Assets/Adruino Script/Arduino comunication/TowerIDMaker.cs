using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class TowerIDMaker : MonoBehaviour
{
    public SerialController serialController;
    public TowerIdentity[] towerIDArray = new TowerIdentity[36];
    public Gamemanager gameManager;

    private float tagTimeout = 4.0f;

    private Dictionary<string, TagState> activeTags = new Dictionary<string, TagState>();

    class TagState
    {
        public int placementID;
        public float lastSeenTime;
        public TowerIdentity identity;
    }

    void Start()
    {
        towerIDArray[0] = new TowerIdentity("153B3528", 1);

        towerIDArray[1] = new TowerIdentity("05D90728", 1);
        towerIDArray[2] = new TowerIdentity("059E4828", 1);
        towerIDArray[3] = new TowerIdentity("1D71158F900000", 1);
        towerIDArray[4] = new TowerIdentity("1DF1AA8E900000", 1);
        towerIDArray[5] = new TowerIdentity("1DE5E78E900000", 1);
        towerIDArray[6] = new TowerIdentity("1DE50B8F900000", 1);
        towerIDArray[7] = new TowerIdentity("1D6A2E8E900000", 1);
        towerIDArray[8] = new TowerIdentity("1D470A8D900000", 1);

        towerIDArray[9] = new TowerIdentity("63077B0E", 2);
        towerIDArray[10] = new TowerIdentity("32CF70DA", 2);
        towerIDArray[11] = new TowerIdentity("32F570DA", 2);
        towerIDArray[12] = new TowerIdentity("1DD14F8E900000", 2);
        towerIDArray[13] = new TowerIdentity("1D58BD8E900000", 2);
        towerIDArray[14] = new TowerIdentity("1D22508E900000", 2);
        towerIDArray[15] = new TowerIdentity("1DC21C8F900000", 2);
        towerIDArray[16] = new TowerIdentity("1DD2148F900000", 2);
        towerIDArray[17] = new TowerIdentity("1D76BF8E900000", 2);

        towerIDArray[18] = new TowerIdentity("43FE790E", 3);
        towerIDArray[19] = new TowerIdentity("15973F28", 3);
        towerIDArray[20] = new TowerIdentity("60699F30", 3);
        towerIDArray[21] = new TowerIdentity("1DE7158F900000", 3);
        towerIDArray[22] = new TowerIdentity("1D90BF8E900000", 3);
        towerIDArray[23] = new TowerIdentity("1DB9A98E900000", 3);
        towerIDArray[24] = new TowerIdentity("1D96008D900000", 3);
        towerIDArray[25] = new TowerIdentity("1D5C768E900000", 3);
        towerIDArray[26] = new TowerIdentity("1D97E78E900000", 3);

        towerIDArray[27] = new TowerIdentity("067274F5", 4);
        towerIDArray[28] = new TowerIdentity("15628A28", 4);
        towerIDArray[29] = new TowerIdentity("15A67128", 4);
        towerIDArray[30] = new TowerIdentity("1D18DE8E900000", 4);
        towerIDArray[31] = new TowerIdentity("1D714D8D900000", 4);
        towerIDArray[32] = new TowerIdentity("1D38BF8E900000", 4);
        towerIDArray[33] = new TowerIdentity("1DC6248F900000", 4);
        towerIDArray[34] = new TowerIdentity("1D89F18C900000", 4);
        towerIDArray[35] = new TowerIdentity("1D201D8F900000", 4);
    }

    void Update()
    {
        foreach (var item in activeTags)
        {
            Debug.Log("Active Tag"+item.Key);
        }

        List<string> tagsToRemove = new List<string>();

        foreach (var kvp in activeTags)
        {
            if (Time.time - kvp.Value.lastSeenTime > tagTimeout)
            {
                tagsToRemove.Add(kvp.Key);
            }
        }

        for (int i = 0; i < tagsToRemove.Count; i++)
        {
            string tagID = tagsToRemove[i];
            
            var removedTag = activeTags[tagID];
            Debug.Log($"[REMOVED] Tag at placement {removedTag.placementID} has been removed");
            activeTags.Remove(tagID);

            gameManager.UsedSpawners[i].GetComponent<SpawnPoint>().TowerPlaced = false;
            gameManager.RemoveTower(gameManager.SpawnedTowers[i]);
        }
        Debug.Log(activeTags.Count);


    }

    void OnMessageArrived(string message)
    {
        Debug.Log("Message arrived: " + message);

        if (!string.IsNullOrEmpty(message))
        {
            string placementOfTower = "";
            string id = "";
            bool nextMessage = false;

            for (int i = 0; i < message.Length; i++)
            {
                bool skip = false;
                if (message[i] == '#') { nextMessage = true; skip = true; }
                if (message[i] == ' ') { skip = true; }

                if (!nextMessage && !skip) placementOfTower += message[i];
                if (nextMessage && !skip) id += message[i];
            }

            id = id.Replace(" ", "");

            if (nextMessage && int.TryParse(placementOfTower, out int placementID))
            {
                TowerIdentity towerTemp = GetTower(id);

                if (towerTemp != null)
                {
                    if (activeTags.ContainsKey(id))
                    {
                        activeTags[id].lastSeenTime = Time.time;
                    }
                    else
                    {

                        Debug.Log($"[NEW] Tower placed: Type {towerTemp.towerType}, Placement {placementID}");
                        gameManager.SpawnTowers(towerTemp.towerType, towerTemp.towerUpgrade, placementID);
                       
                        activeTags[id] = new TagState
                        {
                            placementID = placementID,
                            lastSeenTime = Time.time,
                            identity = towerTemp
                        };
                    }
                }
                else
                {
                    Debug.Log("Tower temp is null");
                }
            }
        }
    }

    public TowerIdentity GetTower(string id)
    {
        id = id.Replace(" ", ""); // Normalize

        for (int i = 0; i < towerIDArray.Length; i++)
        {
            if (towerIDArray[i] != null && towerIDArray[i].towerID.Replace(" ", "") == id)
            {
                return towerIDArray[i];
            }
        }

        return null;
    }

    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
