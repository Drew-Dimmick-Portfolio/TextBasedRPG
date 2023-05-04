using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class BaseNode : Node {

	public virtual string GetString()
    {
        return null;
    }

    public virtual Sprite GetSprite()
    {
        return null;
    }

    public virtual DialogueGraph GetDialogueGraph()
    {
        return null;
    }

    public virtual List<int> GetDoorIDs()
    {
        return null;
    }

    public virtual int GetStartIndex()
    {
        return 0;
    }
}