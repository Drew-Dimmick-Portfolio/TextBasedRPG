using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MenuController : MonoBehaviour
{
    public Player player;
    private Dictionary<string, int> playerBaseStats = new Dictionary<string, int>();

    public int menuIndex;
    public List<GameObject> menuScreens;
    public List<GameObject> navButtons;
    public List<TMP_Dropdown> statDropDowns;
    public List<StatValueSelector> statValues;
    public List<SkillValue> skillValues;
    public bool updateDropDowns = true;
    public bool canContinue;

    private List<string> balancedArray = new List<string>() { "-", "14", "12", "14", "12", "14", "12" };
    private List<string> oneWayHeroArray = new List<string>() { "-", "17", "17", "10", "9", "8", "8" };
    private List<string> classicArray = new List<string>() { "-", "16", "15", "14", "12", "10", "8" };
    private List<string> specializedArray = new List<string>() { "-", "18", "14", "12", "10", "9", "8" };
    public List<string> currentArray = new List<string>();

    private Dictionary<string, bool> mercenaryClassSkills = new Dictionary<string, bool>() {
        { "medical", true }, { "speech", false }, { "hardware", false }, { "software", false }, { "lockpicking", false }, { "stealth", false }, { "athletics", true }, { "perception", true }, };
    private Dictionary<string, bool> spacerClassSkills = new Dictionary<string, bool>() {
        { "medical", false }, { "speech", true }, { "hardware", false }, { "software", false }, { "lockpicking", true }, { "stealth", true }, { "athletics", false }, { "perception", true }, };
    private Dictionary<string, bool> machinistClassSkills = new Dictionary<string, bool>() {
        { "medical", true }, { "speech", false }, { "hardware", true }, { "software", true }, { "lockpicking", false }, { "stealth", true }, { "athletics", false }, { "perception", true }, };

    public Dictionary<string, bool> currentClassSkills = new Dictionary<string, bool>();

    //[System.NonSerialized]
    public int remainingSkillPoints;
    public TMP_Text remainingPointsText;

    void Start()
    {
        canContinue = true;

        playerBaseStats = player.playerStats;

        menuIndex = 0;

        remainingSkillPoints = 12;

        for(int i = 0; i < menuScreens.Count; i++)
        {
            if(i == menuIndex)
            {
                menuScreens[i].SetActive(true);
            }
            else
            {
                menuScreens[i].SetActive(false);
            }
        }
    }

    void Update()
    {
        if (menuIndex == 0)
        {
            canContinue = true;
            ResetPlayer();
            foreach (GameObject btn in navButtons)
            {
                btn.SetActive(false);
            }
        }
        else if(menuIndex == 1) {
            foreach(GameObject btn in navButtons)
            {
                btn.SetActive(true);
            }
        }
    }

    public void UpdateRemainingSkillPoints(string opperator, int cost)
    {
        switch(opperator)
        {
            case "+":
                remainingSkillPoints += cost;
                remainingPointsText.text = remainingSkillPoints.ToString();
                break;
            case "-":
                remainingSkillPoints -= cost;
                remainingPointsText.text = remainingSkillPoints.ToString();
                break;
        }
    }

    public void SetClassSkills(string className)
    {
        switch (className)
        {
            case "mercenary":
                currentClassSkills = mercenaryClassSkills;
                break;
            case "spacer":
                currentClassSkills = spacerClassSkills;
                break;
            case "machinist":
                currentClassSkills = machinistClassSkills;
                break;
        }
        
        foreach(SkillValue sValue in skillValues)
        {
            sValue.classSkill = currentClassSkills[sValue.skillName];

            if(sValue.classSkill)
            {
                sValue.pointCost = 1;
            }
            else
            {
                sValue.pointCost = 2;
            }
        }
    }

    private void ResetPlayer()
    {
        player.playerClass = "";
        player.playerName = "";
        player.playerStats = playerBaseStats;
        currentClassSkills = null;
    }

    public void SetDropDownOptions()
    {
        if (updateDropDowns)
        {
            switch (player.statArray)
            {
                case "balanced":
                    currentArray.Clear();
                    currentArray.AddRange(balancedArray);
                    break;
                case "oneWayHero":
                    currentArray.Clear();
                    currentArray.AddRange(oneWayHeroArray);
                    break;
                case "classic":
                    currentArray.Clear();
                    currentArray.AddRange(classicArray);
                    break;
                case "specialized":
                    currentArray.Clear();
                    currentArray.AddRange(specializedArray);
                    break;
            }

            for (int i = 0; i < statDropDowns.Count; i++)
            {
                statDropDowns[i].ClearOptions();

                statDropDowns[i].AddOptions(currentArray);
            }
        }
        
        updateDropDowns = false;
    }

    public void UpdateDropDownOptions(int index, ref string lastValue)
    {
        string temp = currentArray[index];
        currentArray[index] = lastValue;
        lastValue = temp;

        updateDropDowns = true;

        for (int i = 0; i < statDropDowns.Count; i++)
        {
            statDropDowns[i].ClearOptions();

            statDropDowns[i].AddOptions(currentArray);
        }
    }

    public bool AllStatsFilled()
    {
        foreach(StatValueSelector statValue in statValues)
        {
            if(statValue.savedValue == "-")
            {
                return false;
            }
        }

        return true;
    }

    public bool AllSkillsFilled()
    {
        if (remainingSkillPoints == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void UpdatePlayer(string stat, TMP_Text label)
    {
        int valueInt = 0;
        ParseText(label, ref valueInt);
        player.playerStats[stat] = valueInt;
    }

    private void ParseText(TMP_Text text, ref int valueInt)
    {
        int.TryParse(text.GetParsedText(), out valueInt);
    }

    public void Next()
    {
        if(menuIndex == 3)
        {
            if(AllStatsFilled())
            {
                canContinue = true;
            }
        }
        else if(menuIndex == 4)
        {
            if(AllSkillsFilled())
            {
                canContinue = true;
            }
        }

        if(canContinue)
        {
            menuScreens[menuIndex].SetActive(false);

            menuIndex++;

            if(menuIndex == 3)
            {
                foreach (StatValueSelector statValue in statValues)
                {
                    statValue.ResetValues();
                }

                updateDropDowns = true;
                SetDropDownOptions();
            }
            else if(menuIndex == 4)
            {
                foreach(StatValueSelector statValue in statValues)
                {
                    UpdatePlayer(statValue.statName, statValue.label);
                }

                player.PrintStats();
            }

            menuScreens[menuIndex].SetActive(true);
            canContinue = false;
        }
    }

    public void Cancel()
    {
        menuScreens[menuIndex].SetActive(false);

        menuIndex--;

        if (menuIndex == 3)
        {
            foreach (StatValueSelector statValue in statValues)
            {
                statValue.ResetValues();
            }

            updateDropDowns = true;
            SetDropDownOptions();
        }
        else if(menuIndex == 4)
        {
            foreach (SkillValue skillValue in skillValues)
            {
                skillValue.ResetValues();
            }
            remainingSkillPoints = 12;
            remainingPointsText.text = remainingSkillPoints.ToString();
        }

        menuScreens[menuIndex].SetActive(true);
    }
}
