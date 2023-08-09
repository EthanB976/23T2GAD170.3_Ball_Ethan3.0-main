using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using TMPro;
using UnityEngine;

public class DangerButton : MonoBehaviour
{

   [SerializeField] private TextMeshPro tutorialText;
   [SerializeField] private bool isPCNextToButton = false;

    [SerializeField] private GameObject cube;

    [SerializeField] private Transform spawnPoint;

   private void Start()
   {
       tutorialText.enabled = false;
   }

   private void OnTriggerEnter(Collider other)
   {
       //PLayer triggers method
       if (other.CompareTag("Player"))
       {
           Debug.Log("Stuff = things");
           //show text on screen
           tutorialText.enabled = true;
            isPCNextToButton = true;
       }

   }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stuff = things");
            //hide text on screen
            tutorialText.enabled = false;
            isPCNextToButton = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPCNextToButton)
        {
            Debug.Log("Danger zone");

            Instantiate(cube, spawnPoint.position, Random.rotation);
        }
    }


}
