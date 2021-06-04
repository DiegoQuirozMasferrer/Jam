
using UnityEngine;
using System;
using System.Collections.Generic;

public class BtWalk : Bnode
{
    protected Vector3 NextDestination { get; set; }
    public float speed =0.8f;
    public BtWalk(BehaviorTree t) : base(t)
    {
        NextDestination = Vector3.zero;
        FindNextDestination();
    }
    public bool FindNextDestination()
    {
        object o;
        bool found = false;
        found = tree.Blackboard.TryGetValue("WorldBounds", out o);
        if (found)
        {
            Rect bounds = (Rect)o;
            float x = UnityEngine.Random.value * bounds.width;
            float y = UnityEngine.Random.value * bounds.height;

            NextDestination = new Vector3(x, y, NextDestination.z);
        }


        return found;
            
            
    }

    public override Result Execute()
    {
        if(tree.gameObject.transform.position == NextDestination)
        {
            if (!FindNextDestination()) { 
                Debug.Log("se no mueve");
            return Result.failure;}
            else
                return Result.success;


        }
        
        else
        {
            tree.gameObject.transform.position =
                Vector3.MoveTowards(tree.gameObject.transform.position, NextDestination, Time.deltaTime * speed);
            
            return Result.runnig;
            Debug.Log("se mueve");
        }

        
    }

}
