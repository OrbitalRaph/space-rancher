using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chicken : MonoBehaviour
{

    public delegate void ChickenCaptureEvent();
    public static event ChickenCaptureEvent OnChickenCaptured;

    [Header("Movement")]
    public float walkSpeed = 0.5f;
    public float runSpeed = 1f;
    public float rotationSpeed = 2f;
    public float distanceTrigger = 1f;
    public float distanceMax = 4f;
    private float distanceToPlayer;
    private bool isRunningAway = false;
    private bool isWalking = false;
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private Vector3 direction;
    public Transform player;
    private Animator animator;
    private Rigidbody rb;

    [Header("Capture")]
    public float maxCaptureProgress = 100f;
    public float captureDecreaseRate = 1f;
    
    public GameObject captureProgressMeter;
    public GameObject eggPrefab;
    public ParticleSystem chickenParticlePrefab;
    private float captureProgress = 0f;
    private bool isCapturing = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < distanceTrigger)
        {
            RunAway();
        }
        else
        {
            RandomMovement();
        }

        captureProgressMeter.GetComponent<Image>().fillAmount = captureProgress / maxCaptureProgress;
    }

    private void FixedUpdate()
    {
        if (captureProgress > 0 && !isCapturing)
        {
            captureProgress -= captureDecreaseRate * Time.deltaTime;
        }

        rb.AddForce(Physics.gravity * 0.2f, ForceMode.Acceleration);
    }

    private void LateUpdate()
    {
        captureProgressMeter.transform.LookAt(transform.position + Camera.main.transform.forward);
    }

    private void RunAway()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);

        Vector3 directionFuite = transform.position - player.position;
        directionFuite.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionFuite), rotationSpeed * Time.deltaTime);
        rb.velocity = transform.forward * runSpeed;

        if (distanceToPlayer > distanceMax)
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("Run", false);
            isRunningAway = false;
        }
    }

    private void RandomMovement()
    {
        int randomMovement = Random.Range(1, 3);
        int randomTime = Random.Range(1, 4);

        if (!isWalking && !isRotatingLeft && !isRotatingRight && !isRunningAway)
        {
            switch (randomMovement)
            {
                case 1:
                    StartCoroutine(MoveForward(randomTime));
                    break;
                case 2:
                    StartCoroutine(RotateLeft(randomTime));
                    break;
                case 3:
                    StartCoroutine(RotateRight(randomTime));
                    break;
            }
        }

    }

    IEnumerator MoveForward(int time)
    {
        isWalking = true;
        animator.SetBool("Walk", true);
        animator.SetBool("Run", false);
        rb.velocity = transform.forward * walkSpeed;
        yield return new WaitForSeconds(time);
        rb.velocity = Vector3.zero;
        isWalking = false;
        yield return new WaitForSeconds(1);
    }

    IEnumerator RotateLeft(int time)
    {
        isRotatingLeft = true;
        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        int randomAngle = Random.Range(45, 130);
        transform.Rotate(0, -randomAngle, 0);
        yield return new WaitForSeconds(time);
        isRotatingLeft = false;
        yield return new WaitForSeconds(1);
    }

    IEnumerator RotateRight(int time)
    {
        isRotatingRight = true;
        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        int randomAngle = Random.Range(45, 130);
        transform.Rotate(0, randomAngle, 0);
        yield return new WaitForSeconds(time);
        isRotatingRight = false;
        yield return new WaitForSeconds(1);
    }

    public void Capturing(float captureRate)
    {
        isCapturing = true;
        captureProgress += captureRate;
        captureProgress = Mathf.Clamp(captureProgress, 0f, maxCaptureProgress);

        if (captureProgress >= maxCaptureProgress)
        {   
            OnChickenCaptured?.Invoke();
            Instantiate(chickenParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
        if (captureProgress >= maxCaptureProgress / 3f && Random.Range(0, 200) < 1)
        {
            GameObject egg = Instantiate(eggPrefab, transform.position + Vector3.up * 0.3f, Quaternion.identity);
        }

        if (Random.Range(0, 100) < 1)
        {
            GetComponent<AudioSource>().Play();
        }

        isCapturing = false;
    }
}
