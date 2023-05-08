using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenTank : MonoBehaviour
{
    private ParticleSystem particles;

    // Start is called before the first frame update
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        Chicken.OnChickenCaptured += ChickenCaptured;
    }

    private void OnDisable()
    {
        Chicken.OnChickenCaptured -= ChickenCaptured;
    }

    void ChickenCaptured()
    {
        particles.Emit(1);
    }
}
