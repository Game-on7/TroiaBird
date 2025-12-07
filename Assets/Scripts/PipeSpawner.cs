using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipe;

    private float timer;
    
    void Start()
    {
        SpawnPipe();
    }

    private void Update()
    {
        if (timer > maxTime)
        {
            SpawnPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe1 = Instantiate(pipe, spawnPos, Quaternion.identity);
        Destroy(pipe1, 10f);
    }
}
