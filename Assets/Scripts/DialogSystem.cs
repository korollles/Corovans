using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogSystem : MonoBehaviour
{
    public TMP_Text dialogPanel;

    public int randomMilk;
    public int randomBitCoins;

    public GameObject spDefault;
    public GameObject spLose;

    public GameObject panelPuttons;

    void Start()
    {
        randomMilk = Random.Range(1, 99);
        randomBitCoins = Random.Range(1, 200000);

        dialogPanel.text = "Paid entrance. Pay with " + randomMilk + " milk or " + randomBitCoins + " bitcoins. Now!";
    }

    public void GiveMilk()
    {
        Item item = GameManager.instance.inventory.myItems.Find(x => x.ID == 1);
        if (item != null )
        {
            if (item.amount >= randomMilk)
            {
                Win("Good milk! Meeeeooow. Go!");
            }
            else
            {
                Lose("Very little milk. Say goodbye to life!");
            }
        }
        else
        {
            Lose("Lier! You have no milk. Goodbye.");
        }
    }

    public void GiveBitcoins()
    {
        
        if (GameManager.instance.bitcoins >= randomBitCoins)
        {
            GameManager.instance.bitcoins -= randomBitCoins;
            GameManager.instance.UpdateMyCoins();
            Win("OK! This time, bitcoins saved you. But we'll meet again.");
        }
        else
        {
            Lose("Did you want to deceive me? Now you will die!");
        }
    }

    public void RandomeLoseOrWin()
    {
        int rand = Random.Range(0, 4);

        switch (rand)
        {
            case 0:
                Lose("An honest answer and an honest death!");
                break;

            case 1:
                Lose("Is your head worth anything? Let's check!");
                break;

            case 2:
                Win("I'm very kind. Leave!");
                break;

            case 3:
                Win("You are so pathetic. This time I changed my mind about killing you.");
                break;
        }
    }

    public void Lose(string loseText)
    {
        dialogPanel.text = loseText;
        spDefault.SetActive(false);
        spLose.SetActive(true);
        StartCoroutine(coroutineLose());
    }

    public void Win(string winText)
    {
        dialogPanel.text = winText;
        StartCoroutine(coroutineWin());
    }

    IEnumerator coroutineWin()
    {
        // wait for 1 second
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(3);

        yield return null;
    }

    IEnumerator coroutineLose()
    {
        panelPuttons.SetActive(false);
        List<Item> items;
        items = GameManager.instance.inventory.myItems;
        foreach (Item item in items)
            item.amount = 0;
        GameManager.instance.inventory.myItems.Clear();
        // wait for 1 second
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(0);

        yield return null;
    }
}
