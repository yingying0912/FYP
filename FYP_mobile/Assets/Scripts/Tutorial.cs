using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject startDialogue;
    Transform[] startDialogues;
    [SerializeField] AudioClip[] sd_audio;

    [SerializeField] GameObject playDialogue;
    Transform[] playDialogues;
    [SerializeField] AudioClip[] pd_audio;

    [SerializeField] GameObject endDialogue;
    Transform[] endDialogues;
    [SerializeField] AudioClip[] ed_audio;

    [SerializeField] AudioSource audioSource;

    [SerializeField] GameObject virus;

    int currentGes = -1;

    [SerializeField] GameObject buttonPanel;

    bool playTutorial = false;
    bool endTutorial = false;
    bool chat = false;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameState = GameManager.GameStatus.pause;

        startDialogues = startDialogue.GetComponentsInChildren<Transform>(true);
        playDialogues = playDialogue.GetComponentsInChildren<Transform>(true);
        endDialogues = endDialogue.GetComponentsInChildren<Transform>(true);

        StartCoroutine("StartTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playTutorial)
        {
            PlayTutorial();
        }

        if (endTutorial)
        {
            EndTutorial();
        }
    }

    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(2);
        startDialogues[1].gameObject.SetActive(true);


        for (int i = 2; i < startDialogues.Length; i++)
        {
            if (i > 2)
            {
                startDialogues[i - 1].gameObject.SetActive(false);
            }

            if (i == 6)
                virus.SetActive(true);

            startDialogues[i].gameObject.SetActive(true);
            audioSource.PlayOneShot(sd_audio[i - 2]);

            if (i < 6)
                yield return new WaitForSeconds(2);
            else
                yield return new WaitForSeconds(5);
        }

        startDialogues[startDialogues.Length - 1].gameObject.SetActive(false);
        startDialogues[1].gameObject.SetActive(false);
        virus.SetActive(false);

        GameManager.gameState = GameManager.GameStatus.start;

        playTutorial = true;

        yield return null;

    }

    void PlayTutorial()
    {
        playDialogues[1].gameObject.SetActive(true);

        if (currentGes != WashHandLoop.currentGesture)
        {
            currentGes = WashHandLoop.currentGesture;

            if (currentGes > 0)
            {
                playDialogues[currentGes + 1].gameObject.SetActive(false);
            }

            if (!WashHandLoop.loopOnce)
            {
                playDialogues[currentGes + 2].gameObject.SetActive(true);
                this.Invoke(() => audioSource.PlayOneShot(pd_audio[currentGes]), 0.5f);
            }            
        }

        if (WashHandLoop.loopOnce)
        {
            playTutorial = false;
            playDialogues[playDialogues.Length - 1].gameObject.SetActive(false);
            playDialogues[1].gameObject.SetActive(false);
            playDialogue.SetActive(false);

            GameManager.gameState = GameManager.GameStatus.pause;

            endTutorial = true;
        }
    }

    void EndTutorial()
    {
        if (!chat)
        {
            chat = true;

            endDialogues[1].gameObject.SetActive(true);
            this.Invoke(() => endDialogues[2].gameObject.SetActive(true), 2);

            this.Invoke(() => endDialogues[2].gameObject.GetComponent<Text>().text = "Congratulations!", 2);
            this.Invoke(() => audioSource.PlayOneShot(ed_audio[0]), 2);

            this.Invoke(() => endDialogues[2].gameObject.GetComponent<Text>().text = "Now you are ready!", 4);
            this.Invoke(() => audioSource.PlayOneShot(ed_audio[1]), 4);

            this.Invoke(() => endDialogues[2].gameObject.GetComponent<Text>().text = "Lets' go!", 6);
            this.Invoke(() => audioSource.PlayOneShot(ed_audio[2]), 6);

            this.Invoke(() => buttonPanel.SetActive(true), 7);
        }
    }
}