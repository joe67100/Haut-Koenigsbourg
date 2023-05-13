using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfos : MonoBehaviour
{
    public string PlayerName;
    public int KillsCount = 0;
    public int DeathsCount = 0;
    public int Score = 0;
    public ScoreboardItem ScoreBoardItem;

    void start()
    {
        
    }


    // methode qui permet de définir le nom du joueur
    public void SetPlayerName(string name)
    {
        string playerName = name;
    }

    public void AddKillCount()
    {
        KillsCount++;
        Score = Score + 100;
    }

    public void AddDeathCount()
    {
        DeathsCount++;
    }
}
