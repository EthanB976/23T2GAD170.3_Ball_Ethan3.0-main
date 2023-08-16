using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Button : MonoBehaviour
{
    [SerializeField] private GameObject miniPlatformSpawn;
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private int minBallsToSpawn = 1;
    [SerializeField] private int maxBallsToSpawn = 5;

    private void Start()
    {
        miniPlatformSpawn.SetActive(false);
        ball.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                miniPlatformSpawn.SetActive(true);
                ball.SetActive(true);
                int numBallsToSpawn = UnityEngine.Random.Range(minBallsToSpawn, maxBallsToSpawn + 1);

                for (int i = 0; i < numBallsToSpawn; i++)
                {
                    Instantiate(ball, ballSpawnPoint.position, Quaternion.identity);
                }
            }
        }
    }
}
