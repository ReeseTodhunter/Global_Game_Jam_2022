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
    private GameObject BarrelEnd;
    [SerializeField]
    private GameObject projectile;

    private float shotDelay;
    private bool firing;

    Vector2 movement;

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
            Fire();
            shotDelay = baseShotDelay;
        }
    }

    void Fire()
    {
        GameObject temp;
        temp = Instantiate(projectile, BarrelEnd.transform);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed, 0);
    }
}