using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;
    public enum GameStatus {tutorial, start, lose, win};

    static public GameStatus gameState;

    [SerializeField] WashHandLoop washHand;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameStatus.start;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStatus.tutorial:
                washHand.enabled = false;
                break;
            case GameStatus.start:
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
