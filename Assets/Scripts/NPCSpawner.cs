using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  //random, coroutine, instantiate

public class NPCSpawner : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] npc;

    //Spawn
    private float timer = 1f;
    private int maxTimeToSpawn = 10;
    
    //Coroutine
    bool waitForTime = false;

    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(RandomSpawn());
        }
    }

    void Update()
    {
        timer += Time.deltaTime;    
        checkedTimeForIncreaseSpawns();
    }

    private void checkedTimeForIncreaseSpawns()
    {
        int time = (int)timer;
        //Every 5 seconds, decrease max time spawn
        if(time % 5 == 0 && maxTimeToSpawn > 2 && !waitForTime)
        {
            //Spawn enemies faster
            maxTimeToSpawn -= 2;
            StartCoroutine(WaitForNext());
        }
    }

    IEnumerator RandomSpawn()
    {
        int spawnerRandomNum = UnityEngine.Random.Range(0, spawners.Length);
        int NPCRandomNum = UnityEngine.Random.Range(0, npc.Length);
        //int timeBetweenSpawns = UnityEngine.Random.Range(0, maxTimeToSpawn);
        int timeBetweenSpawns = 1;
        //GameObject enemy = Instantiate( npc[NPCRandomNum], spawners[spawnerRandomNum].transform.position, Quaternion.identity ) as GameObject;

        /*Collider[] hitColliders = Physics.OverlapSphere(spawners[spawnerRandomNum].transform.position, .25f);
        if (hitColliders.Length == 0)   //check if spawner isnt being blocked
        {
            GameObject enemy = Instantiate( npc[NPCRandomNum], spawners[spawnerRandomNum].transform.position, Quaternion.identity ) as GameObject;
        }*/

        if(!Physics.CheckSphere(transform.position, .1f))
        {
            GameObject enemy = Instantiate(npc[0], spawners[0].transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            Debug.Log("Couldn't spawn");
        }

        yield return new WaitForSeconds(timeBetweenSpawns);
    }

    IEnumerator WaitForNext()
    {
        waitForTime = true;
        yield return new WaitForSeconds(1f);
        waitForTime = false;
    }
}
