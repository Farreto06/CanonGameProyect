using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using pooBullet;
using Controller;

namespace CanonScript
{
public class Canon : MonoBehaviour
{
    public GameObject CanonHead;
    public Camera GameCamera;
    public GameObject BulletPrefab;
    public GameObject SmallPoint;
    public float forceBullet;
    public float mass=50;
    public ArrayList points= new ArrayList();
    public ArrayList grafictsPoints= new ArrayList();
    public ObjectBullet objectBullet = new ObjectBullet();
    public bool active;
    public string nameCanon;
    [SerializeField] private GameObject EmtycanonController;
    private CanonController canonController;
    private float angle=0f;
    
    // Start is called before the first frame update
    void Start()
    {
        objectBullet.originalPositionX = GameCamera.transform.position.x;
        objectBullet.originalPositionY = GameCamera.transform.position.y;
        canonController = EmtycanonController.GetComponent<CanonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
        void UnDrawPath(){
            foreach (GameObject point in grafictsPoints){
                Destroy(point);
            }
            grafictsPoints.Clear();
        }

        void OnDrawPath(){
            UnDrawPath();
            foreach (Vector3 point in points){
                GameObject pointObject = Instantiate(SmallPoint);
                pointObject.transform.position = point;
                pointObject.transform.SetParent(this.transform);
                grafictsPoints.Add(pointObject);
            }
        }

        Vector2 mousePosition = Input.mousePosition;
        Vector3 globalPosicion = GameCamera.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,transform.position.z-GameCamera.transform.position.z));
        
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)){
            if(Input.GetMouseButton(0)){
            CanonHead.transform.localEulerAngles = new Vector3(CanonHead.transform.localEulerAngles.x, CanonHead.transform.localEulerAngles.y, Mathf.Atan2((globalPosicion.y - CanonHead.transform.position.y), (globalPosicion.x - CanonHead.transform.position.x))*Mathf.Rad2Deg);
            // Draw line
            angle=Mathf.Atan2((globalPosicion.y - CanonHead.transform.position.y), (globalPosicion.x - CanonHead.transform.position.x))*Mathf.Rad2Deg;
            }
            float Vox = Mathf.Cos(Mathf.Deg2Rad*angle) * forceBullet/mass;
            float Voy = Mathf.Sin(Mathf.Deg2Rad*angle) * forceBullet/mass;
            points.Clear();

            for (float t=0; t<4.5; t+=0.1f){
                float xPoint= Vox*t+CanonHead.transform.position.x;
                float yPoint= Voy*t-0.5f*9.8f*t*t+CanonHead.transform.position.y;
                points.Add(new Vector3(xPoint,yPoint,2));
                
            }
            OnDrawPath();

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            objectBullet.CreateBullet(BulletPrefab, CanonHead, forceBullet, nameCanon);
            if (nameCanon == "CanonDaniela")
            {
                canonController.turnOffCanonDaniela();
                Debug.Log("called turnOffCanonDaniela");
            }
            else if (nameCanon == "CanonVicente")
            {
                canonController.turnOffCanonVicente();
            }
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            incrementForce();
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            decrementForce();
        }
        }
    }

    public void changeCanon()
    {
        if (canonController.turnCanon == "CanonVicente")
        {
            canonController.turnOnCanonVicente();
            Debug.Log("called turnOnCanonVicente of "+nameCanon);
        }
        else if (canonController.turnCanon == "CanonDaniela")
        {
            Debug.Log("called turnOnCanonDaniela of "+nameCanon);
            canonController.turnOnCanonDaniela();
        }
    }
    public void callControllerTuenChange()
    {
        canonController.changeTurnCanon();
    }
    private void incrementForce()
    {
        if(forceBullet<=1400){
            forceBullet += 10;
        }
    }
    private void decrementForce()
    {
        if(forceBullet>=500){
        forceBullet -= 10;
        }
    }
    public void CanonAngleCero(){
        if (nameCanon == "CanonDaniela")
        {
            CanonHead.transform.localEulerAngles = new Vector3(CanonHead.transform.localEulerAngles.x, CanonHead.transform.localEulerAngles.y, 0);
        }
        else
        {
            CanonHead.transform.localEulerAngles = new Vector3(CanonHead.transform.localEulerAngles.x, CanonHead.transform.localEulerAngles.y, 180);
        }
    }
}
}