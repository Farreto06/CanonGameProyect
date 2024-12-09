using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    [Header("------------------")]
    [Header("Healt points Settings")]
    [Header("Player_1")]
    [SerializeField] private GameObject H1_P1;
    [SerializeField] private GameObject H2_P1;
    [SerializeField] private GameObject H3_P1;
    [Header("Player_2")]
    [SerializeField] private GameObject H1_P2;
    [SerializeField] private GameObject H2_P2;
    [SerializeField] private GameObject H3_P2;

    #endregion
    #region Wins and loses
    [Header("Wins and loses")]
    [SerializeField] private GameObject winP1;
    [SerializeField] private GameObject winP2;
    [SerializeField] private GameObject menu;
    private AudioSource audioSource;
    public void winPlayer1(){
        Debug.Log("Player 1 wins");
        winP1.SetActive(true);
        turnCanon = "CanonDaniela";
        canonScriptP1.active = false;
        canonScriptP2.active = false;
        menu.SetActive(true);
        audioSource.Play();
    }
    public void winPlayer2(){
        Debug.Log("Player 2 wins");
        winP2.SetActive(true);
        turnCanon = "CanonVicente";
        canonScriptP1.active = false;
        canonScriptP2.active = false;
        menu.SetActive(true);
        audioSource.Play();
    }
    #endregion

    void Start()
    {
        FindCanonP1();
        FindCanonP2();
        setDefaultCanon();
        audioSource = GetComponent<AudioSource>();
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
    public void decrementHpofController(){
        if (turnCanon == "CanonDaniela"){
            canonScriptP1.decrementHp();
            if (canonScriptP1.hp == 2){
                H3_P1.GetComponent<SpriteRenderer>().enabled = false;
            }else if (canonScriptP1.hp == 1){
                H2_P1.GetComponent<SpriteRenderer>().enabled = false;
            }else if (canonScriptP1.hp == 0){
                H1_P1.GetComponent<SpriteRenderer>().enabled = false;
                winPlayer2();
            }
        }else{
            canonScriptP2.decrementHp();
            if (canonScriptP2.hp == 2){
                H1_P2.GetComponent<SpriteRenderer>().enabled = false;
            }else if (canonScriptP2.hp == 1){
                H2_P2.GetComponent<SpriteRenderer>().enabled = false;
            }else if (canonScriptP2.hp == 0){
                H3_P2.GetComponent<SpriteRenderer>().enabled = false;
                winPlayer1();
            }
        }
    }
}
}
