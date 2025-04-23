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
        towerID.Add(new TowerIdentity("1D 71 15 8F 900000", 0));
        towerID.Add(new TowerIdentity("1D F1 AA 8E 900000", 0));
        towerID.Add(new TowerIdentity("1D E5 E7 8E 900000", 0));
        towerID.Add(new TowerIdentity("1D E50B 8F 900000", 0));
        towerID.Add(new TowerIdentity("1D 6A 2E 8E 900000", 0));
        towerID.Add(new TowerIdentity("1D 470A 8D 900000", 0));
        


        towerID.Add(new TowerIdentity("6307 7B0E", 1));
        towerID.Add(new TowerIdentity("32 CF 70 DA", 1));
        towerID.Add(new TowerIdentity("32 F5 70 DA", 1));
        towerID.Add(new TowerIdentity("1D D1 4F 8E 900000", 1));
        towerID.Add(new TowerIdentity("1D 58 BD 8E 900000", 1));
        towerID.Add(new TowerIdentity("1D 22 50 8E 900000", 1));
        towerID.Add(new TowerIdentity("1D C2 1C 8F 900000", 1));
        towerID.Add(new TowerIdentity("1D D2 14 8F 900000", 1));
        towerID.Add(new TowerIdentity("1D 76 BF 8E 900000", 1));


        towerID.Add(new TowerIdentity("43 FE 790E", 2));
        towerID.Add(new TowerIdentity("15 97 3F 28", 2));
        towerID.Add(new TowerIdentity("60 69 9F 30", 2));
        towerID.Add(new TowerIdentity("1D E7 15 8F 900000", 2));
        towerID.Add(new TowerIdentity("1D 90 BF 8E 900000", 2));
        towerID.Add(new TowerIdentity("1D B9 A9 8E 900000", 2));
        towerID.Add(new TowerIdentity("1D 9600 8D 900000", 2));
        towerID.Add(new TowerIdentity("1D 5C 76 8E 900000", 2));
        towerID.Add(new TowerIdentity("1D 97 E7 8E 900000", 2));


        towerID.Add(new TowerIdentity("06 72 74 F5", 3));
        towerID.Add(new TowerIdentity("15 62 8A 28", 3));
        towerID.Add(new TowerIdentity("15 A6 71 28", 3));
        towerID.Add(new TowerIdentity("1D 18 DE 8E 900000", 3));
        towerID.Add(new TowerIdentity("1D 38 BF 8E 900000", 3));
        towerID.Add(new TowerIdentity("1D C6 24 8F 900000", 3));
        towerID.Add(new TowerIdentity("1D 89 F1 8C 900000", 3));
        towerID.Add(new TowerIdentity("1D 71 4D 8D 900000", 3));
        towerID.Add(new TowerIdentity("1D 20 1D 8F 900000", 3));




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
