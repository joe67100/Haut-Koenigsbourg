using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


// Management du texte du titre

public class TitleTextManagement : MonoBehaviour
{
    public GameObject titleText;
    private int time = 0;
    private bool isFadeIn = false;
    private bool isWaiting = false;
    private bool isFadeOut = false;

    void Start()
    {

    }

    // Défini le texte du titre
    public void SetText(string text)
    {
        // si texte différent
        if (titleText.GetComponent<TMPro.TextMeshProUGUI>().text != text)
        {
            titleText.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            titleText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 0);
            isFadeIn = true;
        }
    }

    void Update()
    {

        if (isFadeIn)
        {
            if (time < 100)
            {
                time++;
                titleText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, time / 100f);
            }
            else
            {
                isFadeIn = false;
                isWaiting = true;
                time = 0;
            }
        }
        else if (isWaiting)
        {
            if (time < 100)
            {
                time++;
            }
            else
            {
                isWaiting = false;
                isFadeOut = true;
                time = 0;
            }
        }
        else if (isFadeOut)
        {
            if (time < 100)
            {
                time++;
                titleText.GetComponent<TMPro.TextMeshProUGUI>().color = new Color(1, 1, 1, 1 - time / 100f);
            }
            else
            {
                isFadeOut = false;
                time = 0;
            }
        }
    }
        
}
