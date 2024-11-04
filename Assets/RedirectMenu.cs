using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class RedirectMenu : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu2"); 
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Level A Bella");
    }


}
