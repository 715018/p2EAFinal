using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 3.0f;

    public int maxHealth = 5;

    public GameObject projectilePrefab;

    Vector2 lookDirection = new Vector2(1, 0);


    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    Animator animator;

    




    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }




    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }


        if (Input.GetKeyDown(KeyCode.C))
        {
                Launch();
        }

        if(transform.position.x < -20)
        {
            transform.position = new Vector3(-5, transform.position.y, transform.position.x);
        }


    }

        void FixedUpdate()
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;


            rigidbody2d.MovePosition(position);
        }

        public void ChangeHealth(int amount)
        {
        }

        void Launch()
        {
            GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

            Projectile projectile = projectileObject.GetComponent<Projectile>();
            projectile.Launch(lookDirection, 850);
        }
    }

