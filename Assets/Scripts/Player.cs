using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityStandardAssets;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float jumpdistance = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(0, 40f);
     [SerializeField] float LevelLoadDelay = 2f;
       [SerializeField] float DeathSlowMoFactor = 0.2f;
       [SerializeField] public LayerMask WhatIsLadder;
       [SerializeField] public LayerMask WhatIsGround;
    private bool isClimbing;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;

    private int extraJumps;
    public int extraJumpValues;

    //  bool isAlive = true;

    //Declar component references
    Rigidbody2D myRigidBody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider2D;
    // BoxCollider2D myFeet;
    float gravityScaleAtStart;
    // bool jumping = false;

    void Start()
    {
        myRigidBody =GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        // myFeet = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myRigidBody.gravityScale;
        extraJumps = extraJumpValues;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    //    isGrounded  = myFeet.IsTouchingLayers(WhatIsGround);
        isGrounded  = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);
    //    print(WhatIsGround);
        if(!PlayerHealth.isAlive){
            return;
        }
        ClimbLadder();
        if(isGrounded){ 
            extraJumps = extraJumpValues;
            }
        Jump();
        // Die();
    }
     void FixedUpdate() {
       
         Run();
         FlipSprite();
    }
     private void Jump(){
       

    
        if(Input.GetButtonDown("Jump") && extraJumps > 0){    
            myRigidBody.velocity = Vector2.up * jumpSpeed;
            extraJumps--;
            // FindObjectOfType<VerticalPlatfrom>().effector2D.rotationalOffset = 0;
            // Debug.Log( myRigidBody.velocity);
        }
         else if (Input.GetButtonDown("Jump") && extraJumps ==0 && isGrounded == true){
            myRigidBody.velocity = Vector2.up * jumpSpeed;
        }
       
 
    }

     private void Run() {
         float controlThrow = UnityEngine.Input.GetAxisRaw("Horizontal"); //value (-1 · +1)
         Vector2 playerVelocity ;
         if(!isGrounded){
             playerVelocity = new Vector2(controlThrow * runSpeed *1.5f , myRigidBody.velocity.y);
         }
         else{
               playerVelocity = new Vector2(controlThrow * runSpeed, myRigidBody.velocity.y);
         }
        
       
        myRigidBody.velocity = playerVelocity;
        
         bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Running", playerHasHorizontalSpeed);
    }

    private void ClimbLadder(){
        // RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 100, WhatIsLadder);
        // print(hitInfo.collider);
        bool hitInfo  = myRigidBody.IsTouchingLayers(LayerMask.GetMask("Climbing")); //TODO move player to center of ladder 
        // print(myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing")));
        // if(myFeet.IsTouchingLayers(LayerMask.GetMask("Climbing"))){
        if(hitInfo && (Input.GetKey("up") ||Input.GetKey("down")) ){
                // if(){
                    isClimbing = true;

                // }
        } else {
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
                isClimbing = false;
            }
        }
        if(isClimbing == true && hitInfo){
            float controlThrow = Input.GetAxis("Vertical");
 
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, controlThrow * climbSpeed);;
            myRigidBody.gravityScale = 0f;
            // bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            myAnimator.SetBool("Climbing", true);
        }else{
            myRigidBody.gravityScale = gravityScaleAtStart;
             myAnimator.SetBool("Climbing", false);
        }
    }

   
    private void FlipSprite(){
        //turn around
         bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHasHorizontalSpeed){
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), 1f);
        }
    }

    //  private void Die(){
    //     if(myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards") ) & isAlive){
    //         isAlive = false;
    //         print("I am die");
    //         myAnimator.SetTrigger("Dying");
    //         StartCoroutine(ExampleCoroutine());
    //         GetComponent<Rigidbody2D>().velocity = deathKick;//希望以后能disable物理碰撞，而不是抛飞出去。。
            
    //     }
//     }
// IEnumerator ExampleCoroutine()
// // void ExampleCoroutine()
//     {
//         Time.timeScale = DeathSlowMoFactor;

//         //yield on a new YieldInstruction that waits for 5 seconds.
//         yield return new WaitForSecondsRealtime(1f);
//         Time.timeScale = 1f;
//         FindObjectOfType<GameSession>().ProcessPlayDeath(GetComponent<Collider2D>());
  
//     }

    // public void Revive(){
    //     isAlive = true;
    //     print("Reviving!");
    //     myAnimator.SetTrigger("Dying");
    // }
}