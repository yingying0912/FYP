using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;
    public enum GameStatus {tutorial, start, lose, win};

    static public GameStatus gameState;

    WashHandLoop washHand;

    // Start is called before the first frame update
    void Start()
    {
        washHand = this.GetComponent<WashHandLoop>();
        washHand.enabled = false;

        if (SceneManager.GetActiveScene().buildIndex == 0)
            gameState = GameStatus.tutorial;
        else
            gameState = GameStatus.start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStatus.tutorial:
                if (washHand.enabled)
                    washHand.enabled = false;
                break;
            case GameStatus.start:
                if (!washHand.enabled)
                    washHand.enabled = true;
                break;
            case GameStatus.lose:
                loseUI.SetActive(true);
                break;
            case GameStatus.win:
                winUI.SetActive(true);
                break;
        }
    }
}
