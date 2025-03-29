using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private bool isGrounded;
    private bool isAir;
    
    private float respawnDelay = 2f;
    [SerializeField]float speed = 2.5f;
    [SerializeField] float jumpForce = 25f;

<<<<<<< HEAD
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 30f;
    float gravity = Physics.gravity.magnitude;
=======
>>>>>>> parent of dc9c805 (UpdatePlayerContro)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        //Player movement----------------------------------------------------

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

<<<<<<< HEAD
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed;//speed walk
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);//spin of player
=======
        Vector3 move = new Vector3(moveX, 0, moveZ) * speed;
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z);
>>>>>>> parent of dc9c805 (UpdatePlayerContro)

        if (Input.GetKey(KeyCode.Space) && isGrounded == true && isAir == false) //Jumping
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }

    // On ground and Air cheeck---------------------------------------------
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        isAir = false;

        if (collision.gameObject.CompareTag("wall")) //This player will not run on the wall.
        {
            float moveY = 0f;
            float moveX = 0f;
        }

        if (collision.gameObject.CompareTag("deathZone")) //death player
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        isAir = true;
    }
    
}
