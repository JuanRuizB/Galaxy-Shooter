using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImageDisplay;

    public Image titleImageDisplay;

    public TextMeshProUGUI scoreText;
    public int score;

    public bool isTitleActive;

    [SerializeField]
    private SpanwManager _spanwManager;

    void Start()
    {
        livesImageDisplay.enabled = false;
        scoreText.enabled = false;
        isTitleActive = true;
        _spanwManager = _spanwManager.GetComponent<SpanwManager>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && isTitleActive)
    //    {
    //        livesImageDisplay.enabled = true;
    //        scoreText.enabled = true;
    //        titleImageDisplay.enabled = false;
    //        isTitleActive = false;

    //    }
    //}

    public void UpdateLives(int currentLives)
    {
        livesImageDisplay.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }

    public void showTitleScreen()
    {
        titleImageDisplay.enabled = true;
        livesImageDisplay.enabled = false;
        //_spanwManager.updateSpawn();
    }

    public void hideTitleScreen()
    {
        titleImageDisplay.enabled = false;
        livesImageDisplay.enabled = true;
        scoreText.enabled = true;
        score = 0;
        scoreText.text = "Score: ";
        //_spanwManager.updateSpawn();
    }

    //public void ManageTitle()
    //{
    //    _spanwManager.updateSpawn();
    //    isTitleActive = true;
    //    titleImageDisplay.enabled = true;
    //    score = 0;
    //}
}
