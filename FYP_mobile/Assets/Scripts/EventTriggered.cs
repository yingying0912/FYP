using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DigitalRuby.LightningBolt;

public class EventTriggered : MonoBehaviour
{
    [SerializeField] GameObject seed;
    [SerializeField] GameObject dialogue;
    [SerializeField] Transform player;

    [SerializeField] LightningBoltScript lightning;
    [SerializeField] LineRenderer line;
    
    [SerializeField] GameObject eventObject;
    List<GameObject> enemies = new List<GameObject>();

    string eventName;
    bool isTriggered = false;
    bool isInitialized = false;
    bool ischat = false;
    int counter;
    int currentGes = 0;

    private void OnTriggerEnter(Collider other)
    {
        eventName = this.gameObject.name;
        Game.gameStart = false;
        //Event1();
    }

    private void Update()
    {
        switch (eventName)
        {
            case "Marker1":
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
                seed.transform.LookAt(player);
                for (int i = 0; i < eventObject.transform.childCount; i++)
                {
                    Debug.Log(eventObject.transform.GetChild(i).gameObject);
                    enemies.Add(eventObject.transform.GetChild(i).gameObject);
                }
 
                isInitialized = true;
                counter = 0;
            }

            if (!ischat)
            {
                ischat = true;
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<Text>().text = "See! There is\na virus.";
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Wash your hands\nto kill it.", 2);
                this.Invoke(() => dialogue.SetActive(false), 4);

                this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 5);
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
                Debug.Log(enemies[counter].gameObject.name);
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                lightning.EndPosition.y = lightning.EndObject.transform.position.y + 0.2f;
                line.enabled = true;

                this.Invoke(() => enemies[counter].SetActive(false), 1.5f);
                this.Invoke(() => line.enabled = false, 1.5f);
                counter++;
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;
                Game.gameStart = true;
                seed.transform.rotation = new Quaternion(0, 0, 0, 1);
            }
        } 
    }
}
