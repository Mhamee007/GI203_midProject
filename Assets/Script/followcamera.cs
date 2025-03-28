using UnityEngine;

public class followcamera : MonoBehaviour
{
    public Transform player; 
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothSpeed = 5f;// Smooth movement speed

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    public void SetNewPlayer(Transform newPlayer) //set new player after death
    {
        player = newPlayer;
    }
}
