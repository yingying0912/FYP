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

    string[] videoName = { "FYP_1", "FYP_2", "FYP_3", "FYP_4", "FYP_5", "FYP_6", "FYP_7", "FYP_8", "FYP_9" };

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
            videoPlayer.clip.name = videoName[WashHandLoop.currentGesture];
            videoPlayer.isLooping = true;
            videoPlayer.SetDirectAudioMute(0, true);
        }
    }

    IEnumerator DisplayDialogue(float time)
    {
        for (int i = 0; i < dialogues.Length; i++)
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
