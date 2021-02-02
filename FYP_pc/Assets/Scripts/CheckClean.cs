using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckClean : MonoBehaviour
{
    public List<GameObject> Bacterium = new List<GameObject>();
    List<BacteriaTrigger> BacteriaTriggered = new List<BacteriaTrigger>();
    public bool isCleaned;
    public static int CleanedNum;
    [SerializeField] int cleanConstant;

    public static int totalClean;
    
    // Start is called before the first frame update
    void Awake()
    {
        isCleaned = false;
        CleanedNum = 0;
        for (int i = 0; i < Bacterium.Count; i++)
            BacteriaTriggered.Add(Bacterium[i].GetComponent<BacteriaTrigger>());

        totalClean = BacteriaTriggered.Count;
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
