using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Level level;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubtext;
    public Text scoreText;

    public Image[] stars;

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
