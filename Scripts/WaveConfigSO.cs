using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> bonusPrefab;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float timeBetweenBonusSpawn = 1f;
    [SerializeField] float spawnTimeVarience = 0f;
    [SerializeField] float minSpawnTime = 0.2f;


    public int GetBounsCount()
    {
        return bonusPrefab.Count;
    }

    public GameObject GetBonusPrefab(int index)
    {
        return bonusPrefab[index];
    }


    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();
        foreach(Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }
        return waypoints;

    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }


    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenBonusSpawn - spawnTimeVarience,
                                                    timeBetweenBonusSpawn + spawnTimeVarience);
        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);
    }


}

