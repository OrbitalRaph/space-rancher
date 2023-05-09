using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static int nombreDePoulet = 0;
    public static bool musiqueEtSon = true;
    public GameObject caseACocher;
    public GameObject boutonFacile;
    public GameObject boutonMoyen;
    public GameObject boutonDifficile;


    void Update()
    {
        VerifierSon();
        VerifierDifficulte();
    }

    void VerifierSon()
    {
        if (caseACocher.GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            musiqueEtSon = false;
        }
        else
        {
            musiqueEtSon = false;
        }
    }

    void VerifierDifficulte()
    {
        if (boutonFacile.GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            nombreDePoulet = 4;
            boutonFacile.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
            boutonMoyen.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
            boutonDifficile.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
        }
        else if (boutonMoyen.GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            nombreDePoulet = 8;
            boutonFacile.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
            boutonMoyen.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
            boutonDifficile.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
        }
        else if (boutonDifficile.GetComponent<UnityEngine.UI.Toggle>().isOn)
        {
            nombreDePoulet = 14;
            boutonFacile.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
            boutonMoyen.GetComponent<UnityEngine.UI.Toggle>().interactable = true;
            boutonDifficile.GetComponent<UnityEngine.UI.Toggle>().interactable = false;
        }
    }
}
