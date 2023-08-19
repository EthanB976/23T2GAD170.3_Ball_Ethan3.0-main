//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CoinList : MonoBehaviour
//{
//    [SerializeField] private List<GameObject> collectedCoins = new List<GameObject>();
//    private int collectedCoinCount = 0;

//    private void Start()
//    {
//        // Subscribe to the OnTriggerStateChanged event from CoinController
//        CoinController.OnTriggerStateChanged += HandleTriggerStateChanged;
//    }

//    private void HandleTriggerStateChanged(bool isTriggered)
//    {
//        if (isTriggered)
//        {
//            Debug.Log("Trigger is now active.");
//            // Your code to respond to the trigger activation
//            Collectcoins();
//        }
//    }

//    public void AddCollectedCoin(GameObject coin)
//    {
//        collectedCoins.Add(coin); // Add the coin to the list
//    }

//    private void Collectcoins()
//    {
//        foreach (GameObject coin in collectedCoins)
//        {
//            coin.GetComponent<CoinController>().CollectCoin(); // Collect each coin
//        }
//        collectedCoinCount = collectedCoins.Count; // Set the collected coins count
//        collectedCoins.Clear(); // Clear the list of coin objects
//        Debug.Log("Coins collected: " + collectedCoinCount);
//    }
//}
