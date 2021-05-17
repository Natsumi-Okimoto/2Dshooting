using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CUtility 
{
    static Vector2 MoveLimitTopLeft = new Vector2(-8.1f, 4.2f);
    static Vector2 MoveLimitButtomRight = new Vector2(4.0f, -4.2f);

    static Vector2 EnemyLimitTopLeft = new Vector2(-7.0f, 6.2f);
    static Vector2 EnemyLimitButtomRight = new Vector2(3.0f, -5.2f);
    // 指定された位置を移動可能な範囲に収めた値を返す
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
   
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3
            (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
            );
    }
}
