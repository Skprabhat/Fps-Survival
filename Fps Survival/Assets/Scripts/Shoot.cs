using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera mainCam;

    public ParticleSystem dust;

    public float range = 10f;
    public int maxAmmo = 14;
    private int currentAmmo;
    public float damage = 10f;

    //private void Start()
    //{
    //    currentAmmo = maxAmmo;
    //}
    void Update()
    {
        
            if (Input.GetButton("Fire1") && maxAmmo > 0)
            {
                shoot();
            }
       
        
    }
    private void shoot()
    {
       // Debug.Log("hooo");
       // maxAmmo--;
        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(mainCam.transform.position , mainCam.transform.forward , Color.red , 2f);
           
            EnemyDamage ed = hit.transform.GetComponent<EnemyDamage>();
            if(ed!= null)
            {
                ed.TakeDamage(damage);
            }
        }
        
    }
}
