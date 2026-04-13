using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private Vector2 direction = Vector2.zero;

    private Rigidbody2D rb;

    public float Max_Speed = 5;

    private Vector2 Velocity;

    public float acceleration = 1.5f;

    public float friction = 0.75f;

    public float gravity = 0.5f;

    public float max_fall_speed = 9.8f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()

    {






        if (Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }

        else if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }

        else
        {
            direction.y = 0;

        }
        direction = direction.normalized;
    }

    private void FixedUpdate()
    {

        Velocity.x += acceleration * direction.x;  

        Velocity.x = Mathf.Clamp(Velocity.x, -Max_Speed, Max_Speed);

        if (direction.x == 0)
        {
            Velocity.x = Mathf.MoveTowards(Velocity.x, 0, friction);
        }

        Velocity.y -= gravity;
        Velocity.y = Mathf.Max(Velocity.y, -max_fall_speed);

        rb.MovePosition(rb.position + (Velocity * Max_Speed * Time.fixedDeltaTime));

    }










}
