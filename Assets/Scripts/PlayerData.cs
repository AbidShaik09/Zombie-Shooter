using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerData 
{
    public int coins { get; set; }
    public string name { get; set; }

    public int zombiesKilled { get; set; }

    public GunData[] gunsOwned { get; set; }

    public int bulletCount { get; set; }
}
