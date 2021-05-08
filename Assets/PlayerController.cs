using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float slowMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
           
        }
    }
}