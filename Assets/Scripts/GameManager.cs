using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int bitcoins = 0;

    public TMP_Text myCoins;

    public Shop shop;
    public Inventory inventory;

    public AudioPlayer audioPlayer;

    void Awake()
    {
        // “еперь, провер€ем существование экземпл€ра
        if (instance == null)
        { // Ёкземпл€р менеджера был найден
            instance = this; // «адаем ссылку на экземпл€р объекта
        }
        else if (instance != this)
        { // Ёкземпл€р объекта уже существует на сцене
            Destroy(gameObject); // ”дал€ем объект
        }  
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        inventory = GetComponent<Inventory>();
        
    }

    public void Buy(ButtonItemInfo buttonItemInfo)
    {
        
        //отн€ть деньги
        if (bitcoins >= buttonItemInfo.price)
        {
            audioPlayer.PlaySoundCoin();
            bitcoins -= buttonItemInfo.price;
            UpdateMyCoins();
            //убрать из магазина
            if (buttonItemInfo.amount > 1)
            {
                buttonItemInfo.MinusAmount();
            }
            else
            {
                Destroy(buttonItemInfo.gameObject);
            }

            //дать игроку предмет

            inventory.TakeItem(shop.allItems[buttonItemInfo.itemID]);
        }

    }

    public void Sell(ButtonItemInfo buttonItemInfo)
    {
        audioPlayer.PlaySoundCoin();
        //прибавить деньги
        bitcoins += buttonItemInfo.price;
        UpdateMyCoins();
        //убрать предмет у игрока
        inventory.RemoveItem(shop.allItems[buttonItemInfo.itemID]);
    }

    public void LoadNewScen(int sceneInt)
    {
        instance.inventory.buttonItemInfos.Clear();
        SceneManager.LoadScene(sceneInt);
    }

    public void LoadNewScenRandom()
    {
        instance.inventory.buttonItemInfos.Clear();
        int rand = Random.Range(0, 2);
        Debug.Log(rand);
        if(rand == 0)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(4);
    }

    public void UpdateMyCoins()
    {
        myCoins.text = bitcoins.ToString();
    }
}
