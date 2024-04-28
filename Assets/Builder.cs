using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class Builder : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public LayerMask groundlayer;
    public LayerMask UiLayer;
    public bool IsBuildingStarted = false;
    public GameObject CurrentBuilding;
    public void OnBuildingStart(int BuildingNumber)
    {
        Destroy(CurrentBuilding);
        IsBuildingStarted = true;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CurrentBuilding = Instantiate(buildingPrefabs[BuildingNumber], mouseWorldPos, Quaternion.identity);
        CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 100);
    }
    private void Update()
    {
        if (IsBuildingStarted)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.down, 10f, groundlayer);
            CurrentBuilding.transform.position = new Vector2(hit1.point.x, hit1.point.y+CurrentBuilding.GetComponent<SpriteRenderer>().size.y/2f+0.4f);
            Debug.Log(hit1.point.y);
            if (CurrentBuilding.GetComponent<BuildingTriggerDetector>().AmITriggered || EventSystem.current.IsPointerOverGameObject())
            {
                CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 100);
            }
            else
            {
                CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 100);
            }
            if (Input.GetMouseButton(0))
            {
                if (!CurrentBuilding.GetComponent<BuildingTriggerDetector>().AmITriggered && !EventSystem.current.IsPointerOverGameObject())
                {
                    CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                    CurrentBuilding.GetComponent<BoxCollider2D>().isTrigger = false;
                    IsBuildingStarted = false;
                    CurrentBuilding = null;
                }
            }
        }
    }
}
