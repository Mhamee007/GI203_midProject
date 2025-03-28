using System.Collections;
using UnityEngine;

public class fallingBlock : MonoBehaviour
{
    private Rigidbody rb;
    private float fallDelay = 0.3f;
    private Vector3 originalPosition;
    public spawnerBlock mySpawner;   // Reference to the specific spawner for this block

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;

        // Store the original position of THIS block
        originalPosition = transform.position;

        // Find the closest spawner to this block
        mySpawner = FindClosestSpawner();
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

        yield return new WaitForSeconds(1.3f); // Wait for before destroys the block
        
        Destroy(gameObject);

        spawnerBlock spawner = FindObjectOfType<spawnerBlock>(); //calling code from spawnerBlock ot respawn

        if (spawner != null) //check is spawner is true
        {
            spawner.RespawnBlock(originalPosition);
        }

    }

    // Find the closest spawner to this block
    private spawnerBlock FindClosestSpawner()
    {
        spawnerBlock[] spawners = FindObjectsOfType<spawnerBlock>();
        spawnerBlock closest = null;
        float minDistance = Mathf.Infinity;

        foreach (spawnerBlock spawner in spawners)
        {
            float distance = Vector3.Distance(transform.position, spawner.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = spawner;
            }
        }

        return closest;
    }


}
