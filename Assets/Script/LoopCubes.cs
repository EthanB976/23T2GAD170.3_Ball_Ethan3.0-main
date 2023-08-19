using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoopCubes : MonoBehaviour
{
   
    [SerializeField] private GameObject ball;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private int minBallsToSpawn = 1;
    [SerializeField] private int maxBallsToSpawn = 5;

    private void Start()
    {
        //set game objects to false so they can be activated later on
       
        ball.SetActive(false);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //when player enters

            //in player presses E then platforms/balls spawn in
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
