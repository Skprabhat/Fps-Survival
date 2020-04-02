using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Texture itemTexture;
    public int id;
    public string type;
    public string description;
   
  
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            this.gameObject.SetActive(false);
        }
      
    }
}
