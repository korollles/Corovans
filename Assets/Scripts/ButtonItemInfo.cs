using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonItemInfo : MonoBehaviour
{
    public Image icon;
    public int itemID;
    public int price;
    public int amount;
    public TMP_Text priceText;
    public TMP_Text nameItem;
    public TMP_Text amountText;

    public bool isBuyButton = true;

    void Start()
    {
        priceText.text = price.ToString();
        amountText.text = "x" + amount.ToString();

        if(isBuyButton == true)
            GetComponent<Button>().onClick.AddListener(ClickBuy);
        else
            GetComponent<Button>().onClick.AddListener(ClickSell);
    }
    
    public void UpdateAmount()
    {
        amountText.text = "x" + amount.ToString();
    }

    public void MinusAmount()
    {
        amount--;
        amountText.text = "x" + amount.ToString();
    }

    void ClickBuy()
    {
        GameManager.instance.Buy(this);
    }

    void ClickSell()
    {
        GameManager.instance.Sell(this);
    }
}
