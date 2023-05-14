using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public string PlayerName;
    public int KillsCount = 0;
    public int DeathsCount = 0;
    public int Score = 0;

    [SerializeField] private GameObject askNameWindow;

    void start()
    {

    }


    // methode qui permet de définir le nom du joueur
    public void SetPlayerName(string name)
    {
        string playerName = name;
        //Debug.Log("Nom changer à : " + playerName);
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
