using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    public Level level;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;

    public Image[] stars;

    public GameOver gameover;

    private int startIndex;
    private bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStars();
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int target)
    {
        remainingText.text = target.ToString();
    }

    public void SetRemaining(string target)
    {
        remainingText.text = target;
    }

    public void OnGameWin(int score)
    {
        gameover.ShowWin(score, startIndex);

        if (startIndex > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0))
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, startIndex);
        }
    }

    public void OnGameLose()
    {
        gameover.ShowLose();
    }

    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                remainingSubText.text = "Moves Remaining";
                targetSubtext.text = "Target Score";
                break;

            case Level.LevelType.OBSTACLE:
                remainingSubText.text = "Moves Remaining";
                targetSubtext.text = "Dishes Remaining";
                break;

            case Level.LevelType.TIMER:

                remainingSubText.text = "Time Remaining";
                targetSubtext.text = "Target Score";
                break;

        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

        int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }

        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }

        else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        startIndex = visibleStar;

        UpdateStars();
    }

    public void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == startIndex)
            {
                stars[i].enabled = true;
            }
            else
            {
                stars[i].enabled = false;
            }
        }
    }
}
