using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public Wave[] waves;
    public Enemy enemy;

    Wave CurrentWave;
    int currentWaveNumber;

    int enemiesRemainingToSpawn;
    float nextSpawnTime;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + CurrentWave.timeBetweenSpawns;

            Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
            //spawnedEnemy.OnDeath += OnEnemyDeath;
        }
    }

    void OnEnemyDeath()
    {
        print("Enemy DIED");
    }

    void NextWave()
    {
        currentWaveNumber++;
        CurrentWave = waves[currentWaveNumber - 1];

        enemiesRemainingToSpawn = CurrentWave.enemyCount;
    }

    [System.Serializable]

    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;

    }

}