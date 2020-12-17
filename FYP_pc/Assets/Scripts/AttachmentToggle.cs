using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentToggle : MonoBehaviour
{
    public GameObject gameObject;
    public string bacteriaTag;
    GameObject[] Bacterium;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Bacterium = GameObject.FindGameObjectsWithTag(bacteriaTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!gameObject.active)
                gameObject.SetActive(true);
            else
                gameObject.SetActive(false);
        }
        
        if (!gameObject.active)
        {
            foreach (GameObject bacteria in Bacterium)
                bacteria.SetActive(false);
        }
        else
        {
            foreach (GameObject bacteria in Bacterium)
                bacteria.SetActive(true);
        }

    }
}
