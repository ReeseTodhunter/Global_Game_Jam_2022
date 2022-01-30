using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://youtu.be/yumoqNlaPCE
//https://youtu.be/t_ST7ectK2Q

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    private int FlightPath = 0; //The number that will decide which flight path the enemy will follow

    [SerializeField]
    private bool IsMeleeEnemy = false; //Whether or not the current enemy is a melee attack
    private Vector3 MeleeAttackDirection = new Vector3(0.0f, 0.0f, 0.0f);

    private int TurnNum = 0;    //How far through we are in our Flight Path, only applies to simple pathing
    [SerializeField]
    private float Counter;      //Delta Timer for use within the script

    private float speed = 2;    //The speed the enemy moves
    [SerializeField]
    int[] LRTurns;              //Array that stores simple turns for the Enemies to use
    int[] RotationDirection;    //Sets whether the Rotate Pathing will go left, right or straight, Left is 1, Right is 2, Straight is 3
    private float Rotation;     //The amount that Complex Rotation Turns by

    float[] TimeToTurn;   //The time that Counter must reach in order for Any Pathing to turn

    // Start is called before the first frame update
    void Start()
    {
        
        switch (FlightPath)
        {
            case 1:
                LRTurns = new int[] { 1, 1, 2, 2, 1, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 2.0f };
                break;
            case 2:
                LRTurns = new int[] { 1, 2, 1, 1, 2, 1 };
                TimeToTurn = new float[] { 2.0f };
                break;
            case 3:
                Rotation = 1.0f;
                RotationDirection = new int[] {1,2,3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 4:
                Rotation = 2.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 5:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 6:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 7:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 8:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 9:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 2.0f, 3.0f, 1.0f };
                break;
            case 10:
                Rotation = 3.0f;
                RotationDirection = new int[] { 1, 2, 3 };
                TimeToTurn = new float[] { 1.0f, 5.0f, 11.0f };
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (FlightPath < 3)
        {
            //Basic Straight Line Movement
            SimplePathing();
            transform.position += -transform.right * speed * Time.fixedDeltaTime;
        }
        if (FlightPath >= 3 && FlightPath <=10)
        {
            //Curly Spiral Movements
            RotationPathing();
            transform.position += -transform.right * speed * Time.fixedDeltaTime;
        }
        if(FlightPath == 11)
        {
            //Direct Charge towards the player
            EnemyMeleeAttack();
        }
        
        
        
    }
    
    void SimplePathing()
    {
        Counter += Time.fixedDeltaTime;        
        if (Counter >= TimeToTurn[0] && TurnNum < LRTurns.Length)
        {
            Counter = 0.0f;
            //Find the correct turn in the sequence and find out if it's a left or right
            if(LRTurns[TurnNum] == 1) //1 for left
            {
                transform.Rotate(0.0f, 0.0f, 90.0f, Space.World);
            }
            if (LRTurns[TurnNum] == 2) //2 for right
            {
                transform.Rotate(0.0f, 0.0f, -90.0f, Space.World);
            }            
            TurnNum += 1; //Go to the next turn in the array
        }
        if(TurnNum < LRTurns.Length && IsMeleeEnemy)//If we've run out of turns and we melee attack: change to melee attack flight pattern
        {
            FlightPath = 11;
        }
        
    }
    void RotationPathing()
    {
        Counter += Time.fixedDeltaTime;
        if (Counter >= TimeToTurn[TurnNum] && TurnNum <= TimeToTurn.Length)
        {
            Counter = 0.0f;
            //Go to the next rotation timing, direction and speed
            TurnNum += 1;
        }
        if (TurnNum >= TimeToTurn.Length && IsMeleeEnemy)//When there are no more turns and it melee attacks, change to melee attack flight pattern
        {
            FlightPath = 11;
        }
        else if (TurnNum >= TimeToTurn.Length && IsMeleeEnemy == false)//When there are no more turns and it does NOT melee attack, continue straight
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
        }
        else if (RotationDirection[TurnNum] == 1)//1 for Left
        {
        transform.Rotate(0.0f, 0.0f, Rotation, Space.World); //Turn by our preset speed
        }
        else if (RotationDirection[TurnNum] == 2)//2 for Right
        {
            transform.Rotate(0.0f, 0.0f, -Rotation, Space.World);//Turn by our preset speed rightwards
        }
        else if (RotationDirection[TurnNum] == 3)//3 for Straight
        {
            transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);//Don't turn
        }
               
    }
    void EnemyMeleeAttack()
    {
        if (MeleeAttackDirection == new Vector3(0.0f, 0.0f, 0.0f))
        {
            GameObject Player = GameObject.Find("Player"); //Find the player
            Debug.Log(MeleeAttackDirection);
            MeleeAttackDirection = Player.transform.position - transform.position;
            MeleeAttackDirection = MeleeAttackDirection.normalized;
        }
        else
        {
            transform.position += MeleeAttackDirection * speed * Time.fixedDeltaTime;
        }
    }
}
