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

    public LayerMask mask;

    private RaycastHit2D left_ground_check;

    private RaycastHit2D right_ground_check;


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

        float ground_offset = 0f;

        ground_check = Physics2D.Raycast(rb.position, Vector2.down, 1, mask);
        if (ground_check)
        {

            ground_offset = ground_check.distance - 0.5f;

            Velocity.y = 0;
        }
        else
        {
            Velocity.y -= gravity;
            Velocity.y = Mathf.Max(Velocity.y, -max_fall_speed);
        }



            

        rb.MovePosition(rb.position + (Velocity * Time.fixedDeltaTime) - new Vector2(0, ground_offset));

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(GetComponent<Rigidbody2D>().position + new Vector2(0, 0), Vector2.down);
        Gizmos.DrawRay(GetComponent<Rigidbody2D>().position + new Vector2(-0.5f, 0), Vector2.down);
        Gizmos.DrawRay(GetComponent<Rigidbody2D>().position + new Vector2(0.5f, 0), Vector2.down);
    }







}
