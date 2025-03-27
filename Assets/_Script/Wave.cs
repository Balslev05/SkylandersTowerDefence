using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "WaveSystem", order = 1)]
public class Wave : ScriptableObject
{
    public List<GameObject> Enemies = new List<GameObject>();

    public List<bool> SpawnLeft = new List<bool>();

    [HideInInspector] public float spawnDelay = 0.2f;
}
