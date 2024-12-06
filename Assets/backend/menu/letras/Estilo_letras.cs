using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    private Graphic graphic;
    //private bool isFadingIn = true; // Controla si estamos desvaneciendo hacia adentro o hacia afuera

    void Start()
    {
        graphic = GetComponent<Graphic>();
        graphic.canvasRenderer.SetAlpha(0); // Asegúrate de que el texto comience completamente transparente
        FadeIn(); // Comienza con la aparición del texto
    }

    void FadeIn()
    {
        graphic.CrossFadeAlpha(1f, 2f, false); // Desvanece hacia adentro a opacidad completa en 2 segundos
        Invoke("FadeOut", 2f); // Llama a FadeOut después de 2 segundos
    }

    void FadeOut()
    {
        graphic.CrossFadeAlpha(0f, 2f, false); // Desvanece hacia afuera a opacidad cero en 2 segundos
        Invoke("FadeIn", 2f); // Llama a FadeIn después de 2 segundos
    }
}