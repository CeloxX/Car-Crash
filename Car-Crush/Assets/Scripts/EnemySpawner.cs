using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField]int startingWave = 0;
    [SerializeField] bool loop;
    List<GameObject> enemyPrefabs;
    List<Transform> waypoints;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (loop);
    }
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

   private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            enemyPrefabs = waveConfig.GetEnemyPrefab();
            waypoints = waveConfig.GetWaypoints();
            var newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], waypoints[0].transform.position, transform.rotation);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(GameSession.Instance.GetTimeBetweenSpawns());
        }
    }
}
