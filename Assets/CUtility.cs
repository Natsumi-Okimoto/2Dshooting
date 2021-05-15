using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CUtility 
{
    static Vector2 MoveLimitTopLeft = new Vector2(-5.7f, 4.2f);
    static Vector2 MoveLimitButtomRight = new Vector2(1.7f, -4.2f);

    static Vector2 EnemyLimitTopLeft = new Vector2(-7.0f, 6.2f);
    static Vector2 EnemyLimitButtomRight = new Vector2(3.0f, -5.2f);
    // �w�肳�ꂽ�ʒu���ړ��\�Ȕ͈͂Ɏ��߂��l��Ԃ�
    public static Vector3 ClampPosition(Vector3 position)
    {
        return new Vector3
        (
            Mathf.Clamp(position.x, MoveLimitTopLeft.x, MoveLimitButtomRight.x),
            Mathf.Clamp(position.y, MoveLimitButtomRight.y, MoveLimitTopLeft.y),
            0
        );
    }
    public static bool IsOut(Vector3 position)
    {
        return (position.x < EnemyLimitTopLeft.x ||
               EnemyLimitTopLeft.y < position.y ||
                EnemyLimitButtomRight.x < position.x ||
                position.y < EnemyLimitButtomRight.y);
    }
   
}
