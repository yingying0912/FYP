using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject startDialogue;
    Transform[] startDialogues;
    [SerializeField] GameObject playDialogue;
    Transform[] playDialogues;
    [SerializeField] GameObject endDialogue;
    Transform[] endDialogues;

    [SerializeField] GameObject virus;

    [SerializeField] Image cleanSlider;

    [SerializeField] GameObject washHandVideo;
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip[] videos;
    int currentGes = -1;

    [SerializeField] GameObject buttonPanel;

    bool playTutorial = false;
    bool endTutorial = false;
    bool chat = false;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameState = GameManager.GameStatus.tutorial;

        washHandVideo.SetActive(false);

        startDialogues = startDialogue.GetComponentsInChildren<Transform>(true);
        playDialogues = playDialogue.GetComponentsInChildren<Transform>(true);
        endDialogues = endDialogue.GetComponentsInChildren<Transform>(true);

        Debug.Log(startDialogues.Length);

        //cleanSlider.enabled = false;

        StartCoroutine("StartTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        //if (cleanSlider.enabled)
        // cleanSlider.fillAmount = (float)CheckClean.CleanedNum / (float)CheckClean.totalClean;
        
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
            yield return new WaitForSeconds(3);
        }

        startDialogues[startDialogues.Length - 1].gameObject.SetActive(false);
        startDialogues[1].gameObject.SetActive(false);
        virus.SetActive(false);

        GameManager.gameState = GameManager.GameStatus.start;

        washHandVideo.SetActive(true);

        playTutorial = true;

        yield return null;

        /*
        Debug.Log("cp4");
        //cleanSlider.enabled = true;
        */
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

            playDialogues[currentGes + 2].gameObject.SetActive(true);

            videoPlayer.clip = videos[currentGes];
            videoPlayer.isLooping = true;
            videoPlayer.SetDirectAudioMute(0, true);
            videoPlayer.Play();
        }

        if (WashHandLoop.loopOnce)
        {
            playTutorial = false;
            playDialogues[1].gameObject.SetActive(false);
            playDialogues[playDialogues.Length - 1].gameObject.SetActive(false);

            GameManager.gameState = GameManager.GameStatus.tutorial;
            washHandVideo.SetActive(false);
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
            this.Invoke(() => endDialogues[2].gameObject.GetComponent<Text>().text = "Now you are ready!", 4);
            this.Invoke(() => endDialogues[2].gameObject.GetComponent<Text>().text = "Lets' go!", 6);

            this.Invoke(() => buttonPanel.SetActive(true), 7);
        }
    }
}