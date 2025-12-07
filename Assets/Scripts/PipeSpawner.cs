using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 1.5f;
    [SerializeField] private float heightRange = 0.45f;
    [SerializeField] private GameObject pipe;

    private float timer;
    
    private void Update()
    {
        if (GameManager.instance.gameStarted)
        {
            if (timer > maxTime)
            {
                SpawnPipe();
                timer = 0;
            }

            timer += Time.deltaTime;
        }
    }

    public void SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange));
        GameObject pipe1 = Instantiate(pipe, spawnPos, Quaternion.identity);
        Destroy(pipe1, 5f);
    }
}
