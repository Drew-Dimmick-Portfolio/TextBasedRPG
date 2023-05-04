using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(300)]
[NodeTint("#4a2e2e")]
public class RoomNode : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public RoomNode input;
	public DialogueGraph roomDialogue;
    public enum RoomExits
    {
        north, south, east, west
    }
	[Output(dynamicPortList = true)] public List<int> doorIDs = new List<int>();

    public void RoomExitPorts(int index)
    {
        NodePort port = null;
        if (doorIDs.Count == 0)
        {
            port = GetOutputPort("output");
        }
        else
        {
            if (doorIDs.Count <= index) return;
            port = GetOutputPort("Options " + index);
        }

        if (port == null) return;
        for (int i = 0; i < port.ConnectionCount; i++)
        {
            NodePort connection = port.GetConnection(i);
            //(connection.node as DialogueBaseNode).Trigger();
        }
    }

    // Use this for initialization
    protected override void Init() {
		base.Init();
		
	}

    public override List<int> GetDoorIDs()
    {
        return doorIDs;
    }

	// Return the correct value of an output port when requested
	public override DialogueGraph GetDialogueGraph() {
        return roomDialogue;
	}
}