using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public Item[] allItems;

    public List<Item> shopItems;

    public GameObject buttonItem;
    public Transform _parent;


    // Start is called before the first frame update
    void Start()
    {
        //—оздаю случайную цену и добавл€ю кнопки в магазин
        foreach (Item _item in allItems)
        {
            _item.price = Random.Range(1, 10000);

            int yesOrNot = Random.Range(0, 2);
            if (yesOrNot == 1)
            {
                shopItems.Add(_item);
                GameObject _buttonItem = Instantiate(buttonItem);

                _buttonItem.GetComponent<ButtonItemInfo>().icon.sprite = _item.icon;
                _buttonItem.GetComponent<ButtonItemInfo>().price = _item.price;
                _buttonItem.GetComponent<ButtonItemInfo>().nameItem.text = _item.itemName;
                _buttonItem.GetComponent<ButtonItemInfo>().amount = Random.Range(0, 100);
                _buttonItem.GetComponent<ButtonItemInfo>().itemID = _item.ID;
                _buttonItem.GetComponent<ButtonItemInfo>().isBuyButton = true;
                _buttonItem.transform.SetParent(_parent);
            }       
        }
    }
}
