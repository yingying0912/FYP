using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTriggered : MonoBehaviour
{
    [SerializeField] GameObject seed;
    
    [SerializeField] GameObject eventObject;
    Transform[] enemies;

    string eventName;
    bool isTriggered = false;
    bool isInitialized = false;
    int counter;
    int currentGes = 0;

    private void OnTriggerEnter(Collider other)
    {
        eventName = other.gameObject.name;
        Game.gameStart = false;
    }

    private void Update()
    {
        switch (eventName)
        {
            case "Event1":
                Event1();
                break;
        }
    }

    void Event1()
    {
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                seed.transform.rotation = new Quaternion(18.4f, 202.6f, 4f, 1);
                enemies = eventObject.GetComponentsInChildren<Transform>(true);
                GameManager.gameState = GameManager.GameStatus.start;
                isInitialized = true;
                counter = 1;
            }

            if (counter < enemies.Length)
            {
                enemies[counter].gameObject.SetActive(true);
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;
                enemies[counter].gameObject.SetActive(false);
                counter++;
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
            }
        } 
    }
}
