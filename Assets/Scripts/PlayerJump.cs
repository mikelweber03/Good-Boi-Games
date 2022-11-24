using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class PlayerJump : MonoBehaviour
//{
//    public Rigidbody playerRb;
//    public float jumpAmount = 35;
//    public float gravityScale = 10;
//    public float fallingGravityScale = 40;
//    float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * playerRb.gravityScale));
//    // Start is called before the first frame update
//    void Start()
//    {
//        playerRb = GetComponent<Rigidbody>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            playerRb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
//        }
//        if (playerRb.velocity.y >= 0)
//        {
//            playerRb.gravityScale = gravityScale;
//        }
//        else if (playerRb.velocity.y < 0)
//        {
//            playerRb.gravityScale = fallingGravityScale;
//        }

//    }
//    private void FixedUpdate()
//    {
//        playerRb.AddForce(Physics.gravity * (gravityScale - 1) * playerRb.mass);
//    }
//}
