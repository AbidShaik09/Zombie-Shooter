using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthPrint : MonoBehaviour
{
    public static Image healthBar;
    
    private void Start()
    {
        healthBar=GetComponent<Image>();
    }

    private void Update()
    {
        healthBar.fillAmount = PlayerControllerScript.GetHealth()/200f;
    }

}
