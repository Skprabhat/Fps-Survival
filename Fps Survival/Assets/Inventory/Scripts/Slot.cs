using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerDownHandler
{
    public bool empty;
    public Texture slottexture; 
    public Texture itemtexture;
    public WeaponHandler weaponhandler;
    public GameObject item;
    private GameObject player;

    private void Awake()
    {
        empty = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //Changing texture
        if (item)
        {
            itemtexture = item.GetComponent<Item>().itemTexture;
            this.GetComponent<RawImage>().texture = itemtexture;
            empty = false;
        }
        else
        {
            this.GetComponent<RawImage>().texture = slottexture;
            empty = true;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(item)
        {
            item.SetActive(true);
            //weaponhandler.currentWeapon.gameObject.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

  
}
