using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private GameObject[] _powerups;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerupsRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            
           Instantiate(_enemyPrefab, new Vector3(Random.Range(-8.2f, 8.2f), 4.12f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    IEnumerator SpawnPowerupsRoutine()
    {
        while (true)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(_powerups[randomPowerup], new Vector3(Random.Range(-8.2f, 8.2f), 4.12f, 0),
                Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}
