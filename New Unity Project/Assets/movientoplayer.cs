using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movientoplayer : MonoBehaviour
{
    // Start is called before the first frame update
    
        // Start is called before the first frame update
    private Rigidbody2D rb;
    Vector2 input;
    public float speed;
    private float position;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = input * speed * Time.fixedDeltaTime;
        position = gameObject.transform.position.y;
        
        if (Input.GetKey(KeyCode.UpArrow)  )
        {
            gameObject.transform.localScale = new Vector3(1.2f, 1.4f);
            Trampa();
            Debug.Log("se achico");
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.localScale = new Vector3(3.18f, 2.6625f);
            Legal();
        }

    }
    private bool Trampa()
    {
        gameObject.transform.position = new Vector2( gameObject.transform.position.x ,1.674391f);
        return true;

    }    
    private void Legal()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, -3.15f);
    }
}

    // Update is called once per frame
    

