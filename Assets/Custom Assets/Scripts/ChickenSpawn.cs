using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject chicken;
    public float spawnRadius = 5f;
    public Transform player;

    public void SpawnChicken()
    {
        Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPos.y = transform.position.y;
        GameObject newChicken = Instantiate(chicken, spawnPos, Quaternion.identity);
        newChicken.GetComponent<Chicken>().player = player;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
