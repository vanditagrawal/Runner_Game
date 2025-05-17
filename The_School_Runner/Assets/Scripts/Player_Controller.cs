using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    [SerializeField] Transform centre_pos;
    [SerializeField] Transform left_pos;
    [SerializeField] Transform right_pos;
    [SerializeField] Rigidbody rb;
    

    int current_pos = 0;
    public float side_speed;
    public float runing_speed;
    public float jump_force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        current_pos = 0;  // 0 = center, 1 = left, 2 = right
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + runing_speed*Time.deltaTime);
        if (current_pos == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                current_pos = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                current_pos = 2;
            }
        }
        else if (current_pos == 1)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                current_pos = 0;
            }
        }
        else if (current_pos == 2)
        {
            if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                current_pos = 0;
            }
        }

        if(current_pos == 0)
        {   
            if(Vector3.Distance(transform.position, new Vector3(centre_pos.position.x,transform.position.y,transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(centre_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
            
        }
        else if(current_pos == 1)
        {
            if (Vector3.Distance(transform.position, new Vector3(left_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(left_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
            
        }
        else if(current_pos == 2)
        {
            if (Vector3.Distance(transform.position, new Vector3(right_pos.position.x, transform.position.y, transform.position.z)) >= 0.1f)
            {
                Vector3 dir = new Vector3(right_pos.position.x, transform.position.y, transform.position.z) - transform.position;
                transform.Translate(dir.normalized * side_speed * Time.deltaTime, Space.World);
            }
            
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //rb.AddForce(Vector3.up * jump_force);

            rb.linearVelocity = Vector3.up * jump_force;
        }
    }
}
