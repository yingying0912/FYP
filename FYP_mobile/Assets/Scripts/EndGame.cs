using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    bool isTriggered = false;
    bool isTriggering = false;

    [SerializeField] GameObject seed;
    [SerializeField] Transform player;
    [SerializeField] GameObject dialogue;
    [SerializeField] GameObject endPanel;

    private void OnTriggerEnter(Collider other)
    {
        Game.gameStart = false;
        isTriggered = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered)
        {
            if (!isTriggering)
            {
                isTriggering = true;
                isTriggered = false;
                seed.transform.LookAt(player);
                dialogue.SetActive(true);
                dialogue.GetComponentInChildren<Text>().text = "Well done!";

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "You are now able\nto kill the virus\nby yourself.", 2f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Our trip comes\nto the end.", 4f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Please remember\nthe steps of\nhand washing.", 6f);
                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Now, let's go back.", 8f);

                this.Invoke(() => endPanel.SetActive(true), 9f);
            }
        }
    }
}
