using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControleurAnimMains : MonoBehaviour
{
    [SerializeField] private InputActionProperty actionTrigger;
    [SerializeField] private InputActionProperty actionGrip;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float valeurTrigger = actionTrigger.action.ReadValue<float>();
        float valeurGrip = actionGrip.action.ReadValue<float>();
        anim.SetFloat("Trigger", valeurTrigger);
        anim.SetFloat("Grip", valeurGrip);
    }
}
