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
        //set game objects to false so they can be activated later on
        miniPlatformSpawn.SetActive(false);
        ball.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //when player enters
            if (Input.GetKeyDown(KeyCode.E))
            {
                //in player presses E then platforms/balls spawn in
                miniPlatformSpawn.SetActive(true);
                ball.SetActive(true);
                //set random value of balls
                int numBallsToSpawn = UnityEngine.Random.Range(minBallsToSpawn, maxBallsToSpawn + 1);

                for (int i = 0; i < numBallsToSpawn; i++)
                {
                    //spawn in random amount of balls
                    Instantiate(ball, ballSpawnPoint.position, Quaternion.identity);
                }
            }
        }
    }
}
