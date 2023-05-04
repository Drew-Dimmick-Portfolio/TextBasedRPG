using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

[NodeWidth(400)]
[NodeTint("#23487d")]
public class DialogueNode : BaseNode {

    [Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;
    [TextArea]
    public string dialogueLine;
    [Output(dynamicPortList = true)] public List<string> dialogueOptions = new List<string>();
    private string returnOptionString;

    public void AnswerQuestion(int index)
    {
        NodePort port = null;
        if (dialogueOptions.Count == 0)
        {
            port = GetOutputPort("output");
        }
        else
        {
            if (dialogueOptions.Count <= index) return;
            port = GetOutputPort("Options " + index);
        }

        if (port == null) return;
        for (int i = 0; i < port.ConnectionCount; i++)
        {
            NodePort connection = port.GetConnection(i);
            //(connection.node as DialogueBaseNode).Trigger();
        }
    }

    public override string GetString()
    {
        returnOptionString = "";
        foreach(string option in dialogueOptions)
        {
            returnOptionString += "/" + option;
        }
        return "DialogueNode/" + "unknown" + "/" + dialogueLine + returnOptionString;
    }
}