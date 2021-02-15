using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaTrigger : MonoBehaviour
{
    public int TriggeredNum;

    private void Start()
    {
        TriggeredNum = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        TriggeredNum += 1; 
    }
}
