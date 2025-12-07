using System;
using UnityEngine;

public class PipeIncreaseScore : MonoBehaviour
{
    UIManager uIManager;

    private void Awake()
    {
        uIManager = FindFirstObjectByType<UIManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uIManager.UpdateScore(1);
        }
    }
}
