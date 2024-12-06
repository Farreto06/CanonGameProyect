using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace pooBullet{
public class ObjectBullet
{
    private static bool isBullet = false;
    private static GameObject objectBullet;
    public float originalPositionX;
    public float originalPositionY;

    public void CreateBullet(GameObject BulletPrefab, GameObject CanonHead, float forceBullet, string nameCanon)
{
    if (BulletPrefab == null)
    {
        Debug.LogError("BulletPrefab no está asignado.");
        return;
    }
    if (CanonHead == null)
    {
        Debug.LogError("CanonHead no está asignado.");
        return;
    }
    
    if (!isBullet)
    {
        objectBullet = GameObject.Instantiate(BulletPrefab);
        isBullet = true;
        objectBullet.transform.position = CanonHead.transform.position;
        objectBullet.GetComponent<Rigidbody2D>().AddForce(CanonHead.transform.right * forceBullet);
        objectBullet.transform.SetParent(GameObject.Find(nameCanon).transform);
    }
    else
    {
        Debug.Log("Bullet already exists");
    }
}


    public void DestroyBullet(GameObject bullet,GameObject explosion)
{
    if (objectBullet != null)
    {
        bullet.GetComponent<SpriteRenderer>().enabled = false;
        explosion.SetActive(true);
        GameObject.Destroy(bullet,0.15f);
        bullet.GetComponent<Bullet>().desacyivateInShot();
        isBullet = false;
        }
    }
    public void verifyBullet(){
        if (objectBullet == null){
            isBullet = false;
        }
    }
}
}