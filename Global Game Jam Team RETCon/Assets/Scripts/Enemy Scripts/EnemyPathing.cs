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
    private float Rotation = 3.0f;     //The amount that Complex Rotation Turns by

    float[] TimeToTurn;   //The time that Counter must reach in order for Any Pathing to turn

    public float effectTimer;   //Length of time specials effect enemies
    public bool stunned;    //if the enemy is stunned or not
    public bool pushed;  //if the enemy is currently being pushed

    // Start is called before the first frame update
    void Start()
    {
        switch (FlightPath)
        {
            //Case 1 and 2 are tutorial flight path
            case 1:
                LRTurns = new int[] { 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 5.0f };
                break;
            case 2:
                LRTurns = new int[] { 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 5.0f };
                break;
            //Case 3 and 4 are mirrored
            case 3:
                LRTurns = new int[] { 2, 1, 2, 1, 2, 1, 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            case 4:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            //Case 5 & 6 are mirrored
            case 5:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            case 6:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            //Case 7 & 8 are mirrored
            case 7:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            case 8:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            //Case 9 & 10 are mirrored
            case 9:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            case 10:
                LRTurns = new int[] { 1, 2, 1, 2, 1, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 1.0f, 0.5f, 1.0f, 0.5f, 1.0f, 0.5f, 1.0f };
                break;
            //Case 11 & 12 are mirrored
            case 11:
                LRTurns = new int[] { 2, 1, 1, 2, 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 2.0f, 3.0f, 2.0f, 3.0f, 2.0f };
                break;
            case 12:
                LRTurns = new int[] { 1, 2, 2, 1, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 2.0f, 3.0f, 2.0f, 3.0f, 2.0f };
                break;
            //Case 13 & 14 are mirrored
            case 13:
                LRTurns = new int[] { 1, 2, 2, 1, 1, 1, 1, 2, 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.01f, 2.0f, 2.0f, 1.0f, 3.0f, 3.0f, 1.0f, 0.5f, 3.0f };
                break;
            case 14:
                LRTurns = new int[] { 2, 1, 1, 2, 2, 2, 2, 1, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.01f, 2.0f, 2.0f, 1.0f, 3.0f, 3.0f, 1.0f, 0.5f, 3.0f };
                break;

                //Space for other patterns
            case 19:
                LRTurns = new int[] { 2,1,1,2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 4.0f, 0.5f, 1.0f, 0.5f };
                break;
            case 20:
                LRTurns = new int[] { 1, 2, 2, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 4.0f, 0.5f, 1.0f, 0.5f };
                break;
                //Chili Shield pair
            case 21:
                LRTurns = new int[] { 1, 2, 2, 1, 1, 1, 1, 2, 1, 2, 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.5f, 0.5f, 2.0f, 0.5f, 4.0f, 3.0f, 0.5f, 0.5f, 0.5f, 2.0f, 4.0f };
                break;
            case 22:
                LRTurns = new int[] { 2, 1, 1, 2, 2, 2, 2, 1, 2, 1, 1 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.5f, 0.5f, 2.0f, 0.5f, 4.0f, 3.0f, 0.5f, 0.5f, 0.5f, 2.0f, 4.0f };
                break;
                //Melee enemy pair
            case 23: //Melee enemy, make sure to turn on the boolean IsMeleeEnemy
                LRTurns = new int[] { 2, 1, 1, 2, 2, 1}; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.01f, 3.0f, 2.0f, 2.0f, 2.0f, 2.0f };
                break;
            case 24:
                LRTurns = new int[] { 1, 2, 2, 1, 1, 2 }; //Simple 90 degree turns left and right. 1 for Left, 2 for Right
                TimeToTurn = new float[] { 0.01f, 3.0f, 2.0f, 2.0f, 2.0f, 2.0f };
                break;
            case 25:
                RotationDirection = new int[] { 2, 2 };
                Rotation = 1.0f;
                TimeToTurn = new float[] {4.0f,5.0f};
                speed = -3;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!stunned)
        {
            if (FlightPath < 25)
            {
                //Basic Straight Line Movement
                SimplePathing();
                transform.position += -transform.right * speed * Time.fixedDeltaTime;
            }
            if (FlightPath >= 25 && FlightPath < 99)
            {
                //Curly Spiral Movements
                RotationPathing();
                transform.Rotate(0.0f, 0.0f, Rotation, Space.World);
                transform.position += transform.right * speed * Time.fixedDeltaTime;
            }
            if (FlightPath == 99)
            {
                //Direct Charge towards the player
                EnemyMeleeAttack();
            }
        }
        if (effectTimer <= 0)
        {
            if(pushed)
            {
                GetComponent<Rigidbody>().velocity = Vector3.zero;
                pushed = false;
            }
            else if (stunned)
            {
                stunned = false;
            }
        }
        else
        {
            effectTimer -= Time.fixedDeltaTime;
        }
    }
    
    void SimplePathing()
    {
        Counter += Time.fixedDeltaTime;
        if (TurnNum >= LRTurns.Length)
        {
            TurnNum = 1000;
        }
        if (TurnNum >= LRTurns.Length && IsMeleeEnemy)//If we've run out of turns and we melee attack: change to melee attack flight pattern
        {
            FlightPath = 99;
        }
        else if (Counter >= TimeToTurn[TurnNum] && !(TurnNum >= LRTurns.Length))
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
    }
    void RotationPathing()
    {
        Counter += Time.fixedDeltaTime;
        if (TurnNum >= RotationDirection.Length)
        {
            TurnNum = 1000;
        }
        if (TurnNum < TimeToTurn.Length && Counter >= TimeToTurn[TurnNum])
        {
            Counter = 0.0f;
             if (RotationDirection[TurnNum] == 1)//1 for Left
            {
                Rotation = 1.0f;
            }
            if (RotationDirection[TurnNum] == 2)//2 for Right
            {
                Rotation = -1.0f;//Turn by our preset speed rightwards
            }
            if (RotationDirection[TurnNum] == 3)//3 for Straight
            {
                Rotation = 0.0f;//Don't turn
            }
             //Go to the next rotation timing, direction and speed
             TurnNum += 1;
        }
        if (TurnNum >= TimeToTurn.Length && IsMeleeEnemy)//When there are no more turns and it melee attacks, change to melee attack flight pattern
        {
            FlightPath = 99;
        }
        else if (TurnNum >= TimeToTurn.Length && IsMeleeEnemy == false)//When there are no more turns and it does NOT melee attack, continue straight
        {
            Rotation = 0.0f;//Don't turn
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
