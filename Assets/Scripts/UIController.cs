using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject gameOverScreen;
    public void TryAgainScreen()
    {
        SceneManager.LoadScene("Game");
    }

    public void ActivateGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

}
