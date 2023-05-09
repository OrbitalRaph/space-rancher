using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenSpawn : MonoBehaviour
{
    public GameObject chicken;
    public float spawnRadius = 5f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {      
        for (int i = 0; i < GameSettings.nombreDePoulet; i++)
        {
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
            spawnPosition.y = transform.position.y;
            GameObject newChicken = Instantiate(chicken, spawnPosition, Quaternion.identity);
            newChicken.GetComponent<Chicken>().player = player;
        } 
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
