using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class Inventory : MonoBehaviour
{

    public List<Item> myItems;
    public List<ButtonItemInfo> buttonItemInfos;

    public GameObject buttonItem;
    public Transform _parent;

    void Start()
    {
       UpdateMyItems();
    }

    public void UpdateMyItems()
    {
        //������, � ������ ������ �� ���������, ���� ������ ��� - �������, ����� �� ���������, � ������ �������� ����������!
        Debug.Log("UdateItems");
        foreach (Item _item in myItems)
        {
            bool hasButtonItem = buttonItemInfos.Any(x => x.itemID == _item.ID); ; //���� �� ��� ������ � ����� ���������?  

            //������ ����� ���
            if (hasButtonItem == false)
            {
                GameObject _buttonItem = Instantiate(buttonItem);

                _buttonItem.GetComponent<ButtonItemInfo>().icon.sprite = _item.icon;
                _buttonItem.GetComponent<ButtonItemInfo>().price = _item.price / 3;
                _buttonItem.GetComponent<ButtonItemInfo>().nameItem.text = _item.itemName;
                _buttonItem.GetComponent<ButtonItemInfo>().amount = _item.amount;
                _buttonItem.GetComponent<ButtonItemInfo>().itemID = _item.ID;
                _buttonItem.GetComponent<ButtonItemInfo>().isBuyButton = false;
                _buttonItem.transform.SetParent(_parent);

                buttonItemInfos.Add(_buttonItem.GetComponent<ButtonItemInfo>());
            }
            //���� ��� ���� ������
            else
            {
                ButtonItemInfo item = buttonItemInfos.Find(x => x.itemID == _item.ID);
                item.amount = _item.amount;
                item.UpdateAmount();
            }

        }
    }

    public void TakeItem(Item newItem)
    {
        //���� �� � ��� ����� �������?
        bool hasItem = myItems.Any(x => x.ID == newItem.ID);

        //���� ����, �� �������
        if (hasItem == false)
        {
            myItems.Add(newItem);
        }
        newItem.amount++;
        UpdateMyItems();
    }

    public void RemoveItem(Item removeItem)
    {
        if(removeItem.amount < 2)
        {
            myItems.Remove(removeItem);
            ButtonItemInfo item = buttonItemInfos.Find(x => x.itemID == removeItem.ID);
            buttonItemInfos.Remove(item);
            Destroy(item.gameObject);
        }
        removeItem.amount--;
        UpdateMyItems();
    }
}
