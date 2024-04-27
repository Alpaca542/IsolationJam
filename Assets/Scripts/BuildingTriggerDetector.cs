using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingTriggerDetector : MonoBehaviour
{
    public bool AmITriggered;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AmITriggered = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AmITriggered = false;
    }
}
