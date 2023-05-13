using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreboardItem : MonoBehaviour
{
    public Transform Player;
    public TMP_Text UserNameText;
    public TMP_Text KillsCountText;
    public TMP_Text DeathsCountText;

    private int i = 0;
    
    public void Initialize(Transform player)
    {
        Player = player;
        UserNameText.text = player.GetComponent<PlayerInfos>().PlayerName;
        KillsCountText.text = "0";
        DeathsCountText.text = "0";
    }

    void Start()
    {
        Initialize(Player);
    }

    // Update avec les infos de PlayerInfos
    public void Update()
    {
        if (Player != null)
        {
            KillsCountText.text = Player.GetComponent<PlayerInfos>().KillsCount.ToString();
            DeathsCountText.text = Player.GetComponent<PlayerInfos>().DeathsCount.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
