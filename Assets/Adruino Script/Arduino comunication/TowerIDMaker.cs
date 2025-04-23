using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerIDMaker : MonoBehaviour
{
    public List<TowerIdentity> towerID = new List<TowerIdentity>();
    public TowerIdentity[] towerIDArray = new TowerIdentity[36];

    void Start()
    {
        towerIDArray[0] = new TowerIdentity("15 3B 35 28", 1);
        
        towerIDArray[1] = new TowerIdentity("05 D907 28", 1);
        towerIDArray[2] = new TowerIdentity("05 9E 48 28", 1);
        towerIDArray[3] = new TowerIdentity("1D 71 15 8F 900000", 1);
        towerIDArray[4] = new TowerIdentity("1D F1 AA 8E 900000", 1);
        towerIDArray[5] = new TowerIdentity("1D E5 E7 8E 900000", 1);
        towerIDArray[6] = new TowerIdentity("1D E50B 8F 900000", 1);
        towerIDArray[7] = new TowerIdentity("1D 6A 2E 8E 900000", 1);
        towerIDArray[8] = new TowerIdentity("1D 470A 8D 900000", 1);
    
        
        towerIDArray[9] = new TowerIdentity("6307 7B0E", 2);
        towerIDArray[10] = new TowerIdentity("32 CF 70 DA", 2);
        towerIDArray[11] = new TowerIdentity("32 F5 70 DA", 2);
        towerIDArray[12] = new TowerIdentity("1D D1 4F 8E 900000", 2);
        towerIDArray[13] = new TowerIdentity("1D 58 BD 8E 900000", 2);
        towerIDArray[14] = new TowerIdentity("1D 22 50 8E 900000", 2);
        towerIDArray[15] = new TowerIdentity("1D C2 1C 8F 900000", 2);
        towerIDArray[16] = new TowerIdentity("1D D2 14 8F 900000", 2);
        towerIDArray[17] = new TowerIdentity("1D 76 BF 8E 900000", 2);


        towerIDArray[18] = new TowerIdentity("43 FE 790E", 3);
        towerIDArray[19] = new TowerIdentity("15 97 3F 28", 3);
        towerIDArray[20] = new TowerIdentity("60 69 9F 30", 3);
        towerIDArray[21] = new TowerIdentity("1D E7 15 8F 900000", 3);
        towerIDArray[22] = new TowerIdentity("1D 90 BF 8E 900000", 3);
        towerIDArray[23] = new TowerIdentity("1D B9 A9 8E 900000", 3);
        towerIDArray[24] = new TowerIdentity("1D 9600 8D 900000", 3);
        towerIDArray[25] = new TowerIdentity("1D 5C 76 8E 900000", 3);
  
        towerIDArray[26] = new TowerIdentity(" 1D 97 E7 8E 900000", 3);
  
        towerIDArray[27] = new TowerIdentity(" 06 72 74 F5", 4);
        towerIDArray[28] = new TowerIdentity(" 15 62 8A 28", 4);
        towerIDArray[29] = new TowerIdentity(" 15 A6 71 28", 4);
        towerIDArray[30] = new TowerIdentity(" 1D 18 DE 8E 900000", 4);
        towerIDArray[35] = new TowerIdentity(" 1D 71 4D 8D 900000", 4);
        towerIDArray[31] = new TowerIdentity(" 1D 38 BF 8E 900000", 4);
        towerIDArray[32] = new TowerIdentity(" 1D C6 24 8F 900000", 4);
        towerIDArray[33] = new TowerIdentity(" 1D 89 F1 8C 900000", 4);
        towerIDArray[34] = new TowerIdentity(" 1D 71 4D 8D 900000", 4);
        towerIDArray[35] = new TowerIdentity(" 1D 20 1D 8F 900000", 4);
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
