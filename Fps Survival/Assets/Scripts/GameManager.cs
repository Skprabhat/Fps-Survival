using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int pieces = 8;

    private Vector2 startpoint = new Vector2(-3.55f, 1.77f);
    private Vector2 offset = new Vector2(2.03f, 2f);

    public LayerMask colliderLayermask;

    Ray ray_up, ray_down, ray_left, ray_right;
    RaycastHit hit;
    private BoxCollider collider;
    private Vector3 piece_size;
    private Vector3 piece_centre;

    public string folderName;


    public PuzzleInt puzzlePieces;

    private List<PuzzleInt> puzzleList = new List<PuzzleInt>();
    private List<Vector3> puzzlePos = new List<Vector3>();
    private List<int> randomNo = new List<int>();

    private void Start()
    {
        PuzzleInist();
        PuzzleSet();
        ApplyMat();
        MixPuzzle();


    }
    private void Update()
    {
        MovePuzzle();


    }
    void PuzzleInist()
    {
        for (int i = 0; i < pieces; i++)
        {
            puzzleList.Add(Instantiate(puzzlePieces, new Vector3(0, 0, 0), new Quaternion(0f, 0f, 180f, 0f)) as PuzzleInt);
        }
    }

    void PuzzleSet()
    {
        //first line
        puzzleList[0].transform.position = new Vector3(startpoint.x, startpoint.y, 0);
        puzzleList[1].transform.position = new Vector3(startpoint.x + offset.x, startpoint.y, 0);
        puzzleList[2].transform.position = new Vector3(startpoint.x + (2 * offset.x), startpoint.y, 0);


        //second line
        puzzleList[3].transform.position = new Vector3(startpoint.x, startpoint.y - offset.y, 0);
        puzzleList[4].transform.position = new Vector3(startpoint.x + offset.x, startpoint.y - offset.y, 0);
        puzzleList[5].transform.position = new Vector3(startpoint.x + (2 * offset.x), startpoint.y - offset.y, 0);

        //third line
        puzzleList[6].transform.position = new Vector3(startpoint.x, startpoint.y - (2 * offset.y), 0);
        puzzleList[7].transform.position = new Vector3(startpoint.x + offset.x, startpoint.y - (2 * offset.y), 0);
        //puzzleList[7].transform.position = new Vector3(startpoint.x + (2 * offset.x), startpoint.y - (2 * offset.y), 0);

    }
    void MovePuzzle()
    {
        foreach (PuzzleInt puzzle in puzzleList)
        {
            puzzle.mov_amount = offset;
            if (puzzle.clicked)
            {
                //ray up and down
                collider = puzzle.GetComponent<BoxCollider>();
                piece_size = collider.size;
                piece_centre = collider.center;

                float move_amount = offset.x;
                float direction = Mathf.Sign(move_amount);

                //set ray
                float x = (puzzle.transform.position.x + piece_centre.x - piece_size.x / 2) + piece_size.x / 2;
                float y_up = puzzle.transform.position.y + piece_centre.y + piece_size.y / 2 * direction;
                float y_down = puzzle.transform.position.y + piece_centre.y + piece_size.y / 2 * -direction;

                ray_up = new Ray(new Vector2(x, y_up), new Vector2(0, direction));
                ray_down = new Ray(new Vector2(x, y_down), new Vector2(0, -direction));

                //draw ray
                Debug.DrawRay(ray_up.origin, ray_up.direction);
                Debug.DrawRay(ray_down.origin, ray_down.direction);

                //ray left and right
                float y = (puzzle.transform.position.y + piece_centre.y - piece_size.y / 2) + piece_size.y / 2;
                float x_right = puzzle.transform.position.x + piece_centre.x + piece_size.x / 2 * direction;
                float x_left = puzzle.transform.position.x + piece_centre.x + piece_size.x / 2 * -direction;

                ray_left = new Ray(new Vector2(x_left, y), new Vector2(-direction, 0));
                ray_right = new Ray(new Vector2(x_right, y), new Vector2(direction, 0));

                //draw ray
                Debug.DrawRay(ray_left.origin, ray_left.direction);
                Debug.DrawRay(ray_right.origin, ray_right.direction);

                //collision check
                if ((Physics.Raycast(ray_up, out hit, 1f, colliderLayermask) == false) && (puzzle.moved == false)
                        && (puzzle.transform.position.y < startpoint.y))
                {
                    puzzle.go_up = true;

                }
                if ((Physics.Raycast(ray_down, out hit, 1f, colliderLayermask) == false) && (puzzle.moved == false)
                       && (puzzle.transform.position.y > -2.23))
                {
                    puzzle.go_down = true;

                }
                if ((Physics.Raycast(ray_left, out hit, 1f, colliderLayermask) == false) && (puzzle.moved == false)
                       && (puzzle.transform.position.x > startpoint.x))
                {
                    puzzle.go_left = true;

                }
                if ((Physics.Raycast(ray_right, out hit, 1f, colliderLayermask) == false) && (puzzle.moved == false)
                       && (puzzle.transform.position.x < 0.50))
                {
                    puzzle.go_right = true;

                }

            }
        }
    }

    void ApplyMat()
    {
        string filePath;
        for (int i = 1; i <= puzzleList.Count; i++)
        {
            //if(i > 2)
            //{
            //    filePath = "/Puzzle" + folderName + "/Cube" + (i+1);

            //}
            //else
            //{
            filePath =  folderName+i;

            //  }

            Texture2D mat = Resources.Load(filePath, typeof(Texture2D)) as Texture2D;
            puzzleList[i - 1].GetComponent<Renderer>().material.mainTexture = mat;
        }

    }
    void MixPuzzle()
    {
        int number;
        foreach(PuzzleInt p in puzzleList )
        {
            puzzlePos.Add(p.transform.position);
        }
        foreach(PuzzleInt p in puzzleList )
        {
            number = Random.Range(0, puzzleList.Count);

            while(randomNo.Contains(number))
            {
                number = Random.Range(0, puzzleList.Count);

            }
            randomNo.Add(number);
            p.transform.position = puzzlePos[number];
        }
    }
}
