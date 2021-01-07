using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GameStatus { start, lose, win};

    static GameStatus gameState;

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
                break;
            case GameStatus.win:
                break;
        }
    }
}
