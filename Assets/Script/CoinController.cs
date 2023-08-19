//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//public class CoinController : MonoBehaviour
//{
//    public delegate void TriggerStateChanged(bool isTriggered);
//    private bool isCoinCollected = false;
//    public static event TriggerStateChanged OnTriggerStateChanged;

//    private void Update()
//    {
//        isCoinCollected = false;
//        transform.Rotate(0f, 0f, 100 * Time.deltaTime, Space.Self);
//        OnTriggerStateChanged?.Invoke(false);
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Player")
//        {
//            Debug.Log("Coin collected");
//            CoinList coinList = FindObjectOfType<CoinList>();
//            if (coinList != null)
//            {
//                coinList.AddCollectedCoin(gameObject); // Add the collected coin to the list
//            }
//            CollectCoin();
//        }
//    }

//    public void CollectCoin()
//    {
//        isCoinCollected = true;
//        gameObject.SetActive(false); // Set the GameObject to inactive
//        OnTriggerStateChanged?.Invoke(true);
//    }
//}



