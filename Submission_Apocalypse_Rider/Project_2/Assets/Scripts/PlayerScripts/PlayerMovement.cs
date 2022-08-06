using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //parameters
    public float speed;
    private float jumpStrength;
    public bool levelFinish { get; private set; }

    [SerializeField]
    private float rotationSpeed;

    //privates
    private Rigidbody2D body;
    private Vector3 jump;
    private bool grounded;
    public PlayerSFXManager playerSFXManager;

    [Header("Animation")]
    private Animator animate;
    private bool isMoving;
    private bool isShooting;

    // Start is called before the first frame update
    void Start()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();
        levelFinish = false;
        jumpStrength = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        if(Input.anyKey == false)
        {
            playerSFXManager.PauseEngineSFX();
            isMoving = false;
        }  
        if ((Input.GetKeyDown(KeyCode.Space) && (grounded)) || (Input.GetKeyDown(KeyCode.UpArrow) && (grounded)))
        {
            body.velocity = new Vector2(body.velocity.x, jumpStrength);
            grounded = false;
            //Vector3 currentPosition = this.gameObject.transform.position;
            //Vector3 newPosition = currentPosition + Vector3.up * jumpStrength;
            //this.gameObject.transform.position = newPosition;
        }
        if (Input.GetKey(KeyCode.RightArrow))   //move right
        {
            playerSFXManager.PlayEngineSFX();
            Vector3 currentPosition = this.gameObject.transform.position;
            Vector3 newPosition = currentPosition + Vector3.right * speed;
            this.gameObject.transform.position = newPosition;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))    //move left
        {
            playerSFXManager.PlayEngineSFX();
            Vector3 currentPosition = this.gameObject.transform.position;
            Vector3 newPosition = currentPosition + Vector3.left * speed;
            this.gameObject.transform.position = newPosition;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, Vector3.left);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        if (isMoving == true)
        {
            animate.SetBool("move", true);
        }
        if (isMoving == false)
        {
            animate.SetBool("move", false);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
        //if(collision.gameObject.CompareTag("Finish"))
        //{
        //    levelFinish = true;
        //    FindObjectOfType<GameManager>().levelFinish();
        //}
    }
}
