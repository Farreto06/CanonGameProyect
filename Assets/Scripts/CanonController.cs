using System.Collections;
using System.Collections.Generic;
using CanonScript;
using UnityEngine;
using UnityEngine.Rendering;

namespace Controller
{
public class CanonController: MonoBehaviour
{
    #region Fields definition
    [Header("Canon Settings")]
    [Header("------------------")]
    [SerializeField] private GameObject CanonP1;
    public string tagCanonP1;
    [SerializeField] private GameObject CanonP2;
    public string tagCanonP2;

    [Header("Canon Srcipts")]
    [Header("------------------")]
    private Canon canonScriptP1;
    private Canon canonScriptP2;
    [Header("Canon turn")]
    public string turnCanon="CanonDaniela";
    private bool inShot=false;
    private GameObject objectBullet;
    [Header("Camera Settings")]
    public float n=0.5f;
    #endregion


    void Start()
    {
        FindCanonP1();
        FindCanonP2();
        setDefaultCanon();
    }

    void FixedUpdate()
    {
        if (!inShot){
            putCameraOnCanon(Camera.main);
        }else{
            CameraFollowBullet(Camera.main);
        }
        
    }
    private void FindCanonP1(){
        CanonP1 = GameObject.FindWithTag(tagCanonP1);
        canonScriptP1 = CanonP1.GetComponent<Canon>();
        //Debug.Log("Canon1"+canonScriptP1.nameCanon);
    }
    private void FindCanonP2(){
        CanonP2 = GameObject.FindWithTag(tagCanonP2);
        canonScriptP2 = CanonP2.GetComponent<Canon>();
        //Debug.Log("Canon2"+canonScriptP2.nameCanon);
    }
    private void setDefaultCanon(){
        canonScriptP1.active = true;
        canonScriptP2.active = false;
    }
    public void changeCanon(string origin){
        Debug.Log("Change Canon of "+origin);
        if (canonScriptP1.active){
            canonScriptP1.active = false;
            canonScriptP2.active = true;
            Debug.Log("Activate Canon2");
        }else{
            canonScriptP1.active = true;
            canonScriptP2.active = false;
            Debug.Log("Activate Canon1");
        }
    }
    public void turnOffCanonVicente(){
        canonScriptP2.active = false;
    }
    public void turnOffCanonDaniela(){
        canonScriptP1.active = false;
    }

    public void turnOnCanonVicente(){
        canonScriptP2.active = true;
    }
    public void turnOnCanonDaniela(){
        canonScriptP1.active = true;
    }
    public void changeTurnCanon(){
        if (turnCanon == "CanonDaniela"){
            turnCanon = "CanonVicente";
        }else{
            turnCanon = "CanonDaniela";
        }
    }

    public void putCameraOnCanon(Camera GameCamera){
        if (turnCanon == "CanonDaniela"){
            GameCamera.transform.position = Vector3.Lerp(GameCamera.transform.position,new Vector3(CanonP1.transform.position.x,GameCamera.transform.position.y, GameCamera.transform.position.z),n);
        }else{
            GameCamera.transform.position = Vector3.Lerp(GameCamera.transform.position,new Vector3(CanonP2.transform.position.x,GameCamera.transform.position.y, GameCamera.transform.position.z),n);
        }
    }
    public void setInShot(bool value){
        inShot = value;
    }
    public void setBullet(GameObject bullet){
        objectBullet = bullet;
    }
    public void CameraFollowBullet(Camera GameCamera){
        if (objectBullet != null){    
            GameCamera.transform.position = new Vector3(objectBullet.transform.position.x,GameCamera.transform.position.y, GameCamera.transform.position.z);
        }
    }
}
}
