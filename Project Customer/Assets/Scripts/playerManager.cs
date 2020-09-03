using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    public float verticalSpeed = 1;
    public float horizontalSpeed = 2;
    public float jumpForce = 10;
    public static int score = 0;
    private Rigidbody rb;
    private bool isGrounded = true;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        
    }

    void Move()
    {
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal") * horizontalSpeed, 0, verticalSpeed);
        Vector3 jumpVector = new Vector3(0, jumpForce, 0);
        transform.Translate(moveVector * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(jumpVector, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ocean")
        {
            isGrounded = true;
        }
    }
}
