using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocity = 0.0f;
     Vector3 targetPosition;
    private Vector3 foward;
    Transform currentTarget;
    float maxDist;
    enum state
    {
        Wander,
        espera,
        cambio,
        Chase

    }
    state CurrentState;
    IEnumerator FSM()
    {
        while (true)
        {
            yield return StartCoroutine(CurrentState.ToString());

        }
    }

    void ChangeState(state nextState)
    {
        Debug.Log(CurrentState + "->" + nextState);
        CurrentState = nextState;
    }

    IEnumerator Chase()
    {
        while (CurrentState == state.Chase)
        {

            foward = currentTarget.position - transform.position;

            transform.position += foward.normalized * velocity * Time.deltaTime;
            Debug.DrawLine(transform.position, targetPosition, Color.green);
            
            if(targetPosition.magnitude>maxDist)
            {
                ChangeState(state.Wander);
            }



               yield return 0; 
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            currentTarget = collision.transform;
            ChangeState(state.Chase);
        }
    }

    IEnumerator Wander()
    {

        while (CurrentState == state.Wander)
        {
            int ruta= Random.Range(0,1);

            switch(ruta)
                {

                case 0:
                    rb.AddForce(transform.forward * velocity);
                    break;

                case 1:
                    rb.velocity= -transform.forward* velocity;
                    break;
            }
            
        }
        yield return 0;
    }

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(FSM());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
