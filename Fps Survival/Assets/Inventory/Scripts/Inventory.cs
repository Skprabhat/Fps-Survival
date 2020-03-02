using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventory; 
    public bool isInventoryEnabled;
   
 
   
   

    
    void Start()
    {
        // Slots  beeing detected
        
      
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
        }
        else
        {
            inventory.SetActive(false);
        }

    }

    
}
