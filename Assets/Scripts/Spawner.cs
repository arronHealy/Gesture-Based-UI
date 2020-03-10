using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject zombies;
    public Transform[] spawnPositions;
    

    // Start is called before the first frame update
    void Start()
    {
        //Spawn();
        //spawnPause = spawnSpeed;    
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(int pos)
    {
        //new WaitForSeconds(UnityEngine.Random.Range(0, 5));
        GameObject zombie = Instantiate(zombies, spawnPositions[pos]);
        zombie.transform.position = spawnPositions[pos].transform.position;
    }
}
