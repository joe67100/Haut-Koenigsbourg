using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject StaticHUD;
    [SerializeField] private GameObject askNameWindow;

    // Start is called before the first frame update
    void Start()
    {
        StaticHUD.SetActive(false);
        askNameWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        //si askNameWindow est actif, on ne peut pas faire pause
        if (askNameWindow.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.H))
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
    }

    private void Pause()
    {
        isPaused = true;
        StaticHUD.SetActive(false);
    }

    public void Resume()
    {
        isPaused = false;
        StaticHUD.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}