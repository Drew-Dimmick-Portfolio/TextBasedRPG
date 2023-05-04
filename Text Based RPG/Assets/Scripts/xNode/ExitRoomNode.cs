using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(200)]
[NodeTint("#521818")]
public class ExitRoomNode : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public DialogueNode input;
	public enum RoomExits
	{
		north, south, east, west
	}
	public RoomExits roomExit;
	private string exitString;

	// Use this for initialization
	protected override void Init() {
		base.Init();

		switch(roomExit)
        {
			case RoomExits.north:
				exitString = "north";
				break;
			case RoomExits.south:
				exitString = "south";
				break;
			case RoomExits.east:
				exitString = "east";
				break;
			case RoomExits.west:
				exitString = "west";
				break;
		}
	}

	// Return the correct value of an output port when requested
	public override string GetString() {
		return "exit/" + exitString;
	}
}