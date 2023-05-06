using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
