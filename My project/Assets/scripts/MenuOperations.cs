using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuOperations : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("tut");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
