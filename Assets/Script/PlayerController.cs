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


    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    void Update() 
    {
        //Player movement----------------------------------------------------

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);

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

        if (collision.gameObject.CompareTag("wall")) //This player will not run om the wall.
        {
            float moveY = 0f;
            float moveX = 0f;
        }

        if (collision.gameObject.CompareTag("deathZone")) //This player will not run om the wall.
        {
            Destroy(gameObject);
            FindObjectOfType<PlayerController>().SpawnPlayer();

        }
    }
    void OnCollisionExit(Collision collision)
    {
        isAir = true;
    }
 
    // Spawning and GameOver--------------------------------------------------------------
    public GameObject playerPrefab;
    public Transform respawnPoint;
    public void SpawnPlayer()
    {

        Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
    }
    //-----------------------------------------------------------------------

}
