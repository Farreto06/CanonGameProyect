using UnityEngine;
using UnityEngine.UI;

public class interaccion_interfaz : MonoBehaviour
{
    public GameObject boton1;
    public GameObject boton2;
    public GameObject letras_click;

    void Start(){
        boton1.SetActive(false);
        boton2.SetActive(false);
        letras_click.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar clics fuera de los botones
        if (Input.GetMouseButtonDown(0) && boton1.activeSelf && boton2.activeSelf)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Verificar si se hizo clic en los botones de opciones
            if (!Physics.Raycast(ray, out hit) || (hit.collider.gameObject != boton1 && !hit.collider.gameObject != boton2))
            {
                HideOptions();
            }
        }
        
    }

    void mostrar_opciones (){
        letras_click.SetActive(false);
        boton1.SetActive(true);
        boton2.SetActive(true);
    }

    void HideOptions(){
        letras_click.SetActive(true);
        boton1.SetActive(false);
        boton2.SetActive(false);
    }
}
