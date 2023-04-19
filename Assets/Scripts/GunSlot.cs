using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSlot : MonoBehaviour
{
    //will follow the rotation of the player
    public GameObject playerFollower;
    private GameObject gunSlot;


    // Start is called before the first frame update
    void Start()
    {
        gunSlot = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
