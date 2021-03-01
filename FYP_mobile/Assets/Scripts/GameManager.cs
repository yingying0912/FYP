using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject loseUI;
    [SerializeField] GameObject winUI;
    public enum GameStatus {pause, start, lose, win};

    static public GameStatus gameState;

    WashHandLoop washHand;

    // Start is called before the first frame update
    void Start()
    {
        washHand = this.GetComponent<WashHandLoop>();
        washHand.enabled = false;

        gameState = GameStatus.pause;
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameStatus.pause:
                if (washHand.enabled)
                {
                    washHand.setInactive();
                    washHand.enabled = false;
                }
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
