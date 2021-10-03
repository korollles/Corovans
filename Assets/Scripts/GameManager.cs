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
        // ������, ��������� ������������� ����������
        if (instance == null)
        { // ��������� ��������� ��� ������
            instance = this; // ������ ������ �� ��������� �������
        }
        else if (instance != this)
        { // ��������� ������� ��� ���������� �� �����
            Destroy(gameObject); // ������� ������
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
        
        //������ ������
        if (bitcoins >= buttonItemInfo.price)
        {
            audioPlayer.PlaySoundCoin();
            bitcoins -= buttonItemInfo.price;
            UpdateMyCoins();
            //������ �� ��������
            if (buttonItemInfo.amount > 1)
            {
                buttonItemInfo.MinusAmount();
            }
            else
            {
                Destroy(buttonItemInfo.gameObject);
            }

            //���� ������ �������

            inventory.TakeItem(shop.allItems[buttonItemInfo.itemID]);
        }

    }

    public void Sell(ButtonItemInfo buttonItemInfo)
    {
        audioPlayer.PlaySoundCoin();
        //��������� ������
        bitcoins += buttonItemInfo.price;
        UpdateMyCoins();
        //������ ������� � ������
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
