using UnityEngine;
using UnityEngine.Rendering.Universal;

public class deathZone : MonoBehaviour //the zone that will kill player if touches and bring player to spwanpoint
{
    public GameObject player;
    public Transform spawnPoint;

    // Spawning and GameOver---------------------------------------------------
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           player.transform.position = spawnPoint.position; //tranfer player to respawnpoint
           SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        GameObject newPlayer = Instantiate(player, spawnPoint.position, Quaternion.identity);  //update the new player reference after death and spawn at respawnpoint
        FindObjectOfType<followcamera>().SetNewPlayer(newPlayer.transform);  // Find the camera and move canera to new player reference that set (this code get from followcamera)
    }
    //-----------------------------------------------------------------------


}
