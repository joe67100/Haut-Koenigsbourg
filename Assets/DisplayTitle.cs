using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DisplayTitle : MonoBehaviour
{
    public float displayTime = 5f;
    public UnityEngine.UI.Text titleText;
    public GameObject titleObject; // Le GameObject contenant le composant "Text"

    private float timer = 0.0f;
    private bool isDisplaying = false;

    private void Start()
    {
        // Initialisation texte en transparent
        titleText.color = Color.clear; 
        titleObject.SetActive(false);

        // Affichage test
        SetText("Test");
    }

    private void Update()
    {
        if (isDisplaying)
        {
            timer += Time.deltaTime;

            // Afficher progressivement le texte (augmente l'alpha)
            titleText.color = Color.Lerp(Color.clear, Color.white, timer / displayTime);

            // Si le temps d'affichage est écoulé, cacher le texte
            if (timer > displayTime)
            {
                isDisplaying = false;
                titleObject.SetActive(false);
            }
        }
    }

    public void SetText(string text)
    {
        titleText.text = text;
        titleObject.SetActive(true); // Activer le GameObject contenant le texte
        isDisplaying = true;
        timer = 0.0f; // Réinitialiser le timer
    }
}