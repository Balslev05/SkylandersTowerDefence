using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private WayPointManager LeftWayPointManager;
    [SerializeField] private WayPointManager RightWayPointManager;

    [SerializeField] private List<Wave> waves = new List<Wave>();

    private int currentWave;

    [SerializeField] private int betweenWavesCooldown;

    private void Start()
    {
        currentWave = 0;
        Debug.Log($"Wave {currentWave} Incoming");
        StartCoroutine(StartBattle());
    }

    private void Spawn(WayPointManager SpawnPoint, GameObject enemy)
    {
        EnemyBase spawnedEnemy = Instantiate(enemy, SpawnPoint.spawnPoint, Quaternion.identity).GetComponent<EnemyBase>();
        spawnedEnemy.wayPointManager = SpawnPoint;
        spawnedEnemy.target = SpawnPoint.wayPoints[0];
    }

    private IEnumerator StartBattle()
    {
        for (int i = 0; i < waves[currentWave].Enemies.Count; i++)
        {
            if (waves[currentWave].SpawnLeft[i])
            {
                Spawn(LeftWayPointManager, waves[currentWave].Enemies[i]);
            }
            else
            {
                Spawn(RightWayPointManager, waves[currentWave].Enemies[i]);
            }

            yield return new WaitForSeconds(0);
        }

        yield return new WaitForSeconds(betweenWavesCooldown);
        currentWave++;
        if (currentWave < waves.Count)
        {
            Debug.Log($"Wave {currentWave} Incoming");
            StartCoroutine(StartBattle());
        }
        else
        {
            Debug.Log("Game Won");
        }
    }
}
