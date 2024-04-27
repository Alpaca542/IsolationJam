using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
    public GameObject InventoryContent;
    public GameObject StandartButton;
    public GameObject Inventory;
    public void AddItem(Item tem)
    {
        bool appered = false;
        for (int i = 0; i < Items.Count; i++)
        {
            if (Items[i].id == tem.id)
            {
                appered = true;
                Items[i].amount += tem.amount;
                break;
            }
        }
        if(!appered)
        {
            Items.Add(tem);
        }
    }
    public void ListItems()
    {
        if (!Inventory.activeSelf)
        {
            Inventory.SetActive(true);
            foreach (Button itm in InventoryContent.GetComponentsInChildren<Button>())
            {
                Destroy(itm.gameObject);
            }
            foreach (Item item in Items)
            {
                GameObject itembtn = Instantiate(StandartButton, InventoryContent.transform);
                itembtn.GetComponentInChildren<ItemHolder>().gameObject.GetComponent<Image>().sprite = item.Texture;
                itembtn.GetComponentInChildren<Text>().text = "x" + item.amount.ToString();
            }
        }
        else
        {
            Inventory.SetActive(false);
        }
    }
}
