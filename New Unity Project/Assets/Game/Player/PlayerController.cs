using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    bool alfrente = true;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJump;
    public int extraJumpValue;

    public Transform spawn;
    public string sceneName;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (isGrounded == true)
        {
            extraJump = extraJumpValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJump--;
            
        }
        else if (Input.GetKey(KeyCode.Space) && extraJump == 0 && isGrounded) 

        {
            rb.velocity = Vector2.up * jumpForce; 
        }
        Respawn();
    }


    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
         

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (!facingRight && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight && moveInput < 0) 
        {
            Flip();
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {

            if (!facingRight)
            {
                Flip();
            }

            gameObject.transform.localScale = new Vector3(0.07223215f, 0.07223215f);

            Trampa();
            Atras();
            Debug.Log("se achico");
            alfrente = false;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Trampa();
            Delante();
            gameObject.transform.localScale = new Vector3(0.1223215f, 0.1223215f);
            Legal();
            alfrente = true;

        }

    }

    void Flip() 
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
    private bool Trampa()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, 1.674391f);
        return true;


    }
    private void Legal()
    {
        
    }
    public void Atras()
    {

        GameObject[] edi = GameObject.FindGameObjectsWithTag("Atras");
        Debug.Log("pasooooo");
        GameObject[] edificiosDelanteros = GameObject.FindGameObjectsWithTag("Frente");
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo2");
        GameObject[] enemigos1 = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log("se encontro delante");
        sprite.sortingOrder = 1;
        if (edi.Length == 0)
        {
            Debug.Log("No game objects are tagged with fred");
        }
        foreach (GameObject go in edi)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<BoxCollider2D>().enabled = true;
        }
        foreach (GameObject go in enemigos)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<CircleCollider2D>().enabled = false;
        }
        foreach (GameObject po in edificiosDelanteros)
        {
            po.GetComponent<BoxCollider2D>().enabled = false;

        }
        foreach (GameObject go in enemigos1)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<BoxCollider2D>().isTrigger = true;
            go.GetComponent<Rigidbody2D>().gravityScale = 0;
        }


    }
    public void Delante()
    {
        GameObject[] edi = GameObject.FindGameObjectsWithTag("Frente");
        GameObject[] edificiosTraceros = GameObject.FindGameObjectsWithTag("Atras");
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("Enemigo2");
        GameObject[] enemigos1 = GameObject.FindGameObjectsWithTag("Enemy");
        sprite.sortingOrder =  2;
        foreach (GameObject go in edi)
        {
            go.GetComponent<BoxCollider2D>().enabled = true;
        }
        foreach (GameObject go in edificiosTraceros)
        {
            go.GetComponent<BoxCollider2D>().enabled = false;

        }
        foreach (GameObject go in enemigos)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<CircleCollider2D>().enabled = true;
        }
        foreach (GameObject go in enemigos1)
        {
            Debug.Log("se activo el collider");
            go.GetComponent<BoxCollider2D>().isTrigger = false;
            go.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal")) 
        {
            Debug.Log("BRUH");
            SceneManager.LoadScene(sceneName);
        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo2"))
        {
            this.rb.position = spawn.position;
            Debug.Log("BRUH fuiste");
            
        }
    }
    public void Respawn() 
    {
        if (this.transform.position.y <= -7f) 
        {
            this.rb.position = spawn.position;
        }
    }
    
}
