using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alejarce : MonoBehaviour
{

    public static Alejarce instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void Atras()
    {
       
        GameObject[] edi = GameObject.FindGameObjectsWithTag("Atras");
        Debug.Log("pasooooo");
        GameObject[] edificiosDelanteros = GameObject.FindGameObjectsWithTag("Frente");
        Debug.Log("se encontro delante");
        if (edi.Length == 0)
        {
            Debug.Log("No game objects are tagged with fred");
        }
        foreach (GameObject go in edi)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<BoxCollider2D>().enabled = true;
        }
        foreach(GameObject po in edificiosDelanteros)
        {
            po.GetComponent<BoxCollider2D>().enabled = false;

        }

        
    }
    public void Delante()
    {
        GameObject[] edi = GameObject.FindGameObjectsWithTag("Frente");
        GameObject[] edificiosTraceros = GameObject.FindGameObjectsWithTag("Atras");
        foreach (GameObject go in edi)
        {
            go.GetComponent<BoxCollider2D>().isTrigger = true;
        }
        foreach (GameObject go in edificiosTraceros)
        {
            go.GetComponent<BoxCollider2D>().isTrigger = false;

        }

    }
}
