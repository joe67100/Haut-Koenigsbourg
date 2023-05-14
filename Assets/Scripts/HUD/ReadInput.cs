using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ReadInput : MonoBehaviour
{
    public string input;
    [SerializeField] private GameObject askNameWindow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // when Enter is pressed, the player's name is set to whatever is in the TMP_InputField
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // desactive the askNameWindow and activate the StaticHUD
            GameObject.Find("HUD").GetComponent<HUD>().Resume();
            askNameWindow.SetActive(false);
        }
    }

    public void ReadStringInput(string s)
    {
        input = s;
        Debug.Log(input);

        //TODO 
        // set the player's name to the input

        //Add the player to the scoreboard
        
    }
}
