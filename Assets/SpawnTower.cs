using UnityEngine;

public class SpawnTower : TowerBase
{
    public GameObject[] SoldierPrefabs;
    public int SoldierCount;
    public int SoldierslifeTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Fire() // This is the spawn Function instead
    {
        for (int i = 0; i < SoldierCount ; i++)
        {
            
        }
    }

    public override void OnHit(GameObject Bullet)
    {
        // Dont need to use this
    }

}
