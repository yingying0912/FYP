using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentToggle : MonoBehaviour
{
    public GameObject[] gameObject;
    List<List<GameObject>> Bacterium_ = new List<List<GameObject>>();
    //GameObject[] Bacterium_ = CheckClean.Bacterium;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            Bacterium_.Add(gameObject[i].GetComponent<CheckClean>().Bacterium);
            //Bacterium_[i].AddRange(gameObject[i].GetComponent<CheckClean>().Bacterium);
            gameObject[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < gameObject.Length; i++)
        {
            if (!gameObject[i].active)
            {
                foreach (GameObject bacteria in Bacterium_[i])
                    bacteria.SetActive(false);
            }
            else
            {
                foreach (GameObject bacteria in Bacterium_[i])
                    bacteria.SetActive(true);
            }
        }
    }
}
