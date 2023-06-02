using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3.0f;

    private Vector2 movement;

    public GameObject projectilePrefab;

    Vector2 lookDirection = new Vector2(1, 0);


    Rigidbody2D rigidbody2d;
    

    public Animator animator;
    




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }




    // Update is called once per frame
    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        animator.SetFloat("Speed", Mathf.Abs(movement.magnitude * movementSpeed));

        

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }

        bool flipped = movement.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    void FixedUpdate()
        {
            if (movement !=Vector2.zero)
            {
                var xMovement = movement.x * movementSpeed * Time.deltaTime;
                this.transform.Translate(new Vector3(xMovement, 0), Space.World);
            }
        }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 800);
        
    }
}

