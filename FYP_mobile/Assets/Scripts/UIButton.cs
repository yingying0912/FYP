using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : MonoBehaviour
{
    public void Clicked(string btnName)
    {
        Debug.Log(btnName + " was clicked");
    }
}
