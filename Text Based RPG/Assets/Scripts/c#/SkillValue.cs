using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class SkillValue : MonoBehaviour
{
    public MenuController menuController;

    public GameObject plusButton;
    public GameObject minusButton;

    public TMP_Text skillValue;
    private int skillValueInt;

    public TMP_Text descriptionText;

    public int pointCost = 0;
    public TMP_Text pointCostText;
    public TMP_Text classSkillOrNot;

    public string skillName;
    public bool classSkill;
    private string crossClassSkillText = "Cross-Class Skill";
    private string classSkillText = "Class Skill";

    [TextArea]
    public string description;


    void Start()
    {
        menuController.player.playerLevel = 1;

        ParseText();
        if(skillValueInt == 0)
        {
            minusButton.SetActive(false);
        }
    }

    void Update()
    {
       if(menuController.remainingSkillPoints - pointCost < 0 || IsSkillMaxed())
        {
            plusButton.SetActive(false);
        }
       else
        {
            plusButton.SetActive(true);
        }
    }

    private bool IsSkillMaxed()
    {
        if(classSkill)
        {
            if(skillValueInt >= menuController.player.playerLevel + 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if(skillValueInt >= ((menuController.player.playerLevel + 3) / 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public void DisplayDescription()
    {
        descriptionText.text = description;

        if (pointCost > 0)
        {
            pointCostText.text = pointCost.ToString();
        }

        if(classSkill)
        {
            classSkillOrNot.text = classSkillText;
        }
        else
        {
            classSkillOrNot.text = crossClassSkillText;
        }
    }

    public void Add()
    {
        ParseText();

        if(menuController.remainingSkillPoints - pointCost >= 0)
        {
            skillValueInt++;

            if (skillValueInt == 1)
            {
                minusButton.SetActive(true);
            }
            SetSkillValueText();

            menuController.UpdateRemainingSkillPoints("-", pointCost);
        }
    }

    public void Subtract()
    {
        ParseText();

        if (skillValueInt > 0)
        {
            skillValueInt--;

            if(skillValueInt == 0)
            {
                minusButton.SetActive(false);
            }
            SetSkillValueText();

            menuController.UpdateRemainingSkillPoints("+", pointCost);
        }
    }

    private void ParseText()
    {
        int.TryParse(skillValue.GetParsedText(), out skillValueInt);
    }

    public void ResetValues()
    {
        menuController.remainingSkillPoints = 12;
        skillValueInt = 0;
        SetSkillValueText();
        minusButton.SetActive(false);
    }

    private void SetSkillValueText()
    {
        skillValue.text = skillValueInt.ToString();
    }
}
