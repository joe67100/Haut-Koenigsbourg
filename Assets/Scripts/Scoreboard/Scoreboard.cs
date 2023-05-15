using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scoreboard management

public class Scoreboard : MonoBehaviour
{
    // gère l'affichage du scoreboard et des scoreboardItems
    public GameObject scoreboardItemPrefab;
    public Transform scoreboardItemContainer;
    public GameObject scoreboardCanvas;

    private bool isDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        Hide();
        
        // create a scoreboard item for the player
        GameObject playerScoreboardItemGO = Instantiate(scoreboardItemPrefab, scoreboardItemContainer);
        ScoreboardItem playerScoreboardItem = playerScoreboardItemGO.GetComponent<ScoreboardItem>();
        playerScoreboardItem.Initialize();
    }

    void Update()
    {
        // lorsque appuie sur tab, affiche le scoreboard
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Display();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Hide();
        }
    }

    public void Hide()
    {
        isDisplayed = (false);
        scoreboardCanvas.GetComponent<ScoreboardCanvas>().HideCanvas();
    }
  
    public void Display()
    {
        isDisplayed = true;
        scoreboardCanvas.GetComponent<ScoreboardCanvas>().ShowCanvas();
    }
}

