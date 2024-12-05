using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float smoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("1")){
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x-1,0,-10), smoothing*Time.deltaTime);
        }
        else if(Input.GetKey("2")){
            transform.position = Vector3.Lerp(transform.position,new Vector3(0,0,-10), smoothing*Time.deltaTime);
        }
        else if(Input.GetKey("3")){
            transform.position = Vector3.Lerp(transform.position,new Vector3(transform.position.x+1,0,-10), smoothing*Time.deltaTime);
        }
    }
}
