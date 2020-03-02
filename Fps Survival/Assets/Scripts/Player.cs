using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    public float maxHealth;
    public float maxHunger;
    public float maxThrist;
    private float health,hunger,thrist;
    float heathDecrease=3f;
    [Space]
    public float hungerDecreaseRate;
    public float thristDecreaseRate;
    [Space]
    public GameObject inventory;
    bool isDead;
    bool isInventoryEnabled;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        health = maxHealth;
        isDead = false;
        thrist = maxThrist;
        hunger = maxHunger;
    }

    // Update is called once per frame
    void Update()
    {
        //Player stats decrease rate
        if(!isDead)
        {
            hunger -= hungerDecreaseRate * Time.deltaTime;
            thrist -= thristDecreaseRate * Time.deltaTime;
        }
        //Inventory Input
        if(Input.GetKeyDown(KeyCode.I))
        {
            isInventoryEnabled = !isInventoryEnabled;
        }
        if(isInventoryEnabled==true)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
        //checking isplayer Dead
        if (health < maxHealth)
            Die();
        
        //decreasing health
        if(hunger<0||thrist<0)
        {
            health -= heathDecrease * Time.deltaTime;
        }
    }
    void Die()
    {

    }
}
