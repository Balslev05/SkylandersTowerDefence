using AYellowpaper.SerializedCollections;
using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowerIDMaker : MonoBehaviour
{

    [SerializedDictionary("activeTags","Timer To Expire")]
    public SerializedDictionary<string, float> activeTags = new SerializedDictionary<string, float>();
    [SerializedDictionary("tagToPlacementMap","placementID")]
    public SerializedDictionary<string, int> tagToPlacementMap = new SerializedDictionary<string, int>();
    
    public SerialController serialController;
    public TowerIdentity[] towerIDArray = new TowerIdentity[36];
    public Gamemanager gameManager;

    private float tagTimeout = 4.0f;

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
        List<string> expiredTags = new List<string>();
        //Debug.Log("Active tags: " + activeTags.Keys);
        foreach (var tag in activeTags.Keys.ToArray())
        {
            activeTags[tag] -= Time.deltaTime;

            if (activeTags[tag] <= 0)
            {
                expiredTags.Add(tag);
            }
        }

        foreach (string tag in expiredTags)
        {
            if (tagToPlacementMap.TryGetValue(tag, out int placementID))
            {
                // Fjern tårnet
                Debug.Log("PlacementID: " + placementID);
                gameManager.UsedSpawners[placementID].GetComponent<SpawnPoint>().TowerPlaced = false;
                gameManager.RemoveTower(gameManager.SpawnedTowers[placementID]);

                Debug.Log($"[REMOVE] Tag {tag} timed out. Tower removed at placement {placementID}.");
            }

            // Fjern tag fra dictionaries
            activeTags.Remove(tag);
            tagToPlacementMap.Remove(tag);
        }
    }

    void OnMessageArrived(string message)
    {
        if (!string.IsNullOrEmpty(message))
        {
            string placementStr = "";
            string id = "";
            bool readingID = false;

            foreach (char c in message)
            {
                if (c == '#')
                {
                    readingID = true;
                    continue;
                }

                if (c == ' ') continue;

                if (!readingID)
                    placementStr += c;
                else
                    id += c;
            }

            id = id.Replace(" ", "");

            if (int.TryParse(placementStr, out int placementID))
            {
                TowerIdentity tower = GetTower(id);

                if (tower != null)
                {
                    // Reset timer uanset hvad
                    activeTags[id] = tagTimeout;

                    // Kun placer hvis den ikke allerede er i gang
                    if (!tagToPlacementMap.ContainsKey(id))
                    {
                        tagToPlacementMap[id] = placementID;
                        gameManager.SpawnTowers(tower.towerType, tower.towerUpgrade, placementID);
                        Debug.Log($"[SPAWN] Tower placed for tag {id} at {placementID}");
                    }
                }
            }
        }
    }

    public TowerIdentity GetTower(string id)
    {
        id = id.Replace(" ", "");

        foreach (var tower in towerIDArray)
        {
            if (tower != null && tower.towerID.Replace(" ", "") == id)
                return tower;
        }

        return null;
    }

    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Connection established" : "Connection lost");
    }
}
