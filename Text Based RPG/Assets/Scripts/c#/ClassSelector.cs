using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassSelector : MonoBehaviour
{
    public string className;
    public MenuController menuController;

    public void SelectClass()
    {
        menuController.player.playerClass = className;
        menuController.SetClassSkills(className);
        menuController.canContinue = true;
    }
}
