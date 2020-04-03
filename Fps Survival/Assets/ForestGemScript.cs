using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForestGemScript : MonoBehaviour
{
    public GameObject ForestGem;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
            ForestGem.SetActive(true);
        }
    }
}
