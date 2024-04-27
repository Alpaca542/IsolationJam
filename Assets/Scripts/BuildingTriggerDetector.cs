using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTriggerDetector : MonoBehaviour
{
    public bool AmITriggered;
    private void OnTriggerStay2D(Collider2D collision)
    {
        AmITriggered = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        AmITriggered = false;
    }
}
