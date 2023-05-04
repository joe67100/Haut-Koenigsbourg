using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//zone de texte servant à afficher les objectifs
public class DisplayObjective : MonoBehaviour
{
    public UnityEngine.UI.Text objectiveText;
    public GameObject objectiveObject; // Le GameObject contenant le composant "Text"

    public void Start()
    {
        SetText("Objectif : ");
    }

    public void SetText(string text)
    {
        objectiveText.text = text;
        objectiveObject.SetActive(true); // Activer le GameObject contenant le texte
    }
}
