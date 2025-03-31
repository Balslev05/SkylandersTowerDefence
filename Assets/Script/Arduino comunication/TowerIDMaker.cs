using System.Collections.Generic;
using UnityEngine;

public class TowerIDMaker : MonoBehaviour
{
    List<TowerIdentity> towerID = new List<TowerIdentity>();
    void Start()
    {
        towerID.Add(new TowerIdentity("15 3B 35 28",0));
        towerID.Add(new TowerIdentity("05 D907 28", 0));
        towerID.Add(new TowerIdentity("05 9E 48 28", 0));

        towerID.Add(new TowerIdentity("6307 7B0E", 1));
        towerID.Add(new TowerIdentity("32 CF 70 DA", 1));
        towerID.Add(new TowerIdentity("32 F5 70 DA", 1));

        towerID.Add(new TowerIdentity("43 FE 790E", 2));
        towerID.Add(new TowerIdentity("15 97 3F 28", 2));
        towerID.Add(new TowerIdentity("60 69 9F 30", 2));

        towerID.Add(new TowerIdentity("06 72 74 F5", 3));
        towerID.Add(new TowerIdentity("15 62 8A 28", 3));
        towerID.Add(new TowerIdentity("15 A6 71 28", 3));



    }


    public TowerIdentity GetTower(string id)
    {
        for (int i = 0; i < towerID.Count;)
        {
            if (towerID[i].towerID == id)
            {
                return towerID[i];
            }
        }
        return null;
    }
    

    
}
