using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;

    public int currentScore;
    public static int finalScore;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;

    public TextMeshProUGUI scoreText;

    // HP Bar Variables
    public Slider hpBar;
    public int maxHP = 10;
    private int currentHP;

    public Animator characterAnimator;

    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        finalScore = currentScore;

        currentHP = maxHP;
        hpBar.maxValue = maxHP;
        hpBar.value = currentHP;
    }

    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
        else if (startPlaying && !theMusic.isPlaying && currentHP > 0)
        {
            WinGame();
        }
    }

    public void NoteHit()
    {
        scoreText.text = "Score: " + currentScore;
        finalScore = currentScore;
    }

    public void NormalHit()
    {
        currentScore += scorePerNote;
        NoteHit();
    }

    public void GoodHit()
    {
        currentScore += scorePerGoodNote;
        NoteHit();
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote;
        NoteHit();
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");

        currentHP--;
        hpBar.value = currentHP;

        characterAnimator.SetTrigger("hurt");
        Invoke("ResetHurtAnimation", 0.5f);

        if (currentHP <= 0)
        {
            GameOver();
        }
    }

    private void ResetHurtAnimation()
    {
        characterAnimator.ResetTrigger("hurt");
        characterAnimator.SetTrigger("reset");
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        theMusic.Stop();
        startPlaying = false;

        SceneManager.LoadScene("GameOver");
    }

    private void WinGame()
    {
        Debug.Log("You Win!");
        startPlaying = false;

        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level Shattered Time")
        {
            SceneManager.LoadScene("Win");
        }
        else if (currentScene == "Level A Bella")
        {
            SceneManager.LoadScene("FinalWin");
        }
        else
        {
            Debug.LogWarning("WinGame: Current scene is not recognized.");
        }
    }
}
