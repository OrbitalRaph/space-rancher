using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float occlusionValue = 0.5f;
    public float impactForceThreshold = 10f;
    public GameObject explosionPrefab;

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
        // Egg does not collide with chickens
        if (collision.gameObject.CompareTag("Chicken"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        // If the egg is hit by a force greater than the threshold, it will explode
        if (collision.impulse.magnitude > impactForceThreshold)
        {
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(explosion, 2f);
            Destroy(gameObject);
        }
    }
}
