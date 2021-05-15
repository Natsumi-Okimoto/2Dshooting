using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private Vector2 pos;
    Animator animator;

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float slowMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Clamp();

        
    }

    private void Move()
    {
        float x = Input.GetAxis(horizontal);
        float y = Input.GetAxis(vertical);

        if (x != 0||y!=0)
        {
            if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
            {
                transform.Translate(x * slowMoveSpeed * Time.deltaTime, y * slowMoveSpeed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(x * moveSpeed * Time.deltaTime, y * moveSpeed * Time.deltaTime, 0);
            }
            animator.SetFloat("H", x);
        }
    }

    void Clamp()
    {
       
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -5, 5);
        pos.y = Mathf.Clamp(pos.y, -5, 5);

        transform.position = pos;
    }

   
}
