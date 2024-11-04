using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        finalScoreText.text = "Final Score: " + GameManager.finalScore.ToString();
    }
}
