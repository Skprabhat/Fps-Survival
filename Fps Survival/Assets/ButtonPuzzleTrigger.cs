using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPuzzleTrigger : MonoBehaviour
{
    public GameObject geminstantitaion;
   

    private void Awake()
    {
        geminstantitaion.SetActive(false);
       
    }


  
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.gameObject.CompareTag("Player"))
        {
       
            SceneManager.LoadScene(2); 
           

        }
        
    }
}
