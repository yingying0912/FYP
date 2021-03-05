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
    [SerializeField] AudioSource audio;
    [SerializeField] AudioClip[] clips;

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
                audio.PlayOneShot(clips[0]);

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "You are now able\nto kill the virus\nby yourself.", 2f);
                this.Invoke(() => audio.PlayOneShot(clips[1]), 2f);

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Our trip has\ncomes to\nthe end.", 5f);
                this.Invoke(() => audio.PlayOneShot(clips[2]), 5f);

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Please remember\nthe steps of\nhand washing.", 8f);
                this.Invoke(() => audio.PlayOneShot(clips[3]), 8f);

                this.Invoke(() => dialogue.GetComponentInChildren<Text>().text = "Now, let's go back.", 11f);
                this.Invoke(() => audio.PlayOneShot(clips[4]), 11f);

                this.Invoke(() => endPanel.SetActive(true), 13f);
            }
        }
    }
}
