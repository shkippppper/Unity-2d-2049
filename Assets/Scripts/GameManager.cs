using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TileBoard board;
    public CanvasGroup gameOver;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    private int score;

    public int level = 2;

    public Button two;
    public Button three;
    public Button five;
    public Button seven;
    public Button AT;

    private void Start()
    {
        level = 2;
        NewGame();

    }

    private void Update()
    {

        if (board.gameGoing)
        {
            two.interactable = false;
            three.interactable = false;
            five.interactable = false;
            seven.interactable = false;
        }
        else
        {
            two.interactable = true;
            three.interactable = true;
            five.interactable = true;
            seven.interactable = true;
        }
    }

    public void NewGame()
    {
        
        SetScore(0);
        hiscoreText.text = LoadHiScore().ToString();

        gameOver.alpha = 0f;
        gameOver.interactable = false;

        board.level = level;
        board.gameGoing = false;
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();

        board.enabled = true;
    }

    public void GameOver()
    {

        board.enabled = false;
        gameOver.interactable = true;

        StartCoroutine(Fade(gameOver, 1f, 1f));
    }

    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;

        }
        canvasGroup.alpha = to;    
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiScore();

        if (score > hiscore)
        {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }

    private int LoadHiScore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }


    public void LevelTwo()
    {
        level = 2;
        NewGame();
    }

    public void LevelThree()
    {
        level = 3;
        NewGame();
    }

    public void LevelFive()
    {
        level = 5;
        NewGame();
    }

    public void LevelSeven()
    {
        level = 7;
        NewGame();
    }

    public void Shkipper()
    {
        Application.OpenURL("https://atitb.com");
    }

    public void ATMouseOver()
    {

        AT.transform.localScale = new Vector3(Mathf.Lerp(1f, 1.1f, 1f), Mathf.Lerp(1f, 1.1f, 1f), 1);
    }

    public void ATMouseLeave()
    {
        AT.transform.localScale = new Vector3(Mathf.Lerp(1.1f, 1f, 1f), Mathf.Lerp(1.1f, 1f, 1f), 1);

    }


}
