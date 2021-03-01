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

    bool loop1 = false;

    private void OnTriggerEnter(Collider other)
    {
        eventName = this.gameObject.name;
        Game.gameStart = false;
        TestPath();
    }

    private void Update()
    {
        switch (eventName)
        {
            case "Marker1":
                Event1();
                break;
            case "Marker2":
                Event2();
                break;
            case "Marker3":
                Event3();
                break;
            case "Marker4":
                Event4();
                break;
            case "Marker5":
                Event5();
                break;
        }
        
    }

    void Event1()
    {
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                Initialization();
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
                line.enabled = true;

                this.Invoke(() => line.enabled = false, 1.5f);
                this.Invoke(() => counter++, 1.5f);
                this.Invoke(() => enemies[counter - 1].SetActive(false), 1.5f);
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => Game.gameStart = true, 1f);
                seed.transform.rotation = new Quaternion(0, 0, 0, 1);
            }
        } 
    }

    void Event2()
    {
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                Initialization();
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => line.enabled = false, 1.5f);

                if (currentGes % 3 == 0)
                {
                    this.Invoke(() => counter++, 1.5f);
                    this.Invoke(() => enemies[counter - 1].SetActive(false), 1.5f);
                }
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => Game.gameStart = true, 1f);
                seed.transform.rotation = new Quaternion(0, 0, 0, 1);
            }
        }
    }

    void Event3()
    {
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                Initialization();
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => line.enabled = false, 1.5f);
            }


            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => enemies[counter].SetActive(false), 1.5f);

                this.Invoke(() => Game.gameStart = true, 2f);
                this.Invoke(() => seed.transform.rotation = new Quaternion(0, 0, 0, 1), 2f);
            }
        }
    }
    
    void Event4()
    {
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                Initialization();
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => line.enabled = false, 1.5f);
            }


            if (WashHandLoop.loopOnce && !loop1)
            {
                loop1 = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                this.Invoke(() => counter++, 1.5f);
                this.Invoke(() => enemies[counter - 1].SetActive(false), 1.5f);

                //dialogue out
                this.Invoke(() => dialogue.SetActive(true), 2f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Look! There is\nanother virus at\nyour back!", 2f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Try to kill it\nwithout my\nguidance.", 4f);

                this.Invoke(() => loop1 = true, 4.5f);
                this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 4.5f);
            }

            if (WashHandLoop.loopOnce && loop1)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => enemies[counter].SetActive(false), 1.5f);

                this.Invoke(() => Game.gameStart = true, 2f);
                this.Invoke(() => seed.transform.rotation = new Quaternion(0, 0, 0, 1), 2f);
            }

        }
    }

    void Event5()
    {

    }

    void Initialization()
    {
        seed.transform.LookAt(player);
        for (int i = 0; i < eventObject.transform.childCount; i++)
        {
            enemies.Add(eventObject.transform.GetChild(i).gameObject);
        }
        this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 5);
        isInitialized = true;
        counter = 0;
    }

    void TestPath()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            seed.transform.LookAt(player);
            Debug.Log("current marker" + Game.currentMarker);
            Game.currentMarker++;
            this.Invoke(() => seed.transform.Rotate(0, 180, 0), 1f);
            this.Invoke(() => Game.gameStart = true, 1f);
        }
    }
}
