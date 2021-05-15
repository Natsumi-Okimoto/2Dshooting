using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireMissile : MonoBehaviour
{
    // 変数の定義（データを入れるための箱を作る）
    public GameObject missilePrefab;
    public float missileSpeed;
    public AudioClip fireSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // プレハブからミサイルオブジェクトを作成し、それをmissileという名前の箱に入れる。
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity) as GameObject;

            Shoot(new Vector2(0, missileSpeed));

            AudioSource.PlayClipAtPoint(fireSound, transform.position);

            // 発射したミサイルを２秒後に破壊（削除）する。
            Destroy(missile, 2.0f);
        }
    }

    public void Shoot(Vector2 dir)
    {
        GetComponent<Rigidbody2D>().AddForce(dir);
    }
}
