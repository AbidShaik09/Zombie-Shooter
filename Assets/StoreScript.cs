using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.name.Equals("Player1"))
        {
            PlayerControllerScript.store();
        }
        
    }
    

    // Update is called once per frame

}
