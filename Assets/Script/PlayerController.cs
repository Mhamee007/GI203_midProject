using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{{
    private Rigidbody rb;
    private bool isGrounded;
    private bool isAir;
    private float respawnDelay = 2f;

    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 30f;
    float gravity = Physics.gravity.magnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        //Player movement----------------------------------------------------

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed * rb.mass * gravity;//speed walk
        rb.linearVelocity = new Vector3(move.x, rb.linearVelocity.y, move.z) * rb.mass * gravity;//spin of player

        if (Input.GetKey(KeyCode.Space) && isGrounded == true && isAir == false) //Jumping
        {
            rb.AddForce(Vector3.up * rb.mass * gravity * jumpForce, ForceMode.Impulse);
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
