using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField]
    private float moveSpeed = 4.0f;
    [SerializeField]
    private float projectileSpeed = 6.0f;
    [SerializeField]
    private const float baseShotDelay = 0.3f;
    [SerializeField]
    private const float baseSpecialDelay = 2.0f;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject BarrelEnd;   //Placement of where to spawn the player's ability/shots
    [SerializeField]
    private GameObject potatoProjectile;
    [SerializeField]
    private GameObject chilliProjectile;
    [SerializeField]
    private GameObject jacket;
    [SerializeField]
    private GameObject fireWall;

    public int Lives;   //Number of player livesS
    private float shotDelay;    //Delay between each shot while holding down space
    private float specialDelay; //Delay between uses of specials
    private bool firing;    //If the player is holding space or not
    private string type; //current player type (Potato or Chilli)


    Vector2 movement;

    void Start()
    {
        Lives = 3;
        animator.SetInteger("State", 0);
        type = "P";
    }

    // Update is called once per frame
    void Update()
    {
        //Take inputs in Update
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Shot inputs 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firing = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            firing = false;
        }

        //Special input
        if (Input.GetKeyDown(KeyCode.R))
        {
            Special(type, specialDelay);
        }

        //Switch Character input
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (type == "P")
            {
                type = "C";
                animator.SetInteger("State", 1);
            }
            else
            {
                type = "P";
                animator.SetInteger("State", 0);
            }
        }
    }

    void FixedUpdate()
    {
        //Get a constant movement speed by using fixedDeltaTime
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(shotDelay > 0)
        {
            shotDelay -= Time.fixedDeltaTime;
        }

        if(specialDelay > 0)
        {
            specialDelay -= Time.fixedDeltaTime;
        }

        if (firing && shotDelay <= 0)
        {
            Fire(type);
            shotDelay = baseShotDelay;
        }
    }

    void Fire(string ShotType)
    {
        GameObject temp;
        if (ShotType == "P")
        {
            temp = Instantiate(potatoProjectile, BarrelEnd.transform);
        }
        else
        {
            temp = Instantiate(chilliProjectile, BarrelEnd.transform);
        }
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        temp.GetComponent<ProjectileScript>().projectileType = ShotType;
    }

    void Special(string ShotType, float delay)
    {
        if (delay <= 0)
        {
            specialDelay = baseSpecialDelay;
            GameObject temp;
            if (ShotType == "P")
            {
                temp = Instantiate(potatoProjectile, BarrelEnd.transform);
                temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
                temp.GetComponent<ProjectileScript>().projectileType = "SP";
            }
            else
            {
                temp = Instantiate(chilliProjectile, BarrelEnd.transform);
                temp.GetComponent<ProjectileScript>().projectileType = "SC";
            }
        }
    }
}