using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Canvas management

public class ScoreboardCanvas : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    public void HideCanvas()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void ShowCanvas()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}
