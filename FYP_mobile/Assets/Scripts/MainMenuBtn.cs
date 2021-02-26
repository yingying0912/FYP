using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBtn : MonoBehaviour
{
    public void BtnPressed()
    {
        if (transform.name == "StartBtn")
        {
            SceneManager.LoadScene(1);
        }
        else if (transform.name == "QuitBtn")
        {
            Application.Quit();
        }
    }
}
