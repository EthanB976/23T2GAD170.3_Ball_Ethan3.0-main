using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTrigger : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private GameObject uiPanel;


    private void Start()
    {
        //set objects to false so they can be activated
        tutorialText.gameObject.SetActive(false);
        uiPanel.SetActive(false);
    }


    private void OnTriggerStay(Collider other)
    {
        //PLayer triggers method
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Enters");
            //show text on screen

            tutorialText.gameObject.SetActive(true);
            uiPanel.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Exits");
            //show text on screen

            tutorialText.gameObject.SetActive(false);
            uiPanel.SetActive(false);
        }
    }



}
