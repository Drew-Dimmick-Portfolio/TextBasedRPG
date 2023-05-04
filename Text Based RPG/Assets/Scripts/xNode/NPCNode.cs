using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class NPCNode : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public NPCNode input;
	public DialogueGraph npcDialogue;
	public string npcName;
	private Dictionary<string, int> npcInfo =  new Dictionary<string, int>();
	private int dialogueStartIndex;
	
	// Use this for initialization
	protected override void Init() {
		base.Init();

		if(ES3.KeyExists(npcName))
        {
			npcInfo = ES3.Load(npcName, npcInfo);
			npcInfo["dialogueStartIndex"] = 1;
			dialogueStartIndex = npcInfo["dialogueStartIndex"];
		}
		else
        {
			npcInfo.Add("dialogueStartIndex", 0);
			ES3.Save(npcName, npcInfo);
			dialogueStartIndex = npcInfo["dialogueStartIndex"];
		}
	}

	public override string GetString()
    {
		return "npc";
    }

	public override DialogueGraph GetDialogueGraph()
	{
		return npcDialogue;
	}

	public override int GetStartIndex()
    {
		return dialogueStartIndex;
    }
}