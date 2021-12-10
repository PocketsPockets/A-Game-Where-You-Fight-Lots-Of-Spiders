using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResumeGame : MonoBehaviour
{
    public GameObject pauseMenu;
    public PlayerController playerController;
    bool gameResumed = false;
    public void ResumeTheGame()
    {
        Debug.Log("Unpaused");
        Time.timeScale = 1f;
        playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
    }
    public void GoToTheMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitTheApplication()
    {
        Application.Quit();
    }
}
