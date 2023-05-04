using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[NodeTint("#32a852")]
public class StartNode : BaseNode {

    [Output] public int exit;
    public int startIndex;

    public override string GetString()
    {
        return "Start/" + startIndex.ToString();
    }

   
}