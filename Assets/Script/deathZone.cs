using UnityEngine;
using UnityEngine.Rendering.Universal;

public class deathZone : MonoBehaviour
{
    public GameObject player;
    public Transform spawnPoint;

    // Spawning and GameOver---------------------------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           player.transform.position = spawnPoint.position; //tranfer player to respawn position
           SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        GameObject newPlayer = Instantiate(player, spawnPoint.position, Quaternion.identity);  //update the new player reference after death
        FindObjectOfType<followcamera>().SetNewPlayer(newPlayer.transform);  // Find the camera and update the new player reference

    }
    //-----------------------------------------------------------------------


}
