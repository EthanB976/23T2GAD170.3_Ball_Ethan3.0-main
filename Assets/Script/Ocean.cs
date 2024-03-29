using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ocean : MonoBehaviour
{
    public PlayerMovement position;
    public Transform respawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //resets players position when the hit the ocean
            position.SetPosition(respawnPosition.position.x, respawnPosition.position.y, respawnPosition.position.z);
        }
    }





}
