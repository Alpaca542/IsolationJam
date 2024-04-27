using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject[] buildingPrefabs;
    public bool IsBuildingStarted = false;
    public GameObject CurrentBuilding;
    public void OnBuildingStart(int BuildingNumber)
    {
        IsBuildingStarted = true;
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        CurrentBuilding = Instantiate(buildingPrefabs[BuildingNumber], mouseWorldPos, Quaternion.identity);
        CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 100);
    }
    private void Update()
    {
        if (IsBuildingStarted)
        {
            Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            CurrentBuilding.transform.position = mouseWorldPos;
            if (CurrentBuilding.GetComponent<BuildingTriggerDetector>().AmITriggered)
            {
                CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(255, 0, 0, 100);
            }
            else
            {
                CurrentBuilding.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 0, 100);
            }
            if (Input.GetMouseButton(0))
            {
                if (!CurrentBuilding.GetComponent<BuildingTriggerDetector>().AmITriggered)
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
