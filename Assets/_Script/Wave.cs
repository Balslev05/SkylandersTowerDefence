using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "WaveSystem", order = 1)]
public class Wave : ScriptableObject
{
    public List<GameObject> Enemies = new List<GameObject>();

    public List<bool> SpawnLeft = new List<bool>();
<<<<<<< HEAD:Assets/Script/Wave.cs

    [HideInInspector] public float spawnDelay = 0f;
=======
    
    public float spawnDelay = 10f;
>>>>>>> EnemyBase:Assets/_Script/Wave.cs
}
