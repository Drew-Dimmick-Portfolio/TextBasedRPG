using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

class StoryBlock
{
    public string story;
    public string option1Text, option2Text, option3Text, option4Text;
    public StoryBlock option1Block, option2Block, option3Block, option4Block;

    public StoryBlock(string story, 
                    string option1Text, string option2Text, string option3Text, string option4Text,
                    StoryBlock option1Block = null, StoryBlock option2Block = null, StoryBlock option3Block = null, StoryBlock option4Block = null)
    {
        this.story = story;

        this.option1Text = option1Text;
        this.option2Text = option2Text;
        this.option3Text = option3Text;
        this.option4Text = option4Text;

        this.option1Block = option1Block;
        this.option2Block = option2Block;
        this.option3Block = option3Block;
        this.option4Block = option4Block;
    }
}

public class DialogController : MonoBehaviour
{
    public Button dialogButton1, dialogButton2, dialogButton3, dialogButton4;
    public TMP_Text dialogOption1, dialogOption2, dialogOption3, dialogOption4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
