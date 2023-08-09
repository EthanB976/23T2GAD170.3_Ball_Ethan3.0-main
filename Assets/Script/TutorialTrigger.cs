using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{


    [SerializeField] private TextMeshPro tutorialText;
     public GameObject dialogBox;
     public TextMeshProUGUI dialogueText;


    private void Start()
    {
        tutorialText.enabled = false;
    }




    private void OnTriggerStay(Collider other)
    {
        //PLayer triggers method
        if (other.CompareTag("Player"))
        {
            Debug.Log("Stuff = things");
            //show text on screen
            tutorialText.enabled = true;
        }
        
    }





}
