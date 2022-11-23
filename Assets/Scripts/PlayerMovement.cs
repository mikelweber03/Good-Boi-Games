using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool gameOver = false;
    public bool isOnGround = true;
    private Rigidbody playerRb;
    public float movementSpeed = 10f;
    public float jumpForce = 20f;
    public float horizontalInput;
    public float gravityModifier;
    
    [Header("Dashing")]
    public bool canDash = true;
    public float timeBtweDashes;
    public float dashJumpIncrease;
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
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
       
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround )
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
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
        jumpForce = dashJumpIncrease;
        yield return new WaitForSeconds(dashingTime);
        movementSpeed = 10f;
        jumpForce = 20f;
        yield return new WaitForSeconds(timeBtweDashes);
        canDash = true;

        }

}
