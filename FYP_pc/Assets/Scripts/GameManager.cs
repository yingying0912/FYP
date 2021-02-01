using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;
     public enum GameStatus { start, lose, win};

    static public GameStatus gameState;

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
            case GameStatus.start:
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
