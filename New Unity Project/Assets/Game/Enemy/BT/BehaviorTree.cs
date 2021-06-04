using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTree : MonoBehaviour
{

    private Bnode mRoot;
    private bool startBehavior;
    private Coroutine behavior;
    private Rigidbody2D rb;
    [SerializeField]
    public Transform playerCheck;
    public float minAgroDistance = 1f;
    public float maxAgroDistance = 2f;
    public LayerMask whatIsPlayer;

    public Dictionary<string, object> Blackboard { get; set; }
    public Bnode Root
    {
        get
        {
            return mRoot;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Blackboard = new Dictionary<string, object>();
        Blackboard.Add("WorldBounds", new Rect(0, 0, 100, 1));


        startBehavior = false;
        mRoot = new BtReapeter(this, new BtSequencer(this, new Bnode[] { new BtWalk(this), new Agrro(this) }));
    }

    // Update is called once per frame
    void Update() 
    {
        if (!startBehavior)
        {
            behavior = StartCoroutine(RunBehavior());
            startBehavior = true;
        }
    }

    private IEnumerator RunBehavior()
    {
        Bnode.Result result = Root.Execute();
        while(result == Bnode.Result.runnig)
        {
            Debug.Log("Root :" + result);
            yield return null;
            result = Root.Execute();
        }

        Debug.Log("Behavior has finish with:" + result);

    }



}
