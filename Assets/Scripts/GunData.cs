using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GunData 
{
    int gunId { get; set; }
    int cartridgesize { get; set; }
    int reloadTime { get; set; }

    int bulletpower { get;set; }

    int bulletShot { get; set; }
}
