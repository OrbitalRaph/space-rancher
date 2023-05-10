using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameController : MonoBehaviour
{
    public int numChickensCaptured = 0;
    public int numChickensToCatch = GameSettings.nombreDePoulet;
    public bool isGameOver = false;
    public GameObject[] ChickenSpawners;
    public AudioMixer audioMixer;

    void Start()
    {
        for (int i = 0; i < GameSettings.nombreDePoulet; i++)
        {
            int randomIndex = Random.Range(0, ChickenSpawners.Length);
            GameObject chickenSpawner = ChickenSpawners[randomIndex];
            chickenSpawner.GetComponent<ChickenSpawn>().SpawnChicken();
        }
        SonEtMusique();
    }

    private void OnEnable()
    {
        Chicken.OnChickenCaptured += ChickenCaptured;
    }

    private void OnDisable()
    {
        Chicken.OnChickenCaptured -= ChickenCaptured;
    }

    void SonEtMusique()
    {
        if (GameSettings.musiqueEtSon == true)
        {
            audioMixer.SetFloat("Music", 0);
            audioMixer.SetFloat("Effects", 0);
        }
        else
        {
            audioMixer.SetFloat("Music", -80);
            audioMixer.SetFloat("Effects", -80);
        }
    }

    void ChickenCaptured()
    {
        numChickensCaptured++;
        Debug.Log("Chickens Captured: " + numChickensCaptured);
        if (numChickensCaptured >= numChickensToCatch)
        {
            isGameOver = true;
            Debug.Log("Game Over!");
        }
    }
}
