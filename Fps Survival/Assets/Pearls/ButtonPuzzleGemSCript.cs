using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPuzzleGemSCript : MonoBehaviour
{
    public GameObject Firegem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onclick()
    {
        Firegem.SetActive(true);
        SceneManager.LoadScene(1);
   
        
    }


}
