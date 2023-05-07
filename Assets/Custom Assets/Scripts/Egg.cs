using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float occlusionValue = 0.5f;
    public float impactForceThreshold = 10f;
    public GameObject explosionPrefab;

    void Start()
    {
        // Ignore collisions between eggs and chickens
        Physics.IgnoreLayerCollision(6, 6);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the egg if it falls off the map
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the egg is hit by a force greater than the threshold, it will explode
        if (collision.impulse.magnitude > impactForceThreshold)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);
        }
    }
}
