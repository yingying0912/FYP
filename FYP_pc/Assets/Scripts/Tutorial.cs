using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] dialogues;
    float dialoguesWaitingTime;

    [SerializeField] Image cleanSlider;
    [SerializeField] GameObject washHandVideo;

    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoClip[] videos;

    [SerializeField] GameObject buttonPanel;

    float lastDialogueWaitingTime = 2f;
    float endUIWaitingTime = 5f;
    float currentTime = 0;

    // Start is called before the first frame update
    void Awake()
    {
        washHandVideo.SetActive(false);

        dialoguesWaitingTime = 3.0f;

        cleanSlider.enabled = false;

        StartCoroutine(DisplayDialogue(dialoguesWaitingTime)); 

    }

    // Update is called once per frame
    void Update()
    {
        if (cleanSlider.enabled)
            cleanSlider.fillAmount = (float)CheckClean.CleanedNum / (float)CheckClean.totalClean;

        if (washHandVideo.activeSelf)
        {
            videoPlayer.clip = videos[WashHandLoop.currentGesture];
            videoPlayer.isLooping = true;
            videoPlayer.SetDirectAudioMute(0, true);
            videoPlayer.Play();
        }

        if (WashHandLoop.loopOnce)
        {
            GameManager.gameState = GameManager.GameStatus.tutorial;
            washHandVideo.SetActive(false);
            cleanSlider.enabled = false;

            currentTime += Time.deltaTime;
            if (currentTime >= lastDialogueWaitingTime)
            {
                dialogues[dialogues.Length - 2].SetActive(false);
                dialogues[dialogues.Length - 1].SetActive(true);
            }
            
            /*
            if (currentTime >= lastDialogueWaitingTime * 2)
            {
                dialogues[dialogues.Length - 22].SetActive(false);
                dialogues[dialogues.Length - 1].SetActive(true);
            }
            */
                
            if (currentTime >= endUIWaitingTime)
                buttonPanel.SetActive(true);
        }
    }

    IEnumerator DisplayDialogue(float time)
    {
        for (int i = 0; i < dialogues.Length - 1; i++)
        {
            if (i != 0)
            {
                dialogues[i - 1].SetActive(false);
            }

            dialogues[i].SetActive(true);
            yield return new WaitForSeconds(time);
        }

        GameManager.gameState = GameManager.GameStatus.start;

        washHandVideo.SetActive(true);

        cleanSlider.enabled = true;

        yield return null;     
    }
}
