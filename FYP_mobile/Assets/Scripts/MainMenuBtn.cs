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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (transform.name == "QuitBtn")
        {
            Application.Quit();
        }
        else if (transform.name == "ReturnBtn")
        {
            SceneManager.LoadScene(0);
        }
    }
}
