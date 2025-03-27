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
           player.transform.position = spawnPoint.position;
           SpawnPlayer();
        }
    }

    public void SpawnPlayer()
    {
        Instantiate(player, spawnPoint.position, Quaternion.identity);
       
    }
    //-----------------------------------------------------------------------


}
