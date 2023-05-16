using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{
    public GameObject player;
    public GameObject text;
    public GameObject AskNameWindow;

    // with position values
    private float x;
    private float z;


    // Update is called once per frame
    void Update()
    {
        
        //if askName is active
        if (AskNameWindow.activeSelf == false)
        {
            if (player.transform.position.z < 810)
            {
                // calls SetText() from TitleTextManagement.cs
                text.GetComponent<TitleTextManagement>().SetText("Far Far Away");
            }

            if (player.transform.position.z >= 890)
            {
                // calls SetText() from TitleTextManagement.cs
                text.GetComponent<TitleTextManagement>().SetText("La mine");
            }
        }
    }
}
