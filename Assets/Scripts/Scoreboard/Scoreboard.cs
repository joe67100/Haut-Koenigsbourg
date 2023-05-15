using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scoreboard : MonoBehaviour
{
    // gère l'affichage du scoreboard et des scoreboardItems
    public GameObject scoreboardItemPrefab;
    public Transform scoreboardItemContainer;

    private bool isDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        //Hide();
        
        // create a scoreboard item for the player
        GameObject playerScoreboardItemGO = Instantiate(scoreboardItemPrefab, scoreboardItemContainer);
        ScoreboardItem playerScoreboardItem = playerScoreboardItemGO.GetComponent<ScoreboardItem>();
        playerScoreboardItem.Initialize();
    }

    void Update()
    {
        Debug.Log("Scoreboard Update");
        
        // lorsque appuie sur tab, affiche le scoreboard
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("Tab pressed");
            
            if (isDisplayed)
            {
                Hide();
                
            }
            else
            {
                Display();
                
            }
        }
    }

    public void Hide()
    {
        isDisplayed = (false);
        
        // desactive tout les items
        //foreach (Transform child in scoreboardItemContainer)
        //{
        //    child.gameObject.SetActive(false);
        //}
        Debug.Log("Scoreboard is not displayed");
    }
  
    public void Display()
    {
        isDisplayed = true;
        
        // active tout les items
        //foreach (Transform child in scoreboardItemContainer)
        //{
        //    child.gameObject.SetActive(true);
        //}
        Debug.Log("Scoreboard is displayed");
    }
}

