using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject[] dialogues;
    float dialoguesWaitingTime;

    [SerializeField] Image cleanSlider;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.gameState = GameManager.GameStatus.tutorial;
        
        dialoguesWaitingTime = 3.0f;

        cleanSlider.enabled = false;

        StartCoroutine(DisplayDialogue(dialoguesWaitingTime));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cleanSlider.enabled)
            cleanSlider.fillAmount = (float)CheckClean.CleanedNum / (float)CheckClean.totalClean;
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

        cleanSlider.enabled = true;


        yield return null;     
    }
}
