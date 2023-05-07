using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private float inactiveTime = 15f;
    private float timer;

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
}
