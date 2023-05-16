using UnityEngine;
using Mirror;
using System;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private float inactiveTime = 15f;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private NetworkManager networkManager;
    private float timer;

    [SerializeField] private GameObject mainCameraMenu;
    [SerializeField] private GameObject AudioMainTheme;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject AudioInGame;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private TMPro.TMP_InputField ipInputField;

    private void Update()
    {
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0f || Input.GetAxis("Mouse Y") != 0f)
        {
            timer = 0f;
            if (!menuCanvas.gameObject.activeSelf)
            {
                menuCanvas.gameObject.SetActive(true);
            }
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= inactiveTime)
            {
                menuCanvas.gameObject.SetActive(false);
            }
        }

        if (NetworkClient.isConnected)
        {
            UpdateGameObjects();
        }
    }
    
    public void UpdateGameObjects()
    {
        mainMenu.SetActive(false);
        AudioInGame.SetActive(true);
        PauseMenu.SetActive(true);
    }

    public void StartHost()
    {
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (!NetworkClient.active)
            {
                if (Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    networkManager.StartHost();
                }
            }   
        }
    }

    public void StartClient()
    {
        string ipAddress = ipInputField.text;
        if (string.IsNullOrWhiteSpace(ipAddress))
        {
            ipAddress = "localhost";
        }

        networkManager.networkAddress = ipAddress;
        networkManager.StartClient();
    }
}
