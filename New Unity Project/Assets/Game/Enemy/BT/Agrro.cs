using UnityEditor;
using UnityEngine;
using System;

public class Agrro : Bnode
{
    public float speed = 1.0f;
    protected Vector3 NextDestination { get; set; }

    public Agrro(BehaviorTree t) : base(t)
    {
        FindTarget();
    }
    public bool FindTarget()
    {
        object o;
        bool found = false;
        found = Physics2D.Raycast(tree.playerCheck.position, tree.transform.right, tree.maxAgroDistance, tree.whatIsPlayer);
        Debug.Log("found:"+found);
        if (found)
        {
            NextDestination = new Vector3(tree.playerCheck.position.x, tree.playerCheck.position.y, tree.playerCheck.position.z);
        }

        return found;
    }

    public override Result Execute()
    {
        if (tree.gameObject.transform.position == NextDestination)
        {
            if (!FindTarget())
            {
               
                return Result.failure;
            }
            else
                return Result.success;


        }

        else
        {
            tree.gameObject.transform.position =
                Vector3.MoveTowards(tree.gameObject.transform.position, NextDestination, Time.deltaTime * speed);
            Debug.Log("ataca");
            return Result.runnig;
           
        }


    }
}

