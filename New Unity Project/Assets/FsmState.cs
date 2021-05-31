using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmState : MonoBehaviour
{
    enum state
    {
        Wander, 
        espera,
        cambio,
        ataque

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
    IEnumerator Wander ()
    {
        while (CurrentState == state.Wander)
        {

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
