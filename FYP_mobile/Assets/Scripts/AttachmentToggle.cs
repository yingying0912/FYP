using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachmentToggle : MonoBehaviour
{
    List<GameObject> Bacterium_ = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        Bacterium_ = gameObject.GetComponent<CheckClean>().Bacterium;
    }

    public void setBacteriaActive()
    {
        foreach (GameObject bacteria in Bacterium_)
            bacteria.SetActive(true);
    }

    public void setBacteriaInactive()
    {
        foreach (GameObject bacteria in Bacterium_)
            bacteria.SetActive(false);
    }
}
