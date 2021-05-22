using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBullet : MonoBehaviour
{
    float Speed = 3.0f, Angle = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector3 dir = pos - transform.position;
        Angle = Mathf.Atan2(pos.y - transform.position.y, pos.x - transform.position.x);
        print(Angle);
        transform.position += CUtility.GetDirectionPI2(Angle) * Speed * Time.deltaTime;

        // íeÇ™êiçsï˚å¸Çå¸Ç≠ÇÊÇ§Ç…Ç∑ÇÈ
        var angles = transform.localEulerAngles;
        angles.z = Angle * Mathf.Rad2Deg - 90;
        transform.localEulerAngles = angles;

        if (CUtility.IsOut(transform.position))
        {
            Destroy(gameObject);
        }
    }

    public void SetParam(float speed, float angle)
    {
        Speed = speed;
        Angle = angle;
    }
}
