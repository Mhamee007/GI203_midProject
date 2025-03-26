using UnityEngine;

public class JumpBooster : MonoBehaviour
{

    [SerializeField] float jumpBoostForce = 13f;
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Make sure your player has the tag "Player"
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset Y velocity
                rb.AddForce(Vector3.up * jumpBoostForce, ForceMode.Impulse); // Add upward force
            }
        }

    }
}
