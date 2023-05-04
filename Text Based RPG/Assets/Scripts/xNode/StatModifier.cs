using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(250)]
[NodeTint("#250c2e")]
public class StatModifier : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;
	[Output(backingValue = ShowBackingValue.Never)] public DialogueNode output;
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
	public enum ModifierOptions
	{
		add, subtract, set
	}
	public ModifierOptions modifyType;
	public int value;

	private string statString, modifierString;

	// Use this for initialization
	protected override void Init() {
		base.Init();

		switch (stat)
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

		switch (modifyType)
		{
			case ModifierOptions.add:
				modifierString = "+";
				break;
			case ModifierOptions.subtract:
				modifierString = "-";
				break;
			case ModifierOptions.set:
				modifierString = "=";
				break;
		}

	}

	// Return the correct value of an output port when requested
	public override string GetString()
	{
		return "StatModifier/" + statString + "/" + modifierString + "/" + value.ToString();
	}
}