﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeWidth(100)]
[NodeTint("#521818")]
public class ExitNode : BaseNode {

	[Input(backingValue = ShowBackingValue.Never)] public RoomNode input;

	// Use this for initialization
	protected override void Init() {
		base.Init();
		
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}