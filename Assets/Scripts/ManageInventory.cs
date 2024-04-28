using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageInventory : MonoBehaviour
{
    public RectTransform ButtonSword;
    public RectTransform ButtonHammer;
    public void OnHammerChosen()
    {
        ButtonSword.localScale = new Vector3(0.74f, 0.74f, 1f);
        ButtonHammer.localScale = new Vector3(1f, 1f, 1f);
    }
    public void OnSwordChosen()
    {
        ButtonHammer.localScale = new Vector3(0.74f, 0.74f, 1f);
        ButtonSword.localScale = new Vector3(1f, 1f, 1f);
    }
}
