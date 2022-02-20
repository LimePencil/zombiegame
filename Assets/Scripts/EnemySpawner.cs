using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public float[] spawnPossiblity;
    public float spawnDistance = 5f;
    public Transform player;
    public float spawnRate = 1f;
    private float startSpawnRate;
    private float nextTime;
    public float peakSpawnRate = 0.2f;
    public float timeReachPeak = 500f;
    private float startTime;

    void Start() {
        nextTime = Time.time+spawnRate;
        startTime = Time.time;
        startSpawnRate = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Time.time > nextTime){
            Spawn();
        }


    }
    void Spawn(){
        nextTime = Time.time+spawnRate;
        spawnRate =  startSpawnRate - (startSpawnRate-peakSpawnRate)*(Mathf.Min(Time.time-startTime,timeReachPeak))/timeReachPeak;
        for (int i = 0; i < enemies.Length; i++)
        {
            float r = Random.Range(0f,1f);
            if (r < spawnPossiblity[i]){
                Vector3 v = Random.insideUnitCircle.normalized*spawnDistance;
                GameObject e = Instantiate(enemies[i],player.position+v,Quaternion.identity);
            }
        }
        
    }
}
