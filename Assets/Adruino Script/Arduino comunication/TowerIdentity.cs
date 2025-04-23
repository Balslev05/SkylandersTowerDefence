using UnityEngine;

public class TowerIdentity 
{
    public string towerID;
    public int towerType;
    public int towerUpgrade;

    public TowerIdentity(string towerID, int towerType)
    {
        this.towerID = towerID;
        this.towerType = towerType;
        towerUpgrade = 0;
    }

}
