using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private CurrencyManager currencyManager;

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

    private void Spawn(WayPointManager SpawnPoint, GameObject enemy, int CurrentWave)
    {
        EnemyBase spawnedEnemy = Instantiate(enemy, SpawnPoint.spawnPoint, Quaternion.identity).GetComponent<EnemyBase>();
        spawnedEnemy.wayPointManager = SpawnPoint;
        spawnedEnemy.target = SpawnPoint.wayPoints[0];
        spawnedEnemy.fromWaveID = CurrentWave;
    }

    private IEnumerator StartBattle()
    {
        for (int i = 0; i < waves[currentWave].Enemies.Count; i++)
        {
            if (waves[currentWave].SpawnLeft[i])
            {
                Spawn(LeftWayPointManager, waves[currentWave].Enemies[i], currentWave);
            }
            else
            {
                Spawn(RightWayPointManager, waves[currentWave].Enemies[i], currentWave);;
            }

            yield return new WaitForSeconds(waves[currentWave].spawnDelay);
        }
        
        yield return new WaitForSeconds(betweenWavesCooldown);

        currencyManager.GetMoney(waves[currentWave].currencyValue);
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
