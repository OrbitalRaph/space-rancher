using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    public static int nombreDePoulet = 6;
    public static bool musiqueEtSon = true;
    public GameObject caseACocher;
    public TMP_Text textDifficulte;
    private string difficulter = "Facile";


    void Update()
    {
        SetTextDifficulter();

        
    }

    public void MusicAndSound()
    {
        switch (musiqueEtSon)
        {
            case true:
                musiqueEtSon = false;
                break;
            case false:
                musiqueEtSon = true;
                break;
        }
    }

    void SetTextDifficulter()
    {
        textDifficulte.text = "Difficulté : " + difficulter;
    }

    public void Facile()
    {
        nombreDePoulet = 6;
        difficulter = "Facile";
    }

    public void Moyen()
    {
        nombreDePoulet = 10;
        difficulter = "Moyen";
    }

    public void Difficile()
    {
        nombreDePoulet = 15;
        difficulter = "Difficile";
    }
}
