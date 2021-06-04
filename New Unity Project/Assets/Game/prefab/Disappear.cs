using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 2) {
            Destroy(this.gameObject);
            timer = 0f;
        }
            
       
    }
}
