using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class RoomNodeParser : MonoBehaviour
{
    public DialogueNodeParser dialogueNodeParser;
    public RoomGraph graph;
    private List<int> doorIDs = new List<int>();
    void Start()
    {
        foreach (BaseNode b in graph.nodes)
        {
            if (b.GetString() == "Start")
            {
                graph.current = b;
                NextNode("exit");
                break;
            }
        }
        ParseNode();
    }

    private void ParseNode()
    {
        BaseNode b = graph.current;
        doorIDs = b.GetDoorIDs();
    }

    public void ChangeRooms(int doorID)
    {
        for(int i = 0; i < doorIDs.Count; i++)
        {
            if (doorIDs[i] == doorID)
            {
                NextNode("doorIDs " + i);
                return;
            }
        }
    }

    public void NextNode(string fieldName)
    {
        foreach (NodePort p in graph.current.Ports)
        {
            if (p.fieldName == fieldName)
            {
                graph.current = p.Connection.node as BaseNode;
                BaseNode b = graph.current;
                //DialogueGraph newDialogue = b.GetDialogueGraph();
                dialogueNodeParser.ChangeDialogueGraph(b.GetDialogueGraph());
                break;
            }
        }
        ParseNode();
    }
}
