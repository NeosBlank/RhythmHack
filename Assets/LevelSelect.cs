using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Level Shattered Time");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("Level A Bella");
    }

}
