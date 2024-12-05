using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pooBullet;
using CanonScript;

public class Bullet : MonoBehaviour
{
    public float liveTime = 3;
    private Canon canonScript; // Referencia al script Canon


    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el script Canon en la escena
        canonScript = FindObjectOfType<Canon>();

        if (canonScript == null)
        {
            Debug.LogError("No se encontró un objeto con el script Canon en la escena.");
        }
    }
    // Update is called once per frame
    void Update()
    {
        liveTime -= Time.deltaTime;

        if (liveTime <= 0)
        {
            // Accede a objectBullet y llama a algún método o cambia una propiedad
            if (canonScript != null && canonScript.objectBullet != null)
            {
                //Debug.Log("Manipulando objectBullet desde Bullet.cs");
                canonScript.objectBullet.DestroyBullet(gameObject); // Reemplaza con el método que necesites llamar
            }
        }

    }
}
