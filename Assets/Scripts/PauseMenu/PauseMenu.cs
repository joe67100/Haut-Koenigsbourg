using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private static bool isPaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private AudioSource menuSound;

    private void Update()
    {
        if (!characterController.isGrounded) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        characterController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        menuSound.Play();
    }

    private void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        characterController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        menuSound.Play();
    }

    public void MainMenu()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
