using System.Collections;
using UnityEngine;

public class spawnerBlock : MonoBehaviour
{

    public GameObject block; //objects to spawn back
    public Transform spawnBlock; //block spawnposition

    public void RespawnBlock()
    {
        StartCoroutine(Spawnblock());
    } 

    IEnumerator Spawnblock()
    {
        yield return new WaitForSeconds(5f);
        Instantiate(block, spawnBlock.position, Quaternion.identity);
    }
}
