using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public Transform player;
    [SerializeField] GameObject ScoreBoardItemPrefab;

    // Start is called before the first frame update
    void Start()
    {
        AddScoreboardItem(player);
        gameObject.SetActive(false);
    }

    void update()
    {
        //si a est pressé, afficher le scoreboard
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.SetActive(true);
        }
        //si a est relaché, cacher le scoreboard
        if (Input.GetKeyUp(KeyCode.A))
        {
            gameObject.SetActive(false);
        }
    }


    void AddScoreboardItem(Transform player)
    {
        GameObject item = Instantiate(ScoreBoardItemPrefab, transform);
        item.GetComponent<ScoreboardItem>().Initialize(player);
    }

    public void DeleteScoreboardItem(Transform player)
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<ScoreboardItem>().Player == player)
            {
                Destroy(child.gameObject);
                return;
            }
        }
    }  
}
