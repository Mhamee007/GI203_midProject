using System.Collections;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{
    private Rigidbody rb;
    private float fallDelay = 0.5f;

    public GameObject block;
    public Transform spawnBlock;



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

        yield return new WaitForSeconds(1f); // Wait for before destroys the block
        Destroy(gameObject);

    }
    

    void OnDestroy()
    {
        StartCoroutine(Spawnblock());
    }

    IEnumerator Spawnblock()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(block, spawnBlock.position, Quaternion.identity);
    }


}
