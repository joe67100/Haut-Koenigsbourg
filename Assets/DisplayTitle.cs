using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class DisplayTitle : MonoBehaviour
{
    public float displayTime = 5f;
    public UnityEngine.UI.Text titleText;
    public GameObject titleObject; // Le GameObject contenant le composant "Text"

    private float timer = 0.0f;
    private bool isFadingIn = false;
    private bool isDisplaying = false;
    private bool isFadingOut = false;

    private void Start()
    {
        // Initialisation texte en blanc, alpha 0
        titleText.color = new Color(1f, 1f, 1f, 0f);

        // Affichage test
        SetText("Texte Titre");
    }

    private void Update()
    {
        if (isFadingIn)
        {
            titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a + (Time.deltaTime / displayTime));

            // Si le texte est entièrement affiché, on passe à l'étape isDisplaying
            if (titleText.color.a >= 0.95f)
            {
                isFadingIn = false;
                isDisplaying = true;
                timer = 0.0f;
            }
        }
        else if (isDisplaying)
        {
            timer += Time.deltaTime;

            // Si le temps d'affichage est écoulé, on passe à l'étape isFadingOut
            if (timer > displayTime)
            {
                isDisplaying = false;
                isFadingOut = true;
            }
        }
        else if (isFadingOut)
        {
            // Cacher progressivement le texte (diminue l'alpha)
            titleText.color = new Color(titleText.color.r, titleText.color.g, titleText.color.b, titleText.color.a - (Time.deltaTime / displayTime));

            if (titleText.color.a <= 0.0f)
            {
                isFadingOut = false;
            }
        }
    }

    public void SetText(string text)
    {
        titleText.text = text;
        isFadingIn = true;
        timer = 0.0f; // Réinitialiser le timer
    }
}