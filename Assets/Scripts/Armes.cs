using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armes : MonoBehaviour
{
    public bool inHand = false;
    public GameObject weaponSlot;
    private Rigidbody rb;
    private GameObject weapon;
    public Quaternion rotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        weapon = gameObject;
    }

    void Update()
    {
        if (rb.isKinematic)
        {
            inHand = true;
        }
        else
        {
            inHand = false;
        }

        AddWeaponToBelt();
    }

    //ajouter à la ceinture du joueur
    private void AddWeaponToBelt()
    {
        if (!inHand)
        {
            weapon.transform.parent = weaponSlot.transform;
            weapon.transform.localPosition = Vector3.zero; 
            weapon.transform.localRotation = rotation;

        }
    }
}
