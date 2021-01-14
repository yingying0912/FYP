using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckClean : MonoBehaviour
{
    public List<GameObject> Bacterium = new List<GameObject>();
    List<BacteriaTrigger> BacteriaTriggered = new List<BacteriaTrigger>();
    public bool isCleaned;
    int CleanedNum;
    [SerializeField] int cleanConstant;
    
    // Start is called before the first frame update
    void Awake()
    {
        isCleaned = false;
        CleanedNum = 0;
        for (int i = 0; i < Bacterium.Count; i++)
            BacteriaTriggered.Add(Bacterium[i].GetComponent<BacteriaTrigger>());
    }

    // Update is called once per frame
    void Update()
    {
        CleanedNum = 0;
        isCleaned = false; 

        foreach (BacteriaTrigger bacteria in BacteriaTriggered)
        {
            if (bacteria.TriggeredNum >= cleanConstant)
                CleanedNum += 1;
        }

        if (CleanedNum == BacteriaTriggered.Count)
            isCleaned = true;

        if (isCleaned)
        {
            Debug.Log(name + " is Cleaned!");
            foreach (BacteriaTrigger bacteria in BacteriaTriggered)
            {
                bacteria.TriggeredNum = 0;
            }
        }
            
    }
}
