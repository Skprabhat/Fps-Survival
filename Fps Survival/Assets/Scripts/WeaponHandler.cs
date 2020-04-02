using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public GameObject[] weapons;
    [SerializeField]
    public GameObject currentWeapon;
    public Animator gunAnim;
    public Animator swingAnim;
    int weaponNumber = 0;
    int previousWeapon;
    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            weaponNumber += 1;
            previousWeapon = weaponNumber - 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            weaponNumber -= 1;
            previousWeapon = weaponNumber + 1;
        }
        if (weaponNumber > 3)
            weaponNumber = 0;

        if (weaponNumber < 0)
            weaponNumber = 3;
        currentWeapon = weapons[weaponNumber];
        weapons[weaponNumber].gameObject.SetActive(true);
        weapons[previousWeapon].gameObject.SetActive(false);
        if(weapons[1])
        {
            SwingAnim();
        }
        if (weapons[2])
        {
            gunAnimation();
        }
    }
    void gunAnimation()
    {
        if (Input.GetMouseButton(1))
        {
            gunAnim.SetBool("isAiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            gunAnim.SetBool("isAiming", false);
        }
       
    }
    void SwingAnim()
    {
        if (Input.GetMouseButtonDown(0) && weapons[1].activeInHierarchy)
        {
            swingAnim.SetBool("swing", true);
        }
        if (Input.GetMouseButtonUp(0) && weapons[1].activeInHierarchy)
        {
            swingAnim.SetBool("swing", false);
        }
    }
}
