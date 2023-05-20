using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
   [SerializeField] List<WaveConfigSO> waveConfigs;
   [SerializeField] float timeBetweenWaves = 0f;
   [SerializeField] bool isLooping; 
   WaveConfigSO currentWave;
    void Start()
    {
       StartCoroutine(SpawnBonusWave()); 
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnBonusWave()
    {
        do
        {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                        
                for(int i = 0; i < currentWave.GetBounsCount(); i++)
                {
                    
                Instantiate(
                    currentWave.GetBonusPrefab(i), 
                    currentWave.GetStartingWaypoint().position,
                    Quaternion.identity, 
                    transform );

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while(isLooping);
    }
}

