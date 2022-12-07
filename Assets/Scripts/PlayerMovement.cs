using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver = false;
    public bool isOnGround = true;
    public bool isOnAir = false;
    public bool crouch = false;
    private LayerMask groundLayer;

    public Vector3 playerPosition;
    private Rigidbody playerRb;
    private BoxCollider boxCollider;
    
    public float movementSpeed;
    public float jumpForce;
    public float horizontalInput;
    public float verticalInput;
    public float gravityModifier;
   

    public float crouchSpeed;
    private Vector3 crouchHigh = new Vector3(0f, 0.7f, 0f);
    private Vector3 crouchScale = new Vector3(1f, 0.4f, 1f);
    private Vector3 standingScale = new Vector3(1, 1, 1);

    [Header("swordAtack")]
    public MeshRenderer swortMeshRenderer;
    public BoxCollider swortBoxCollider;
    bool canAtack = true;
    public float atackTime;
    public float atackCoolDown;

    [Header("NinjaStar")]
    public GameObject ninjaStar;
    public bool canThrow;
    public float throwTime;

    [Header("Dashing")]
    public bool canDash = true;
    public float timeBtweDashes;
    public float dashSpeed;
    public float dashingTime;
    public float startDashTime;

    [Header("Wall Jump")]
    public bool isOnWall = false;
    public float wallJump;
    public bool grounded = true;
    public float climping;
    
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        dashingTime = startDashTime;
        boxCollider = GetComponent<BoxCollider>();



    }

    
    void Update()
    {
        // eingabe für die bewegung in wertikalerweise 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");



        if (!gameOver)
        {
            if (isOnWall)
            {
                playerRb.velocity = Vector3.zero;
                playerRb.angularVelocity = Vector3.zero;
                playerRb.useGravity = false;
                grounded = false;
                transform.Translate(Vector3.up * verticalInput * Time.deltaTime * climping);
                if (isOnWall && Input.GetKeyDown(KeyCode.Space))
                {
                    isOnWall = false;
                    playerRb.useGravity = true;
                    playerRb.AddRelativeForce(-10, 20, 0, ForceMode.Impulse);
                    transform.eulerAngles = this.transform.eulerAngles + new Vector3(0, 180, 0);

                }

            }
            if (!isOnWall && grounded)
            {
                transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed, Space.World);
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

            // let the Player shoot a Ninja Star
            if (Input.GetKeyDown(KeyCode.Q) && !isOnWall)
            {
                NinjaStarAbility();
            }
            
            // let the Player Jump and anables the dubble jump
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !crouch && !isOnWall)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
               // isOnAir = true;
            }
                    // let the player dubble jump with the isOnAir condition
            // else if (Input.GetKeyDown(KeyCode.Space) && isOnAir && !crouch)
            //{
            //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //    isOnAir = false;

            //}
            // shifts the scale of the Player charakter for a bether coruch animation
            if (Input.GetKeyDown(KeyCode.S) && isOnGround && !crouch && !isOnWall)
            {
                crouch = true;
                this.transform.localScale = crouchScale;
                this.transform.localPosition = playerPosition - crouchHigh;

            }
            // Shifts the scale back after crouch
            else if (Input.GetKeyUp(KeyCode.S) && crouch)
            {
                crouch = false;
                this.transform.localScale = standingScale;
                this.transform.localPosition = playerPosition + crouchHigh;
            }

            //let the Player Dash
            if (Input.GetKeyDown(KeyCode.LeftShift) && !crouch)
            {
                DashAbility();
            }

                // Sword atack
            if (Input.GetKeyDown(KeyCode.E) && !crouch && !isOnWall)
            {
                SwordAbility();
                
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("LucianosWorkSpace");
            }
            //else if (!isOnGround)
            //{
            //    crouch = false;
            //    this.transform.localScale = standingScale;
            //    this.transform.localPosition = playerPosition + crouchHigh;
            //}
        }
        

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is on hart surves and gives him the ability to jump again
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            grounded = true;
           
        }
        else if (collision.gameObject.CompareTag("Wall") && !isOnGround)
        {
            isOnWall = true;
            
        }
        
    }

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
        canDash = false;
        movementSpeed = dashSpeed;
        yield return new WaitForSeconds(dashingTime);
        movementSpeed = 10f;
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
        Instantiate(ninjaStar, transform.position, ninjaStar.transform.rotation);
        yield return new WaitForSeconds(throwTime);
        canThrow = true;
    }
    

}
