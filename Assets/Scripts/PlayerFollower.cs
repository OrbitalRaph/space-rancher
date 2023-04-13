using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    private GameObject follower;
    public GameObject player;

    void Start()
    {
        follower = gameObject;
    }

    void Update()
    {
        follower.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
        follower.transform.rotation = new Quaternion(0, player.transform.rotation.y, 0, player.transform.rotation.w);

    }
}
