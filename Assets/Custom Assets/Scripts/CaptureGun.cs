using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class CaptureGun : MonoBehaviour
{
    public GameObject VacuumEffect;
    public float captureWidth = 0.8f;
    public float captureHeight = 0.8f;
    public float captureRange = 1.5f;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = -1.1f;
    public float captureSpeed = 15f;
    public float eggGravitationalPull = 0.1f;
    private float currentCaptureSpeed;
    private float eggOcclusionValue = 0f;
    public LayerMask chickenLayer;
    public XRNode rightHandController;
    private InputDevice rightHand;
    private Rigidbody gunRb;

    // Start is called before the first frame update
    void Start()
    {
        gunRb = GetComponent<Rigidbody>();
        currentCaptureSpeed = captureSpeed;
        VacuumEffect.SetActive(false);
        Physics.IgnoreLayerCollision(7, 8);
        InitController();
    }

    void InitController()
    {
        rightHand = InputDevices.GetDeviceAtXRNode(rightHandController);
    }

    // Update is called once per frame
    void Update()
    {
        if (!rightHand.isValid)
        {
            InitController();
        }

        //if the gun is being held and the trigger is pressed, capture chickens and eggs
        if (gunRb.isKinematic)
        {
            if (rightHand.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.5f)
            {
                VacuumEffect.SetActive(true);
                // play the vacuum sound
                GetComponent<AudioSource>().Play();

                eggOcclusionValue = 0f;
                Collider[] colliders = Physics.OverlapBox(transform.position + transform.forward * offsetZ + transform.up * offsetY + transform.right * offsetX, new Vector3(captureWidth, captureHeight, captureRange) / 2, transform.rotation, chickenLayer);
                foreach (Collider col in colliders)
                {
                    Chicken chicken = col.GetComponent<Chicken>();
                    if (chicken != null)
                    {
                        chicken.Capturing(currentCaptureSpeed * Time.deltaTime);

                    }

                    Egg egg = col.GetComponent<Egg>();
                    if (egg != null)
                    {
                        eggOcclusionValue += egg.occlusionValue;
                        // pull the egg towards the gun and counter the world gravity to male it float
                        egg.GetComponent<Rigidbody>().AddForce((transform.position - egg.transform.position).normalized * eggGravitationalPull);
                        egg.GetComponent<Rigidbody>().AddForce(Vector3.up * 9.81f * 1.5f);

                    }
                }

                // Update capture speed based on occlusion, cannot go under 0
                currentCaptureSpeed = captureSpeed - eggOcclusionValue * captureSpeed;
                if (currentCaptureSpeed < 0)
                {
                    currentCaptureSpeed = 0;
                }
            }
            else
            {
                VacuumEffect.SetActive(false);
                GetComponent<AudioSource>().Stop();
            }
        }

    }

    // Draw the capture range in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.matrix = Matrix4x4.TRS(transform.position + transform.forward * offsetZ + transform.up * offsetY + transform.right * offsetX, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(captureWidth, captureHeight, captureRange));
    }
}
