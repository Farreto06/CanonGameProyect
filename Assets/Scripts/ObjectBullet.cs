using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CanonScript;

namespace pooBullet{
public class ObjectBullet
{
    private static bool isBullet = false;
    private static GameObject objectBullet;
    public float originalPositionX;
    public float originalPositionY;

    public void CreateBullet(GameObject BulletPrefab, GameObject CanonHead, float forceBullet,string nameCanon){
        //Verifica si el prefab de la bala está asignado
        if (BulletPrefab == null)
        {
            Debug.LogError("BulletPrefab no está asignado.");
            return;
        }
        //Verifica si el CanonHead está asignado
        if (CanonHead == null)
        {
            Debug.LogError("CanonHead no está asignado.");
            return;
        }
        
        if (!isBullet){
            objectBullet = GameObject.Instantiate(BulletPrefab);
            isBullet = true;
            objectBullet.transform.position = CanonHead.transform.position;
            objectBullet.GetComponent<Rigidbody2D>().AddForce(CanonHead.transform.right * forceBullet);
            objectBullet.transform.SetParent(GameObject.Find(nameCanon).transform);

        }else{
            //Console.WriteLine("Bullet already exists");
        }
    }

    public void DestroyBullet(GameObject bullet){
        if (objectBullet != null){
            GameObject.Destroy(bullet);
            isBullet = false;
        }
    }

    public void verifyBullet(){
        if (objectBullet == null){
            isBullet = false;
        }
    }
    public void CameraFollowBullet(Camera GameCamera){

        if (objectBullet != null){
            if (objectBullet.transform.position.x > 0){
                GameCamera.transform.position = new Vector3(objectBullet.transform.position.x,GameCamera.transform.position.y, GameCamera.transform.position.z);
            }
        }else{
            GameCamera.transform.position = Vector3.Lerp(GameCamera.transform.position, new Vector3(originalPositionX,originalPositionY,GameCamera.transform.position.z), 0.1f);  
        }
    }
}
}