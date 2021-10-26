using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float walkspeed;
    [SerializeField] private float runspeed;
    [SerializeField] private float jumpforce;
    [SerializeField] private float diveforce;
    [SerializeField] private float horiFlipKick;
    [SerializeField] private float vertiFlipKick;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask golem;
    public Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private float leftOrRight;
    private float diveCount;
    private float flipKickCount;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
 

    // Update is called once per frame
    void Update()
    {
        Vector3 characterScale = transform.localScale;

        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        if(Input.GetAxis("Horizontal") > 0)
        {
            leftOrRight = 1;
            characterScale.x = 1;
            anim.SetBool("anspeed", true);
        } 
        if(Input.GetAxis("Horizontal") < 0)
        {
            leftOrRight = -1;
            characterScale.x = -1;
            anim.SetBool("anspeed", true);
            
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            anim.SetBool("anspeed", false);
        }
        transform.localScale = characterScale;

    if (Input.GetKeyDown(KeyCode.Z))
    {
        if(isGrounded()){
           Jump();
           
           Debug.Log("Z hit");
        }
        if(isLeftWallJumped()){
            Jump();
            anim.SetBool("anwalljump", true);
             characterScale.x = -1;
        }
        if(isRightWallJumped()){
            Jump();
            anim.SetBool("anwalljump", true);
             characterScale.x = -1;
        }
       
    }
     transform.localScale = characterScale;
    if(!isGrounded()){
        anim.SetBool("anjump", true);
    }

       if(Input.GetKeyDown(KeyCode.X))
    {
        if(diveCount < 1){
        anim.SetBool("andive", true);
        Dive();
        Debug.Log ("X hit");
        diveCount = diveCount + 1;
        }
     
    }

      if(Input.GetKeyDown(KeyCode.LeftShift))
    {
        Run();

    }
    if(Input.GetKeyUp(KeyCode.LeftShift))
    {
        speed = walkspeed;
    }

    if(Input.GetKeyDown(KeyCode.C))
    {
        if(flipKickCount < 1){
            anim.SetBool("anflipkick", true);
            FlipKick();
            flipKickCount = flipKickCount + 1;
            characterScale.x = -1;
        }
      
    }

    if(Input.GetKeyDown(KeyCode.Escape))
    {
        Application.Quit();
    }

    if(isGrounded())
    {
        diveCount = 0;
        flipKickCount = 0;
        anim.SetBool("andive", false);
        anim.SetBool("anflipkick", false);
        anim.SetBool("anjump", false);
        anim.SetBool("anwalljump", false);
    }

    }

    private void Run()
    {
      speed = runspeed;
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        Debug.Log(rb.velocity.y);
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
    return raycastHit.collider != null;
    }

    private bool isLeftWallJumped()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.left, 0.1f, groundLayer);
        return raycastHit.collider !=null;
    }
    
     private bool isRightWallJumped()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.right, 0.1f, groundLayer);
        return raycastHit.collider !=null;
    }

   
   
    private void FlipKick(){
        rb.AddForce(new Vector2(horiFlipKick * leftOrRight, vertiFlipKick));
    }

    private void Dive()
    {
        rb.AddForce(new Vector2(leftOrRight * diveforce , rb.velocity.y));
        
      
    }

    
}
