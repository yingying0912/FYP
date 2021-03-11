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

    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] clips;

    Animator enemyAnim;

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
        Game.gameStart = false;
        eventName = this.gameObject.name;
        //TestPath();
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
            default:
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
                audio.PlayOneShot(clips[0]);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Wash your hands\nto kill it.", 2);
                this.Invoke(() => audio.PlayOneShot(clips[1]), 2);
                this.Invoke(() => dialogue.SetActive(false), 4);

                this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 5);
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
                enemyAnim = enemies[counter].GetComponent<Animator>();
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => enemyAnim.Play("Die"), 1f);
                this.Invoke(() => line.enabled = false, 1.5f);
                this.Invoke(() => counter++, 1.5f);

                this.Invoke(() => enemies[counter - 1].SetActive(false), 2f);
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => Game.gameStart = true, 3f);
                seed.transform.Rotate(0, 180, 0);
            }
        } 
    }

    void Event2()
    {
        //Debug.Log("Entering event 2");
        if (!isTriggered)
        {
            if (!isInitialized)
            {
                Initialization();
            }

            if (counter < enemies.Count)
            {
                enemies[counter].SetActive(true);
                enemyAnim = enemies[counter].GetComponent<Animator>();
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => line.enabled = false, 1.5f);

                if (currentGes % 3 == 0)
                {
                    this.Invoke(() => enemyAnim.Play("Die"), 1f);
                    this.Invoke(() => counter++, 1.5f);
                    this.Invoke(() => enemies[counter - 1].SetActive(false), 2f);
                }
                else
                {
                    this.Invoke(() => enemyAnim.Play("GetHit"), 1f);
                }
            }

            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => Game.gameStart = true, 3f);
                seed.transform.Rotate(0, 180, 0);
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
                enemyAnim = enemies[counter].GetComponent<Animator>();
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => enemyAnim.Play("GetHit"), 1f);
                this.Invoke(() => line.enabled = false, 1.5f);
            }


            if (WashHandLoop.loopOnce)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => enemyAnim.Play("Die"), 1f);
                this.Invoke(() => enemies[counter].SetActive(false), 2f);

                this.Invoke(() => Game.gameStart = true, 3f);
                this.Invoke(() => seed.transform.Rotate(0, 180, 0), 3f);
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
                enemyAnim = enemies[counter].GetComponent<Animator>();
            }

            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                lightning.EndObject = enemies[counter];
                line.enabled = true;

                this.Invoke(() => enemyAnim.Play("GetHit"), 1f);
                this.Invoke(() => line.enabled = false, 1.5f);
            }


            if (WashHandLoop.loopOnce && !loop1)
            {
                loop1 = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                this.Invoke(() => enemyAnim.Play("Die"), 1f);
                this.Invoke(() => counter++, 1.5f);
                this.Invoke(() => enemies[counter - 1].SetActive(false), 2f);

                //dialogue out
                this.Invoke(() => dialogue.SetActive(true), 3f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Look! There is\nanother virus\nbehind you!", 3f);
                this.Invoke(() => audio.PlayOneShot(clips[0]), 3f); 

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Try to kill it\nwithout my\nguidance.", 6f);
                this.Invoke(() => audio.PlayOneShot(clips[1]), 6f);

                this.Invoke(() => dialogue.SetActive(false), 8f);

                this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 6.5f);
                WashHandLoop.loopOnce = false;
            }

            if (WashHandLoop.loopOnce && loop1)
            {
                isTriggered = true;
                GameManager.gameState = GameManager.GameStatus.pause;
                Game.currentMarker++;

                this.Invoke(() => enemyAnim.Play("Die"), 1f);
                this.Invoke(() => enemies[counter].SetActive(false), 2f);

                this.Invoke(() => Game.gameStart = true, 3f);
                this.Invoke(() => seed.transform.Rotate(0, 180, 0), 3f);
            }

        }
    }

    void Initialization()
    {
        Reset();
        seed.transform.LookAt(player);
        for (int i = 0; i < eventObject.transform.childCount; i++)
        {
            enemies.Add(eventObject.transform.GetChild(i).gameObject);
        }
        this.Invoke(() => GameManager.gameState = GameManager.GameStatus.start, 5);
        isInitialized = true;
        counter = 0;
    }

    private void Reset()
    {
        isTriggered = false;
        isInitialized = false;
        WashHandLoop.loopOnce = false;
        currentGes = 0;
    }

    void TestPath()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            seed.transform.LookAt(player);
            Game.currentMarker++;
            this.Invoke(() => seed.transform.Rotate(0, 180, 0), 1f);
            this.Invoke(() => Game.gameStart = true, 1f);
        }
    }
}
