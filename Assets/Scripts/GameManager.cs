using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject player;
    public GameObject gameOver;
    public GameObject scoreText;
    public GameObject scoreNumber;
    public GameObject gameTitle;
    public GameObject bgController;
    public GameObject coinGenerator; 
    public GameObject obstacleGenerator;
    public GameObject HPimage;
    public GameObject HPscore;

    public enum GameManagerState
    {
        OPENING,
        GAMEPLAY,
        GAMEOVER
    }

    GameManagerState GMState;
    void Start()
    {
        GMState = GameManagerState.OPENING;
        UpdateGMState();
    }
    void UpdateGMState()
    {
        switch (GMState)
        {
            case GameManagerState.OPENING:
                gameOver.GetComponent<GameOver>().SwitchAnimation(false);
                gameTitle.GetComponent<titleScript>().SwitchAnimation(true);
                StartCoroutine(EnableOpening());

               
                break;
            case GameManagerState.GAMEPLAY:
                buttonPlay.SetActive(false);
                gameTitle.GetComponent<titleScript>().SwitchAnimation(false);

                StartCoroutine(EnableGameplay());
                break;
            case GameManagerState.GAMEOVER:
                obstacleGenerator.GetComponent<ObstacleGenerator>().StopSpawn();
                coinGenerator.GetComponent<CoinGenerator>().StopSpawn();
                bgController.GetComponent<BGController>().StopScrolling();

                StartCoroutine(EnableGameover());

                HPimage.SetActive(false);
                HPscore.SetActive(false);
                scoreText.SetActive(false);
                scoreNumber.SetActive(false);

                gameOver.GetComponent<GameOver>().SwitchAnimation(true);
                Invoke("ChangeToOpening", 5f);
                break;
            default:
                break;
        }
    }
    public void SetGMState(GameManagerState state)
    {
        GMState = state;
        UpdateGMState();
    }

    public void StartGamePlay()
    {
        SetGMState(GameManagerState.GAMEPLAY);
    }

    IEnumerator EnableGameplay()
    {
        yield return new WaitForSeconds(1.65f);

        obstacleGenerator.GetComponent<ObstacleGenerator>().StartSpawn();
        coinGenerator.GetComponent<CoinGenerator>().StartSpawn();
      
        player.SetActive(true);
        player.transform.position = new Vector3(-5.63f, -4.24f, -0.15f);

        scoreText.SetActive(true);
        scoreNumber.SetActive(true);
        scoreNumber.GetComponent<GameScore>().Score = 0;

        HPscore.SetActive(true);
        HPimage.SetActive(true);
        HPscore.GetComponent<HPscore>().Score = 3;
    }

    IEnumerator EnableOpening()
    {
        yield return new WaitForSeconds(1.6f);
        buttonPlay.SetActive(true);
        bgController.GetComponent<BGController>().StartScrolling();
    }

    IEnumerator EnableGameover()
    {
        yield return new WaitForSeconds(2f);
        player.SetActive(false);
    }
    public void ChangeToOpening()
    {
        SetGMState(GameManagerState.OPENING);
    }
}
