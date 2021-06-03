using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bnode 
{
   public enum Result { runnig, failure, success};

    public BehaviorTree tree { get; set; }

    public Bnode (BehaviorTree t)
    {
        tree = t;
    }

    public virtual Result Execute()
    {
        return Result.failure;
    }
}
