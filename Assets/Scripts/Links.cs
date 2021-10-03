using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Links : MonoBehaviour
{
    public bool shopLocation;

    void Start()
    {
        if (shopLocation)
        {
            GameManager.instance.shop = FindObjectOfType<Shop>();
            GameManager.instance.audioPlayer = FindObjectOfType<AudioPlayer>();
            GameManager.instance.GetComponent<Inventory>()._parent = GameObject.FindGameObjectWithTag("myInventory").transform;
            GameManager.instance.inventory.UpdateMyItems();
        }
        
        GameManager.instance.myCoins = GameObject.FindGameObjectWithTag("Coins").GetComponent<TMP_Text>();
        GameManager.instance.UpdateMyCoins();
        
    }
}
