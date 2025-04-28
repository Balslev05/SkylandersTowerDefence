using DG.Tweening.Core.Easing;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor.VersionControl;
using UnityEngine;

public class TowerIDMaker : MonoBehaviour
{
    public SerialController serialController;
    public TowerIdentity[] towerIDArray = new TowerIdentity[36];
    public int towerType, upgradeLevel, placementID;
    public Gamemanager gameManager;

    void Start()
    {
        towerIDArray[0] = new TowerIdentity("15 3B 35 28", 1);
        
        towerIDArray[1] = new TowerIdentity("05D90728", 1);
        towerIDArray[2] = new TowerIdentity("059E4828", 1);
        towerIDArray[3] = new TowerIdentity("1D71158F900000", 1);
        towerIDArray[4] = new TowerIdentity("1DF1AA8E900000", 1);
        towerIDArray[5] = new TowerIdentity("1DE5E78E900000", 1);
        towerIDArray[6] = new TowerIdentity("1DE50B8F900000", 1);
        towerIDArray[7] = new TowerIdentity("1D6A2E8E900000", 1);
        towerIDArray[8] = new TowerIdentity("1D470A8D900000", 1);
    
        
        towerIDArray[9] = new TowerIdentity("63077B0E", 2);
        towerIDArray[10] = new TowerIdentity("32CF70 DA", 2);
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
        towerIDArray[35] = new TowerIdentity("1D714D8D900000", 4);
        towerIDArray[31] = new TowerIdentity("1D38BF8E900000", 4);
        towerIDArray[32] = new TowerIdentity("1DC6248F900000", 4);
        towerIDArray[33] = new TowerIdentity("1D89F18C900000", 4);
        towerIDArray[34] = new TowerIdentity("1D714D8D900000", 4);
        towerIDArray[35] = new TowerIdentity(" 1D 20 1D 8F 900000", 4);
    }
   
    private void Update()
    {
      

    }
    public TowerIdentity GetTower(string id)
    {
        Debug.Log(towerIDArray.Length);
        for (int i = 0; i < towerIDArray.Length; i++)
        {
            Debug.Log("Se her: "+ towerIDArray[i].towerID);

            if (towerIDArray[i].towerID == id)
            {
                return towerIDArray[i];
            }
        }
        
        return null;
    }

    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string message)
    {
        Debug.Log("Message arrived: " + message);

        if (message != null)
        {
           
            string placementOfTower = "";
            string id = "";
            bool nextMessage = false;
            for (int i = 0; i < message.Length; i++)
            {
                bool skip = false;
                if (message[i] == '#')
                {
                    nextMessage = true;
                    skip = true;
                }

                if (message[i] == ' ')
                {
                    skip = true;
                }

                if (nextMessage == false && skip == false)
                {
                    placementOfTower += message[i];
                }

                if (nextMessage == true && skip == false)
                {
                    id += message[i];
                }
            }
            Debug.Log("id:" + id);
            Debug.Log("placement: " + placementOfTower);
            Debug.Log("next message: " + nextMessage);


            if (nextMessage == true)
            {
                placementID = int.Parse(placementOfTower);

                TowerIdentity towerTemp = GetTower(id);

                if (towerTemp != null)
                {
                    towerType = towerTemp.towerType;
                    upgradeLevel = towerTemp.towerUpgrade;

                    Debug.Log("towertype " + towerType);
                    Debug.Log("placement " + placementID);
                    Debug.Log("upgrade level " + upgradeLevel);
                }
                else
                {
                    Debug.Log("tower temp is null");
                }

            }

        }
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
