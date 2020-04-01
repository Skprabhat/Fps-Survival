using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInt : MonoBehaviour
{
    [HideInInspector]
    public bool clicked = false;

    [HideInInspector]
    public bool go_left;
    [HideInInspector]
    public bool go_right;

    [HideInInspector]
    public bool go_up;
    [HideInInspector]
    public bool go_down;

    [HideInInspector]
    public Vector2 mov_amount;
    [HideInInspector]
    public bool moved = false;
    private void Start()
    {
        
    }

    private void Update()
    {
        movePuzzle();
    }

    public void OnMouseDown()
    {
        clicked = true;
    }
    public void OnMouseUp()
    {
        clicked = false;
        moved = false;
    }

    void movePuzzle()
    {
        if(go_left)
        {
            transform.position = new Vector3(transform.position.x - mov_amount.x, transform.position.y, transform.position.z);
            go_left = false;
            moved = true;
        }
        if (go_right)
        {
            transform.position = new Vector3(transform.position.x + mov_amount.x, transform.position.y, transform.position.z);
            go_right = false;
            moved = true;
        }
        if (go_up)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y + mov_amount.y, transform.position.z);
            go_up = false;
            moved = true;
        }
        if (go_down)
        {
            transform.position = new Vector3(transform.position.x , transform.position.y - mov_amount.y, transform.position.z);
            go_down = false;
            moved = true;
        }
    }
}
