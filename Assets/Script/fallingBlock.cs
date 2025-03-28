using System.Collections;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{
    private Rigidbody rb;
    private float fallDelay = 0.3f;
   


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnCollisionEnter(Collision collision) //check if player is on the block
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FallAfterDelay()); 
        }
    }

    IEnumerator FallAfterDelay() //Block falling
    {
        yield return new WaitForSeconds(fallDelay); // Wait for fallDelay seconds
        rb.isKinematic = false; 
        rb.useGravity = true;

        yield return new WaitForSeconds(1.5f); // Wait for before destroys the block
        
        Destroy(gameObject);

        FindObjectOfType<spawnerBlock>().RespawnBlock(); //calling code from spawnerBlock tp respawn

    }


}
