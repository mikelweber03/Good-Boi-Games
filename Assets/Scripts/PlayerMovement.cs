using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver = false;
    public bool isOnGround = true;
    public bool isOnAir = true;
    public bool crouch = false;

    public Vector3 playerPosition;
    private Rigidbody playerRb;
    public float movementSpeed;
    public float jumpForce;
    public float horizontalInput;
    public float gravityModifier;

    public float crouchSpeed;
    private Vector3 crouchHigh = new Vector3(0f, 0.7f, 0f);
    private Vector3 crouchScale = new Vector3(1f, 0.4f, 1f);
    private Vector3 standingScale = new Vector3(1, 1, 1);

    //[Header("Jumping")]
    //public float buttonTime = 0.3f;
    //public float jumpTime;
    //public bool jumping;
    
    [Header("Dashing")]
    public bool canDash = true;
    public float timeBtweDashes;
    // public float dashJumpIncrease;
    public float dashSpeed;
    public float dashingTime;
    public float startDashTime;
    

    // Start is called before the first frame update
    void Start()
    {
        
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        dashingTime = startDashTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        // eingabe für die bewegung in wertikalerweise 
        horizontalInput = Input.GetAxis("Horizontal");
        if (!gameOver)
        {

            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * movementSpeed);

            playerPosition = transform.position;

            if (Input.GetKeyDown(KeyCode.LeftShift) && !crouch)
            {
                DashAbility();
            }

            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !crouch)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                isOnAir = true;
            }
            else if (Input.GetKeyDown(KeyCode.Space) && isOnAir && !crouch)
            {
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnAir = false;

            }
            if (Input.GetKeyDown(KeyCode.S) && isOnGround && !crouch)
            {
                crouch = true;
                this.transform.localScale = crouchScale;
                this.transform.localPosition = playerPosition - crouchHigh;

            }
            else if (Input.GetKeyUp(KeyCode.S) && crouch)
            {
                crouch = false;
                this.transform.localScale = standingScale;
                this.transform.localPosition = playerPosition + crouchHigh;
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

        }
        
    }
    void DashAbility()
    {
        if (canDash)
        {
            StartCoroutine(Dash());
        }
    }
    IEnumerator Dash()
    {
        canDash = false;
        movementSpeed = dashSpeed;
        yield return new WaitForSeconds(dashingTime);
        movementSpeed = 10f;
        yield return new WaitForSeconds(timeBtweDashes);
        canDash = true;

        }

}
