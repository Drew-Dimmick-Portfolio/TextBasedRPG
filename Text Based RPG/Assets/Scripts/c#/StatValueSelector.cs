using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatValueSelector : MonoBehaviour
{
    public string statName;
    public MenuController menuController;
    public TMP_Text label;

    private int savedValueIndex;
    public string savedValue = "-";

    public void OnDropDownChanged(TMP_Dropdown dropDown)
    {
        menuController.UpdateDropDownOptions(dropDown.value, ref savedValue);
        label.text = savedValue;
    }

    public void ResetValues()
    {
        savedValue = "-";
        label.text = savedValue;
    }
}
