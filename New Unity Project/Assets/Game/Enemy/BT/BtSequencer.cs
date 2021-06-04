using System;
using System.Collections.Generic;

public class BtSequencer : BtComposite
{
    private int currentNode = 0;
    public BtSequencer(BehaviorTree t, Bnode [] children): base(t, children)
    {

    }
    public override Result Execute()
    {
        if (currentNode < Children.Count)
        {
            Result result = Children[currentNode].Execute();

            if (result == Result.runnig)

                return Result.runnig;
            else if (result == Result.failure)
            {
                currentNode = 0;
                return Result.failure;
            }
            else
            {
                currentNode++;
                if (currentNode < Children.Count)

                    return Result.runnig;
                else
                {
                    currentNode = 0;
                    return Result.success;
                }
            }
        }
        return Result.success;
    }
}

