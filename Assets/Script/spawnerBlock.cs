using System.Collections;
using UnityEngine;

public class spawnerBlock : MonoBehaviour
{

    public GameObject block; //objects to spawn back
  
    public void RespawnBlock(Vector3 spawnPosition)
    {

        StartCoroutine(Spawnblock(spawnPosition));
    } 

    IEnumerator Spawnblock(Vector3 spawnPosition)
    {
        yield return new WaitForSeconds(5f);
        Instantiate(block, spawnPosition, Quaternion.identity);
    }
}
