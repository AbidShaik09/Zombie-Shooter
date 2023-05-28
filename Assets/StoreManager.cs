using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    static Canvas stcanvas;
    static Canvas gncanvas;
    static Canvas bucanvas;

    [SerializeField] Canvas StoreCanvas;
    [SerializeField] Canvas GunCanvas;
    [SerializeField] Canvas BulletCanvas;
    void Start()
    {
        stcanvas = StoreCanvas; gncanvas = GunCanvas; bucanvas = BulletCanvas;
        StoreCanvasEnable();
    }


    public static void StoreCanvasEnable()
    {
        stcanvas.enabled = true;
        bucanvas.enabled = false;
        gncanvas.enabled = false;
    }
    public static void GunsCanvasEnable()
    {
        stcanvas.enabled = false;
        bucanvas.enabled = false;
        gncanvas.enabled = true;
    }
    public static void AmmoCanvasEnable()
    {
        stcanvas.enabled = false;
        bucanvas.enabled = true;
        gncanvas.enabled = false;
    }
    // Update is called once per frame
}
