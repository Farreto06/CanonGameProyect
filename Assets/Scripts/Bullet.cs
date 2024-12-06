using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CanonScript;
using Controller;

public class Bullet : MonoBehaviour
{
    public float liveTime = 3;
    private Canon canonScript; // Referencia al script Canon
    [SerializeField] private GameObject EmtycanonController;
    private CanonController canonController;
    public string nameOriginCanon="CanonDaniela";
    private int canonVicenteLayer;
    private int canonDanielaLayer;
    private int Floor;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        // Encuentra el script Canon en la escena
        canonScript = GameObject.FindWithTag(nameOriginCanon).GetComponent<Canon>();
        // Encuentra el script CanonController en la escena
        FindCanonController();
        canonController.setInShot(true);
        canonController.setBullet(gameObject);

        canonVicenteLayer = LayerMask.NameToLayer("CanonVicente");
        canonDanielaLayer = LayerMask.NameToLayer("CanonDaniela");
        Floor = LayerMask.NameToLayer("Floor");

        if (canonScript == null)
        {
            Debug.LogError("No se encontró un objeto con el script Canon en la escena.");
        }
        explosion=gameObject.transform.GetChild(0).gameObject;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        liveTime -= Time.deltaTime;

        if (liveTime <= 0)
        {
            if (canonScript != null && canonScript.objectBullet != null)
            {
                localDeleteBullet();
            }
        }

        OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());

    }
    private void FindCanonController(){
        EmtycanonController = GameObject.Find("Controller");
        canonController = EmtycanonController.GetComponent<CanonController>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == canonVicenteLayer){
            localDeleteBullet();
            Debug.Log("Colision con "+other.gameObject.name);
            //Add destroy animation
            //Add decrement life
        }
        else if (other.gameObject.layer == canonDanielaLayer){
            localDeleteBullet();
            Debug.Log("Colision con "+other.gameObject.name);
            //Add destroy animation
            //Add decrement life
        }
        if (other.gameObject.layer == Floor){
            localDeleteBullet();
            Debug.Log("Colision con "+other.gameObject.name);
            //Add destroy animation
        }
        else
        {
            
        }
    }
    private void localDeleteBullet(){
        //Debug.Log("Manipulando objectBullet desde Bullet.cs");
        Debug.Log("Destruyendo bala");
        canonScript.objectBullet.DestroyBullet(gameObject,explosion); // Reemplaza con el método que necesites llamar
        canonScript.callControllerTuenChange(); // Cambia el cañón activo
        canonScript.changeCanon(); // Cambia el cañón activo
        //Change name of origin canon
        nameOriginCanon = "CanonVicente";
    }
    public void desacyivateInShot(){
        canonController.setInShot(false);
        canonController.setBullet(null);
    }
}
