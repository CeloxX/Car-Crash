using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefab;
    [SerializeField] List<GameObject> pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;
    [SerializeField] int numberOfEnemies = 5;
   

    public List<GameObject> GetEnemyPrefab() => enemyPrefab;
    public List<Transform> GetWaypoints()
    {
        GameObject path = GetRandomPathPrefab();
        var waveWaypoints = new List<Transform>();
        foreach (Transform child in path.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }
    private GameObject GetRandomPathPrefab() => pathPrefab[Random.Range(0, pathPrefab.Count)];
    public float GetTimeBetweenSpawns() => timeBetweenSpawns;
    public float GetSpawnRandomFactor() => spawnRandomFactor;
    public int GetNumberOfEnemies() => numberOfEnemies;
    
}
