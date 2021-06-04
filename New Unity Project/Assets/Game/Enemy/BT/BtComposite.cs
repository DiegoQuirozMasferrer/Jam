using System;
using System.Collections.Generic;
public class BtComposite : Bnode
{
    public List<Bnode> Children { get; set; }

    public BtComposite(BehaviorTree t, Bnode[] nodes) : base(t)
    {
        Children = new List<Bnode>(nodes);
    }
}