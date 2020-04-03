using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSeq : MonoBehaviour
{
    private int c = 0;
    private int a = 0;
    private int b = 0;



    public GameObject cube;
    public GameObject buttonA;
    public GameObject buttonB;
    public GameObject buttonC;


    void Start()
    {
        
    }


    void Update()
    {
        CheckSeq();
    }
    public void OnCClicked()
    {
        b++;
       if(c == 0)
        {
            a++;              // a = 1
            c++;              // c = 1 
        }
    }

    public void OnAClicked()
    {
        b++;
        if (c == 1)
        {
            a++;            //a = 2
            c++;            //c = 2 
        }
    }
    public void OncBlicked()
    {
        b++;

        if (c == 2)
        {
            a++;            //a = 3
            //c++;            //c = 2 
        }
    }

    void CheckSeq()
    {
        if(a == 3)
        {
            cube.SetActive(true);
               
        }
       
        if(b == 3)
        {
            buttonA.SetActive(false);
            buttonB.SetActive(false);
            buttonC.SetActive(false);
            
        }
        
    }
}

