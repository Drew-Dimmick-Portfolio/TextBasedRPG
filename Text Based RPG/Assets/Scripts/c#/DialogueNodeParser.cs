using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;
using TMPro;

public class DialogueNodeParser : MonoBehaviour
{
    public RoomNodeParser roomNodeParser;
    public Player player;
    public DialogueGraph graph;

    public TMP_Text speaker;
    public TMP_Text dialogue;
    public TMP_Text[] dialogOptions;
    private bool[] dialogueOptionsAvailability =  new bool[4];

    public Animator dialogueAnimator;
    public Image speakerImage;

    private string statToBeChecked;
    private string statCheckOpperator;
    private int statCheckValue;

    private int dialogueStartIndex;

    private void Start()
    {
        foreach (BaseNode b in graph.nodes)
        {
            if(b.GetString() == "Start/" + dialogueStartIndex)
            {
                graph.current = b;
                break;
            }
        }
        ParseNode();
    }

    private void ParseNode()
    {
        BaseNode b = graph.current;
        string data = b.GetString();
        string[] dataParts = data.Split('/');

        if (dataParts[0] == "Start")
        {
            NextNode("exit");
        }
        if (dataParts[0] == "DialogueNode")
        {
            ParseDialogueNode(dataParts);
        }
        if (dataParts[0] == "StatCheckNode")
        {
            ParseStatCheckNode(dataParts);
        }
        if (dataParts[0] == "StatModifier")
        {
            ParseStatModifierNode(dataParts);
        }
        if (dataParts[0] == "npc")
        {
            ParseNPCNode(b);
        }
        /*if (dataParts[0] == "exit")
        {
            roomNodeParser.ChangeRooms(dataParts[1]);
        }*/
    }

    public void ChangeDialogueGraph(DialogueGraph d)
    {
        graph = d;
        foreach (BaseNode b in graph.nodes)
        {
            if (b.GetString() == "Start/" + dialogueStartIndex)
            {
                graph.current = b;
                break;
            }
        }
        ParseNode();
    }

    private void ParseNPCNode(BaseNode b)
    {
        dialogueStartIndex = b.GetStartIndex();
        ChangeDialogueGraph(b.GetDialogueGraph());
        dialogueStartIndex = 0;
    }

    private void ParseDialogueNode(string[] dataParts)
    {
        for (int i = 0; i < dialogOptions.Length; i++)
        {
            dialogOptions[i].text = "";
            dialogueOptionsAvailability[i] = false;
        }
        speaker.text = dataParts[1];
        StartCoroutine(handleTextFade(dataParts));
    }

    private void ParseStatCheckNode(string[] dataParts)
    {
        statToBeChecked = dataParts[1];
        statCheckOpperator = dataParts[2];
        statCheckValue = Int32.Parse(dataParts[3]);

        if (statCheckOpperator == ">")
        {
            if (player.playerStats[statToBeChecked] > statCheckValue)
            {
                NextNode("pass");
            }
            else
            {
                NextNode("fail");
            }
        }
        else if (statCheckOpperator == "<")
        {
            if (player.playerStats[statToBeChecked] < statCheckValue)
            {
                NextNode("pass");
            }
            else
            {
                NextNode("fail");
            }
        }
        else
        {
            if (player.playerStats[statToBeChecked] == statCheckValue)
            {
                NextNode("pass");
            }
            else
            {
                NextNode("fail");
            }
        }
    }

    private void ParseStatModifierNode(string[] dataParts)
    {
        statToBeChecked = dataParts[1];
        statCheckOpperator = dataParts[2];
        statCheckValue = Int32.Parse(dataParts[3]);

        if (statCheckOpperator == "+")
        {
            player.playerStats[statToBeChecked] += statCheckValue;
            NextNode("output");
        }
        else if (statCheckOpperator == "-")
        {
            player.playerStats[statToBeChecked] -= statCheckValue;
            NextNode("output");
        }
        else
        {
            player.playerStats[statToBeChecked] = statCheckValue;
            NextNode("output");
        }
    }

    public void OptionsHandler(int option)
    {
        switch(option)
        {
            case 1:
                if(dialogueOptionsAvailability[0])
                {
                    NextNode("dialogueOptions 0");
                }
                break;
            case 2:
                if (dialogueOptionsAvailability[1])
                {
                    NextNode("dialogueOptions 1");
                }
                break;
            case 3:
                if (dialogueOptionsAvailability[2])
                {
                    NextNode("dialogueOptions 2");
                }
                break;
            case 4:
                if (dialogueOptionsAvailability[3])
                {
                    NextNode("dialogueOptions 3");
                }
                break;
        }
    }

    public void NextNode(string fieldName)
    {
        foreach (NodePort p in graph.current.Ports)
        {
            if (p.fieldName == fieldName)
            {
                dialogueAnimator.SetTrigger("FadeIn");
                graph.current = p.Connection.node as BaseNode;
                break;
            }
        }
        ParseNode();
    }

    IEnumerator handleTextFade(string[] dataParts)
    {
        
        yield return new WaitForSeconds(0.34f);
        dialogue.text = dataParts[2];
        for (int i = 3; i < dataParts.Length; i++)
        {
            dialogOptions[i - 3].text = dataParts[i];
            dialogueOptionsAvailability[i - 3] = true;
        }
    }
}
