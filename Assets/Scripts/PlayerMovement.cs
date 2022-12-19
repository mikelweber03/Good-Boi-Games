using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver = false;
    public bool isOnGround = true;
    public bool crouch = false;

    public Vector3 playerPosition;
    private Rigidbody playerRb;
    
    private float movementSpeed = 15f;
    private float jumpForce = 26f;
    private float horizontalInput;
    private float verticalInput;
    private float gravityModifier = 5f;

    [Header("swordAtack")]
    public MeshRenderer swortMeshRenderer;
    public BoxCollider swortBoxCollider;
    bool canAtack = true;
    private float atackTime = 0.4f;
    private float atackCoolDown = 0.3f;

    [Header("NinjaStar")]
    public GameObject ninjaStar;
    public bool canThrow;
    public float throwTime;

    [Header("Dashing")]
    public ParticleSystem smoke;
    public bool dashJump;
    private float dashJumpForce = 24f;
    public SpriteRenderer nagatoSprite;
    public SpriteRenderer cloud;
    public bool dashBlock = false;
    public bool canDash = true;
    private float timeBtweDashes = 1.75f;
    private float dashForce = 60f;
    private float dashingTime = 0.2f;
    //private float dashDelay = 0.2f;
    //public float dashJumpTime;
    public bool floatTime = true;

    [Header("Wall Jump")]
    public bool isOnWall = false;
    //private float wallJump;
    public bool grounded = true;
    private float climping = 5f;
    
    void Start()
    { 
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    
    void Update()
    {
        // eingabe für die bewegung in wertikalerweise 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // let the Player shoot a Ninja Star
        if (Input.GetKeyDown(KeyCode.Q) && !isOnWall && !crouch || Input.GetKeyDown(KeyCode.Joystick1Button1) && !isOnWall && !crouch)
        {
            NinjaStarAbility();
        }


        // macht die mögliochkeiten um an der wand zu kleben sowie einen walljump
        if (isOnWall)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
                playerRb.useGravity = false;
                grounded = false;
                dashJump = false;
                transform.Translate(Vector3.up * verticalInput * Time.deltaTime * climping);
                if (isOnWall && Input.GetKeyDown(KeyCode.Space) || isOnWall && Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    isOnWall = false;
                    playerRb.useGravity = true;
                    playerRb.AddRelativeForce(-10, 20, 0, ForceMode.Impulse);
                    transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 180, 0);

                }


                // release from wall
                else if (isOnWall && Input.GetKeyDown(KeyCode.Q) || isOnWall && Input.GetKeyDown(KeyCode.Joystick1Button1))
            {  
                playerRb.useGravity = true;
                playerRb.AddRelativeForce(-1, 3, 0, ForceMode.Impulse);
                isOnWall = false;
                grounded = true;

            }

        }
                // Player Movement HorizontalInput
            if (!isOnWall && grounded && !dashBlock)
            {
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed, Space.World);
            //   playerRb.AddForce(0f,1f * horizontalInput * Time.deltaTime * movementSpeed, ((float)Space.World), ((float)ForceMode.Force));
            //Debug.Log((float)Space.World);
            //Debug.Log((float)ForceMode.Force);
        }


        playerPosition = transform.position;


           // flipp the player sprite

            if(horizontalInput < 0 && !isOnWall && grounded)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0f,  180f , 0f));
            }
            
            if (horizontalInput > 0 && !isOnWall && grounded)
            {
                 this.transform.rotation = Quaternion.Euler(new Vector3(0f,  0f, 0f));

            }

        
        // sprung nach dem dash
        if (Input.GetKeyDown(KeyCode.Space) && dashJump && !crouch && !isOnWall && !isOnGround || Input.GetKeyDown(KeyCode.Joystick1Button0) && dashJump && !crouch && !isOnWall && !isOnGround)
        {
            
            playerRb.useGravity = true;
            dashBlock = false;
            grounded = true;
            isOnGround = false;
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * dashJumpForce, ForceMode.Impulse);
            dashJump = false;
            
        }

            // let the Player Jump 
            else if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !crouch && !isOnWall || Input.GetKeyDown(KeyCode.Joystick1Button0) && isOnGround && !crouch && !isOnWall)
            {
            playerRb.velocity = Vector3.zero;
            playerRb.angularVelocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                
            }
                    
            //let the Player Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && !crouch || Input.GetKeyDown(KeyCode.Joystick1Button4) && !crouch)
            {
                DashAbility();
            }

                // Sword atack
            if (Input.GetKeyDown(KeyCode.E) && !crouch && !isOnWall || Input.GetKeyDown(KeyCode.Joystick1Button2) && !crouch)
            {
                SwordAbility();
                
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("LucianosWorkSpace");
            }
            

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is on hart surves and gives him the ability to jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dashJump = false;
            grounded = true;
           
        }
        else if (collision.gameObject.CompareTag("Wall") && !isOnGround)
        {
            isOnWall = true;
            dashJump = false;
            
        }
        
    }
        // check ob spieler an der wand ist
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            isOnWall = false;
            playerRb.useGravity = true;
        }
    }


    // void for the Dash Ability
    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    // Coroutine for the dash
    IEnumerator Dash()
    {
        dashBlock = true;
        canDash = false;
        nagatoSprite.enabled = false;
        //smoke.Play();
        yield return new WaitForSeconds(0.05f);
        cloud.enabled = true;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        playerRb.useGravity = false;
        playerRb.AddRelativeForce(dashForce, 0, 0, ForceMode.Impulse);
        yield return new WaitForSeconds(dashingTime);
        cloud.enabled = false;
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
        yield return new  WaitForSeconds(0.05f);
        nagatoSprite.enabled = true;
        dashJump = true;
        yield return new WaitForSeconds(0.1f);
        dashBlock = false;
        grounded = true;
        playerRb.useGravity = true;
        yield return new WaitForSeconds(timeBtweDashes);
        canDash = true;    
    }

    void SwordAbility()
    {
        if (canAtack)
        {
            StartCoroutine(SwordAttack());
            
        }
            
    }

    IEnumerator SwordAttack()
    {
        canAtack = false;
        swortMeshRenderer.enabled = true;
        swortBoxCollider.enabled = true;
        yield return new WaitForSeconds(atackTime);
        swortMeshRenderer.enabled = false;
        swortBoxCollider.enabled = false;
        yield return new WaitForSeconds(atackCoolDown);
        canAtack = true;
    }


    void NinjaStarAbility()
    {
        if (canThrow)
        {
            StartCoroutine(NinjaStardAttack());

        }

    }

    IEnumerator NinjaStardAttack()
    {
        canThrow = false;
        Instantiate(ninjaStar, transform.position, playerRb.transform.rotation );
        yield return new WaitForSeconds(throwTime);
        canThrow = true;
    }
    

}
