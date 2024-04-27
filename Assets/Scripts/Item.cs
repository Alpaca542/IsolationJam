using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public int amount;
    public Sprite Texture;
    private void OnTriggerEnter2D(Collider2D cld)
    {
        if(cld.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("InvMng").GetComponent<InventoryManager>().AddItem(this);
            Destroy(gameObject);
        }
    }
}
