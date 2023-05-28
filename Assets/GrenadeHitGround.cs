using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeHitGround : MonoBehaviour
{
    Rigidbody gm;
    // Start is called before the first frame update
    void Start()
    {
        gm= GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Floor")){
            gm.useGravity = false;
        }
    }


}
