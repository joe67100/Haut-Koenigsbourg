using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// update the scoreboard

public class ScoreboardItem : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text killsText;
    public TMP_Text deathsText;

    // relie les infos au joueur
    public void Initialize()
    {
        usernameText.text = "Player";   //TODO : set to the player's name
        killsText.text = "0";
        deathsText.text = "0";
    }

    public void SetPlayerName(string name)
    {
        usernameText.text = name;
    }
}
