using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatArraySelector : MonoBehaviour
{
    public string statArray;
    public MenuController menuController;

    public void SelectArray()
    {
        menuController.player.statArray = statArray;
        menuController.canContinue = true;
    }
}

