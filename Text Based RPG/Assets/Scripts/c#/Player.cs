using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string playerName;
    public string playerClass;
    public string statArray;
    public int playerLevel;

    public Dictionary<string, int> playerStats = new Dictionary<string, int>();

    public void EditPlayerStat()
    {

    }

    public void PrintStats()
    {
        foreach(KeyValuePair<string, int> stat in playerStats)
        {
            Debug.Log(stat.Key + ": " + stat.Value);
        }
    }

    void Start()
    {
        playerStats.Add("strength", 1);
        playerStats.Add("agility", 1);
        playerStats.Add("constitution", 1);
        playerStats.Add("intillect", 1);
        playerStats.Add("wisdom", 1);
        playerStats.Add("charisma", 1);
    }

    void Update()
    {
        
    }
}
