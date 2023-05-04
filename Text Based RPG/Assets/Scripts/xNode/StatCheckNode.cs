using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XNode;

[NodeWidth(250)]
[NodeTint("#122642")]
public class StatCheckNode : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;
	public enum statList
    {
		strength,
		agility,
		constitution,
		intellect,
		wisdom,
		charisma
	}
	public statList stat;
	public enum OpperatorOptions
    {
		greaterThan, lessThan, equals
    }
	public OpperatorOptions opperator;
	public int value;
	[Output(backingValue = ShowBackingValue.Never)] public DialogueNode pass;
	[Output(backingValue = ShowBackingValue.Never)] public DialogueNode fail;

	private string statString, opperatorString;

    // Use this for initialization
    protected override void Init() {
		base.Init();

		switch(stat)
        {
			case statList.strength:
				statString = "strength";
				break;
			case statList.agility:
				statString = "agility";
				break;
			case statList.constitution:
				statString = "constitution";
				break;
			case statList.intellect:
				statString = "intellect";
				break;
			case statList.wisdom:
				statString = "wisdom";
				break;
			case statList.charisma:
				statString = "charisma";
				break;
		}

		switch(opperator)
        {
			case OpperatorOptions.greaterThan:
				opperatorString = ">";
				break;
			case OpperatorOptions.lessThan:
				opperatorString = "<";
				break;
			case OpperatorOptions.equals:
				opperatorString = "=";
				break;
		}
	}

	public override string GetString() {
		return "StatCheckNode/" + statString + "/" + opperatorString + "/" + value.ToString();
	}
}