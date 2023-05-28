using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBrain : MonoBehaviour
{
    public Rigidbody rb;
    public ParticleSystem p;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        StartCoroutine(GrenadeTimer());
    }
    IEnumerator GrenadeTimer()
    {
        
        
        yield return new WaitForSeconds(3);

        Vector3 bombcenter = rb.transform.position;
        Collider[] colliders = Physics.OverlapSphere(bombcenter, 4f);
        if (!rb.isKinematic)
        {
            yield return new WaitForSeconds(2);
        }
        foreach (Collider c in colliders) {
            if (c != null)
            if(c.GetComponent<Rigidbody>())
            {
                if (c.gameObject.tag.Equals("Player"))
                {
                    PlayerControllerScript.Damage(40);
                }
                
            }
            if(c!=null)
            if (c.gameObject.tag.Equals("ZombieBody"))
            {
                ZombieBrain zb = c.gameObject.GetComponentInParent<ZombieBrain>();
                zb.Damage(120);
                //print("Health: " + zb.ZombieHealth);
            }
        }
        Quaternion quaternion = Quaternion.identity;
        ParticleSystem x= Instantiate(p,transform.position,quaternion);
        x.Play();
        yield return new WaitForSeconds(1);
        Destroy(x.gameObject);
        Destroy(rb.gameObject);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Terrain"))
        {
            rb.isKinematic = true;
        }
        //print(collision.gameObject.name);
    }
}
