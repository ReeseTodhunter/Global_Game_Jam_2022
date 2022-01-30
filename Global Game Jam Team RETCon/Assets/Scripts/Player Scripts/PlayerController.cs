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
    private Rigidbody2D rb;
    [SerializeField]
    private GameObject BarrelEnd;   //Placement of where to spawn the player's ability/shots
    [SerializeField]
    private GameObject projectile;

    private float shotDelay;    //Delay between each shot while holding down space
    private bool firing;    //If the player is holding space or not
    private string type; //current player type (Potato or Chilli)


    Vector2 movement;

    void Start()
    {
        type = "P";
    }

    // Update is called once per frame
    void Update()
    {
        //Take inputs in Update
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            firing = true;
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            firing = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (type == "P")
            {
                type = "C";
            }
            else
            {
                type = "P";
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

        if (firing && shotDelay <= 0)
        {
            Fire(type);
            shotDelay = baseShotDelay;
        }
    }

    void Fire(string ShotType)
    {
        GameObject temp;
        temp = Instantiate(projectile, BarrelEnd.transform);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
        temp.GetComponent<ProjectileScript>().projectileType = ShotType;
    }

    void Special()
    {

    }
}