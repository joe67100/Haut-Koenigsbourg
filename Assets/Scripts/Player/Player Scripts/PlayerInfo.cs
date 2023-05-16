using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System;

public class PlayerInfo : MonoBehaviour
{
    public string PlayerName;
    public int KillsCount = 0;
    public int DeathsCount = 0;
    public int Score = 0;


    // methode qui permet de définir le nom du joueur
    public void SetName(string name)
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
