using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    [SerializeField] GameObject target;
    [SerializeField]float distance=10;
    [SerializeField] int DistanceAway = 10;
    [SerializeField] GameObject Cam;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 PlayerPOS = target.transform.transform.position;
            Cam.transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + distance, PlayerPOS.z - DistanceAway);
        }
    }
}
