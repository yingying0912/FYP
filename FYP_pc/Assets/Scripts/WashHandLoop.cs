﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashHandLoop : MonoBehaviour
{
    [SerializeField]GameObject[] HandGestures;
    int currentGesture;

    // Start is called before the first frame update
    void Start()
    {
        currentGesture = 0;
        HandGestures[currentGesture].SetActive(true);
        HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaActive();
        for (int i = 1; i < HandGestures.Length; i++)
        {
            HandGestures[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HandGestures[currentGesture].GetComponent<CheckClean>().isCleaned)
        {
            gameObject.GetComponent<ChargeEnergy>().Charging();
            HandGestures[currentGesture].SetActive(false);
            HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaInactive();
            HandGestures[currentGesture].GetComponent<CheckClean>().isCleaned = false;
            
            currentGesture += 1;
            if (currentGesture >= HandGestures.Length)
                currentGesture -= HandGestures.Length;

            HandGestures[currentGesture].SetActive(true);
            HandGestures[currentGesture].GetComponent<AttachmentToggle>().setBacteriaActive();
        }
    }
}