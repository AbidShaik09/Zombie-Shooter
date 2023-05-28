using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBrain : MonoBehaviour
{
    Vector3 vel;
    Rigidbody bullet;
    public static Transform p;
    
    // Start is called before the first frame update
    void Start()
    {
    
        p = PlayerControllerScript._rbody.transform;
        bullet=GetComponent<Rigidbody>();
        bullet.AddForce(transform.forward * 500 * PlayerControllerScript.GunDamage[0] * 0.12f );
        vel=bullet.velocity;
        
    }
    private void FixedUpdate()
    {
        if (bullet.velocity.magnitude > 10 && bullet.velocity.magnitude<15.3)
        {
            Destroy(bullet.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        //print(collision.gameObject.tag);
        if (collision.gameObject.tag.Equals("ZombieHead") || collision.gameObject.tag.Equals("ZombieBody") || collision.gameObject.tag.Equals("ZombieHand") || collision.gameObject.tag.Equals("ZombieLeg") )
        {

            ZombieBrain target=collision.gameObject.GetComponent<ZombieBrain>();
            ZombieBrain.DealDamage(target,PlayerControllerScript.GunDamage[PlayerControllerScript.activeGun]);
            
        }
        if (bullet == null)
        {
            bullet = GetComponent<Rigidbody>();
        }
                Destroy(bullet.gameObject);
        
    }

}
