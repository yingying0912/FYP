using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;


public class HandGesture : MonoBehaviour
{
    public GameObject[] HandGestures;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Debug.Log("activated");
    }

    public void Deactivate()
    {
        Debug.Log("deactivated");
    }
}
