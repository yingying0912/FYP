using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour
{
    [SerializeField] GameObject startDialogue;
    Transform[] startDialogues;

    //bool isInvoking = false;

    // Start is called before the first frame update
    void Start()
    {
        startDialogues = startDialogue.GetComponentsInChildren<Transform>(true);
        StartCoroutine("StartTutorial");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!isInvoking)
        {
            Invoke("StartTutorial", 2f);
            isInvoking = true;
        }
        */
    }

    /*
    void StartTutorial()
    {
        //bool isInvoking2 = false;
        float currentTime = 0f;
        currentTime += Time.deltaTime;

        bool isInvoking2 = false;

        startDialogues[1].gameObject.SetActive(true);

        int i = 2;
        while (i < startDialogues.Length)
        {
            if (!isInvoking2)
            {
                startDialogues[i].gameObject.SetActive(true);
                isInvoking2 = true;
            }

            if (currentTime > 3 && isInvoking2)
            {
                startDialogues[i].gameObject.SetActive(false);
                isInvoking2 = false;
                currentTime = 0;
                i++;
            }
        }
    }
    */

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

            startDialogues[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
        }

        startDialogues[startDialogues.Length - 1].gameObject.SetActive(false);
        startDialogues[1].gameObject.SetActive(false);

        yield return null;
    }
}
