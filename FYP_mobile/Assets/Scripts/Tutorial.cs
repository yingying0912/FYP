using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject startDialogue;
    Transform[] startDialogues;
    [SerializeField] GameObject endDialogue;
    Transform[] endDialogues;

    [SerializeField] GameObject virus;

    [SerializeField] Image cleanSlider;
    [SerializeField] GameObject washHandVideo;

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip[] videos;
    int currentGes = -1;

    [SerializeField] GameObject buttonPanel;

    bool isInvoking = false;

    float lastDialogueWaitingTime = 2f;
    float endUIWaitingTime = 5f;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.gameState = GameManager.GameStatus.tutorial;

        washHandVideo.SetActive(false);

        startDialogues = startDialogue.GetComponentsInChildren<Transform>(true);
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

        yield return null;

        /*
        Debug.Log("cp4");
        //cleanSlider.enabled = true;
        */
    }

    IEnumerator PlayTutorial()
    {
        GameManager.gameState = GameManager.GameStatus.start;

        washHandVideo.SetActive(true);

        while (true)
        {
            if (currentGes != WashHandLoop.currentGesture)
            {
                currentGes = WashHandLoop.currentGesture;

                videoPlayer.clip = videos[currentGes];
                videoPlayer.isLooping = true;
                videoPlayer.SetDirectAudioMute(0, true);
                videoPlayer.Play();
            }

            if (WashHandLoop.loopOnce)
            {
                GameManager.gameState = GameManager.GameStatus.tutorial;
                washHandVideo.SetActive(false);

                break;
            }
        }
        yield return null;
    }
}




