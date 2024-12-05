using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheelSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {

    }
    public void spinToRight(){
        transform.Rotate(0,0,-5f);
    }
    public void spinToLeft(){
        transform.Rotate(0,0,5f);
    }
}
