using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoCountScript : MonoBehaviour
{
   
    public static TextMeshProUGUI display;
    // Start is called before the first frame update
    void Start()
    {
       display = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerControllerScript.hasBullets && PlayerControllerScript.canShoot)
        display.text = ""+PlayerControllerScript.CurrentBullets[PlayerControllerScript.activeGun]+"/"+PlayerControllerScript.totalBullets[PlayerControllerScript.activeGun];   
    }
}
