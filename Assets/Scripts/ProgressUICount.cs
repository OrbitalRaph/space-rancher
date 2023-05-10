using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ProgressUICount : MonoBehaviour
{
    private TMP_Text text;
    public int count = 0;
    public int maxCount;

    void Start()
    {
        maxCount = GameSettings.nombreDePoulet;
        text = GetComponent<TMP_Text>();
        text.text = count + "/" + maxCount;
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
        count++;
        text.text = count + "/" + maxCount;
    }
}
