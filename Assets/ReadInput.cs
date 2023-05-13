using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ReadInput : MonoBehaviour
{
    public Transform player;
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // when Enter is pressed, the player's name is set to whatever is in the TMP_InputField
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    player.GetComponent<Player>().playerName = inputField.text;
        //    gameObject.SetActive(false);

        //    // desactive the askNameWindow and activate the StaticHUD
        //    GameObject.Find("HUD").GetComponent<HUD>().Resume();
            
        //}
    }
}
