using UnityEngine;
using Mirror;

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
                    UpdateGameObjects();
                }
            }   
        }
    }

    public void StartClient()
    {
        if (!NetworkClient.isConnected && !NetworkServer.active)
        {
            if (!NetworkClient.active)
            {
                Debug.Log("J'ai réussi à me connecter");
                networkManager.StartClient();
                UpdateGameObjects();
            }
            else
            {
                Debug.Log("Trying to connect");
            }
        }
    }


}
