using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMushrooms : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject[] MuschiVariants;


    public float spawnRadius = 5.0f;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 0.0f, 5.0f);
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        GameObject enemy = Instantiate(MuschiVariants[Random.Range(0,MuschiVariants.Length)], spawnPosition, Quaternion.identity);
    }
}


// [System.Serializable]
// public class Element {

//     public string name;
//     [Range(1, 10)]
//     public int density;

//     public GameObject[] prefabs;

//     public bool CanPlace () {

//         // Validation check to see if element can be placed. More detailed calculations can go here, such as checking perlin noise.

//         if (Random.Range(0, 10) < density)
//             return true;
//         else
//             return false;

//     }

//     public GameObject GetRandom() {

//         // Return a random GameObject prefab from the prefabs array.

//         return prefabs[Random.Range(0, prefabs.Length)];

//     }

// }