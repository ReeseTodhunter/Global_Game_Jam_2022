using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://youtu.be/yumoqNlaPCE
//https://youtu.be/t_ST7ectK2Q

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    private int FlightPath = 0; //The number that will decide which flight path the enemy will follow

    private bool RotateDirection = false; //Sets whether the Rotate Pathing will go left or right, Left is false, Right is true

    private int TurnNum = 0;    //How far through we are in our Flight Path, only applies to simple pathing
    [SerializeField]
    private float Counter;      //Delta Timer for use within the script

    private float speed = 2;

    int[] LRTurns;              //Array that stores simple turns for the Enemies to use
    private float Rotation;     //The amount that Complex Rotation Turns by
    float[] TimeToTurn;   //The time that Counter must reach in order for Any Pathing to turn

    // Start is called before the first frame update
    void Start()
    {
        
        switch (FlightPath)
        {
            case 1:
                LRTurns = new int[] { 1, 1, 2, 2, 1, 1 };
                TimeToTurn = new float[] { 2.0f };
                break;
            case 2:
                LRTurns = new int[] { 1, 2, 1, 1, 2, 1 };
                TimeToTurn = new float[] { 2.0f };
                break;
            case 3:
                Rotation = 1.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 4:
                Rotation = 2.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 5:
                Rotation = 3.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 6:
                Rotation = 3.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 7:
                Rotation = 3.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 8:
                Rotation = 3.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 9:
                Rotation = 3.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 10:
                Rotation = 1.0f;
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FlightPath < 3)
        {
            SimplePathing();
        }
        if (FlightPath >= 3)
        {
            RotationPathing(FlightPath);
        }
        transform.position += transform.up * speed * Time.fixedDeltaTime;
    }
    
    void SimplePathing()
    {
        Counter += Time.fixedDeltaTime;
         //Simple 90 degree turns left and right. 1 for Left, 2 for Right
        
        if (Counter >= TimeToTurn[0] && TurnNum < 6)
        {
            Counter = 0.0f;
            if(LRTurns[TurnNum] == 1)
            {
                transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            }
            if (LRTurns[TurnNum] == 2)
            {
                transform.Rotate(0.0f, 0.0f, -90.0f, Space.World);
            }
            else { }
            TurnNum += 1;
        }
        
    }
    void RotationPathing(int Path)
    {
        Counter += Time.fixedDeltaTime;
        if (Counter >= TimeToTurn[TurnNum] && TurnNum <= TimeToTurn.Length)
        {
            RotateDirection = !RotateDirection;
            Counter = 0.0f;
        }
        if (RotateDirection == false)
        {
            transform.Rotate(0.0f, 0.0f, Rotation, Space.World);
        }
        if(RotateDirection == true)
        {
            transform.Rotate(0.0f, 0.0f, -Rotation, Space.World);
        }
        TurnNum++;
        
    }
}
