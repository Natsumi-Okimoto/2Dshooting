using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour
{
    public class CBulletFactory
    {
        public GameObject Bullet;
        public float Radius;
        public string[] SpriteName;
        public Sprite[] BulletSprite;
        public bool ColliderType;
        float SizeX, SizeY;
        public CBulletFactory(string[] sprite_name, bool collider_type, float radius = 0.5f, float size_x = 0.5f, float size_y = 0.5f)
        {
            Radius = radius;
            SpriteName = sprite_name;
            BulletSprite = new Sprite[SpriteName.Length];
            ColliderType = collider_type;
            SizeX = size_x;
            SizeY = size_y;
        }
        public void Load()
        {
            for (int i = 0; i < SpriteName.Length - 1; ++i)
            {
                BulletSprite[i] = CUtility.GetSprite(SpriteName[0], SpriteName[i + 1]);
            }
        }

        public void CreateBullet(Vector3 pos, int color)
        {
            GameObject newParent = new GameObject("Empty");
            Bullet = Instantiate(newParent, pos, Quaternion.identity);
            Bullet.tag = "Bullet";
            SpriteRenderer sr = Bullet.AddComponent<SpriteRenderer>();
            sr.sprite = BulletSprite[color];
            sr.sortingLayerName = "Bullet";
            Bullet.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Bullet.AddComponent<CBullet>();
            if (ColliderType)
            {
                CircleCollider2D cc = Bullet.AddComponent<CircleCollider2D>();
                cc.radius = Radius;
                cc.isTrigger = true;
            }
            else
            {
                BoxCollider2D bc = Bullet.AddComponent<BoxCollider2D>();
                bc.size = new Vector2(SizeX, SizeY);
                bc.isTrigger = true;
            }
            Destroy(newParent);
        }
    }
        public CBulletFactory[] BulletFactory = new CBulletFactory[]
            {
            new CBulletFactory(new string[]{ "img/bullet/b0","b0_0","b0_1","b0_2","b0_3","b0_4" }, true),
            new CBulletFactory(new string[]{ "img/bullet/b1","b1_0","b1_1","b1_2","b1_3","b1_4","b1_5" },true),
            };
   


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < BulletFactory.Length; ++i)
        {
            BulletFactory[i].Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
