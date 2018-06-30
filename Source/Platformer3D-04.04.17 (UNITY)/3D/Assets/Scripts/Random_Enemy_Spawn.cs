using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_Enemy_Spawn : MonoBehaviour
{
    public GameObject enemy;                //wybor prefabu przeciwnika
    public float spawnTime = 3f;            //czas miedzy spawnem
    public Transform[] spawnPoints;         //tablica spawnow
    void Start()
    {
        //wywoluj funkcje Spawn co dany odstep czasu, ciagle pojawianie sie przeciwnikow
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
    void Spawn()
    {
        //losuj SpawnPoint
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // tworzenie instancji prefabu w wylosowanym spawnPoincie
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
