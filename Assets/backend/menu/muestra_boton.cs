using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class muestra_boton : MonoBehaviour
{
    public GameObject letras;       // Asigna tu objeto de letras aquí
    public GameObject button1;      // Asigna el primer botón secundario aquí
    public GameObject button2;      // Asigna el segundo botón secundario aquí
    private Coroutine hideCoroutine; // Referencia a la corrutina

    void Start()
    {
        // Asegúrate de que los botones secundarios estén desactivados al inicio
        button1.SetActive(false);
        button2.SetActive(false);
    }

    void Update()
    {
        // Detectar clic en cualquier parte de la pantalla
        if (Input.GetMouseButtonDown(0))
        {
            ShowButtons(); // Mostrar los botones al hacer clic
        }
    }

    void ShowButtons()
    {
        // Activar los botones secundarios
        button1.SetActive(true);
        button2.SetActive(true);

        // Desactivar las letras
        letras.SetActive(false);
    }
}