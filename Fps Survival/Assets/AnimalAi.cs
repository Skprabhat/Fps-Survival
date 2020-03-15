using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAi : MonoBehaviour
{

    public Transform Player;
    [SerializeField]
    private Animator anim;
    private GameObject playerPrefab;
    private void Awake()
    {
        playerPrefab = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = playerPrefab.transform;

    }

    // Update is called once per frame
    void Update()
    {

        AttackWithinRange();

    }


    public void AttackWithinRange()
    {
        //Attacks the player when player comes within the range(20) of fox
        //Within range of player
        //use Navmesh and write translation program
        if (Vector3.Distance(Player.position, this.transform.position) < 25)
        {
            Vector3 direction = Player.transform.position - this.transform.position;
            direction.y = 0; //If player falls over fox, the fox doesnt rotate up

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.2f);
            anim.SetBool("run", true);

            if (direction.magnitude > 5)
            {

                anim.SetBool("run", true);
                anim.SetBool("attack", false);
                anim.SetBool("nearplayer", false);

            }

        }
        if (Vector3.Distance(Player.position, this.transform.position) < 8)
        {
            //Set Run animation false
            //Set Attack animation true
            Vector3 directionc = Player.transform.position - this.transform.position;
            directionc.y = 0; //If player falls over fox, the fox doesnt rotate up

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(directionc), 0.2f);

            if (directionc.magnitude > 5)
            {
                anim.SetBool("nearplayer", true);
                anim.SetBool("run", false);
                anim.SetBool("attack", true);


            }


        }

    }
}
