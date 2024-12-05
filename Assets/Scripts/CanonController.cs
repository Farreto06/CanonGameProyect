using System.Collections;
using System.Collections.Generic;
using CanonScript;
using UnityEngine;

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
    #endregion


    void Start()
    {
        FindCanonP1();
        FindCanonP2();
        setDefaultCanon();
    }

    void Update()
    {

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
}
}
