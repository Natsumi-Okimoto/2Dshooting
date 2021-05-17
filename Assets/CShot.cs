using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CShot : MonoBehaviour
{
    public float Speed = 3.0f;
    public int ShotPower = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = 90.0f;
        transform.position += CUtility.GetDirection(angle) * Speed * Time.deltaTime;

        // �e���i�s�����������悤�ɂ���
        var angles = transform.localEulerAngles;
        angles.z = angle - 90;
        transform.localEulerAngles = angles;

        // 2 �b��ɍ폜����
        Destroy(gameObject, 2);
    }
}
