using System;
using UnityEngine;

public class BtReapeter: Decorato
{
    public BtReapeter(BehaviorTree t, Bnode c): base(t, c)
    {

    }
    public override Result Execute()
    {
        Debug.Log("child reapeter return:" + Child.Execute());
        return Result.runnig;
    }

}