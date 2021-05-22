using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private Vector2 pos;
    Animator animator;
    public GameObject[] ShotObjs;
    
    float VX = 0;
    float VY = 0;
    float Sqrt2;

    Dictionary<string, int> InputArray = new Dictionary<string, int>();
    void CalcInput()
    {
        string[] str = { "Fire1", "Fire2", "Fire3" };
        for (int i = 0; i < str.Length; ++i)
        {
            if (Input.GetButton(str[i]))
            {
                ++InputArray[str[i]];
            }
            else
            {
                InputArray[str[i]] = 0;
            }
        }
    }

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float slowMoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Sqrt2 = 1.0f / Mathf.Sqrt(2.0f);
        InputArray["Fire1"] = 0;
        InputArray["Fire2"] = 0;
        InputArray["Fire3"] = 0;
    }


    // Update is called once per frame
    void Update()
    {
        Move();
       // Clamp();
        CalcInput();
        
        if (0 < InputArray["Fire1"] && InputArray["Fire1"] % 6 == 0)
        {
            if (0 < InputArray["Fire3"])//’á‘¬ˆÚ“®’†‚È‚ç
            {
                LowerSpeedShot();
            }
            else // ’ÊíˆÚ“®’†‚È‚ç
            {
                HiSpeedShot();
            }
        }
     }

    int[] CShot0Num = { 2, 4 };
    Vector3[] HiSpeedShotOffsetPos =
    {
        new Vector3(-0.15f,0.8f),
        new Vector3(0.15f,0.8f),
        new Vector3(-0.45f,0.4f),
        new Vector3(0.45f,0.4f),
    };
    // ’ÊíƒVƒ‡ƒbƒg“o˜^
    void HiSpeedShot()
    {
        //	Power < 200 ?0 : 1
        for (int i = 0; i < CShot0Num[1]; i++)
        {
            //SGP.Shot.Add(new CShot(X + CShot0Pos_X[i], Y + CShot0Pos_Y[i], 0.75f, 10));
            Instantiate(ShotObjs[0], transform.position + HiSpeedShotOffsetPos[i], Quaternion.identity);
        }
    }
    Vector3[] LowerSpeedShotOffsetPos =
{
        new Vector3(-0.05f,0.8f),
        new Vector3(0.05f,0.8f),
        new Vector3(-0.25f,0.4f),
        new Vector3(0.25f,0.4f),
    };
    //’á‘¬’ÊíƒVƒ‡ƒbƒg“o˜^
    void LowerSpeedShot()
    {
        for (int i = 0; i < CShot0Num[1]; i++)
        {
            //SGP.Shot.Add(new CShot(X + CShot0Pos_X[i], Y + CShot0Pos_Y[i], 0.75f, 10));
            Instantiate(ShotObjs[0], transform.position + LowerSpeedShotOffsetPos[i], Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }




    private void Move()
    {
        float x = Input.GetAxis(horizontal);
        float y = Input.GetAxis(vertical);

        VX = VY = 0 < InputArray["Fire3"] ? slowMoveSpeed * Time.deltaTime : moveSpeed * Time.deltaTime;
        if (x < 0) VX = -VX; else if (x == 0) VX = 0;
        if (y < 0) VY = -VY; else if (y == 0) VY = 0;
        // ŽÎ‚ß•ûŒü‚Ì‘¬“x’²ß
        if (VX != 0 && VY != 0)
        {
            VX = VX * Sqrt2;
            VY = VY * Sqrt2;
        }
        transform.position = CUtility.ClampPosition(new Vector3(transform.position.x + VX, transform.position.y + VY, 0));
        animator.SetFloat("H", x);
        //if (x != 0||y!=0)
        //{
        //    if(Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift))
        //    {
        //        transform.Translate(x * slowMoveSpeed * Time.deltaTime, y * slowMoveSpeed * Time.deltaTime, 0);
        //    }
        //    else
        //    {
        //        transform.Translate(x * moveSpeed * Time.deltaTime, y * moveSpeed * Time.deltaTime, 0);
        //    }
        //    animator.SetFloat("H", x);
        //}
    }

    void Clamp()
    {
       
        pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -5, 5);
        pos.y = Mathf.Clamp(pos.y, -5, 5);

        transform.position = pos;
    }

   
}
