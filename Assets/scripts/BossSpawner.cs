using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour
{



    public Transform[] spawnLocations;
    public GameObject[] whatToSpawnPreFab;
    public GameObject[] whatToSpawnClone;

    void Start()
    {
        spawnSomethingAwesomePlease();
    }

    void spawnSomethingAwesomePlease()
    {
        whatToSpawnClone[0] = Instantiate(whatToSpawnPreFab[0], spawnLocations[0].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    
}

