using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterCreationStatBtn : MonoBehaviour
{
    [TextArea]
    public string description;
    public TMP_Text text;

    public void DisplayDescription()
    {
        text.text = description;
    }

    public void HideDescription()
    {
        
    }
}
