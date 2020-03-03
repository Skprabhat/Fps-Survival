using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    

    public GameObject inventory; 
    public bool isInventoryEnabled;
    public GameObject itemDatabase;
    private Transform[] slot;
    public GameObject slotHolder;
    private bool itemPickedUp;
    
 
   
   

    
    void Start()
    {
        GetAllSlots();
        
      
    }

    
    void Update()
    {  
        //Inventory Input
        if (Input.GetKeyDown(KeyCode.I))
        {
            isInventoryEnabled = !isInventoryEnabled;
        }
        if (isInventoryEnabled == true)
        {
            inventory.SetActive(true);

            //Set the LockCursor to false
       

        }
        else
        {
            inventory.SetActive(false);
        }

        
       


    }


    //Checking For ItemPickup
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Itempickup")
        {
            print("Colliding");
         Additem(other.gameObject);
        }
    }

    public void Additem(GameObject item)
    { 
       
        GameObject rootitem;
        rootitem = item.GetComponent<ItemPickUp>().originalitem;
        for(int i=0;i<9;i++)
        {
            if(slot[i].GetComponent<Slot>().empty==true && item.GetComponent<ItemPickUp>().itemPickedUp==false) //Checking if Already pickedUp or not
            {
                //add item
                slot[i].GetComponent<Slot>().item = rootitem;
               item.GetComponent<ItemPickUp>().itemPickedUp = true;
                Destroy(item);

            }
        }


    }
    
    public void GetAllSlots()
    {
        slot = new Transform[9];
        for (int i = 0; i < 9; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i);
           
        }
    }
}
