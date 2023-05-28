using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Force : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshProUGUI.text = "" + PlayerControllerScript.force;        
    }
}
