using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


// Management du texte du titre

public class ObjectiveTextManagement : MonoBehaviour
{
    public GameObject objectiveText;


    void Start()
    {
        objectiveText.SetActive(true);

        //SetText("Objectifs : \n\n Atteindre la ville");
    }

    // Défini le texte du titre
    public void SetText(string text)
    {
        objectiveText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
    }

    void Update()
    {

    }

}
