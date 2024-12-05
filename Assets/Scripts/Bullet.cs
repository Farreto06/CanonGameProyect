using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pooBullet;
using CanonScript;


public class Bullet : MonoBehaviour
{
    public float liveTime = 3;
    private Canon canonScript; // Referencia al script Canon
    public string nameOriginCanon="CanonDaniela";


    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el script Canon en la escena
        canonScript = GameObject.FindWithTag(nameOriginCanon).GetComponent<Canon>();

        if (canonScript == null)
        {
            Debug.LogError("No se encontró un objeto con el script Canon en la escena.");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        liveTime -= Time.deltaTime;

        if (liveTime <= 0)
        {
            // Accede a objectBullet y llama a algún método o cambia una propiedad
            if (canonScript != null && canonScript.objectBullet != null)
            {
                //Debug.Log("Manipulando objectBullet desde Bullet.cs");
                Debug.Log("Destruyendo bala");
                canonScript.objectBullet.DestroyBullet(gameObject); // Reemplaza con el método que necesites llamar
                canonScript.callControllerTuenChange(); // Cambia el cañón activo
                canonScript.changeCanon(); // Cambia el cañón activo
                //Change name of origin canon
                nameOriginCanon = "CanonVicente";

            }
        }

    }
}
