using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CUtility 
{
    static Vector2 MoveLimitTopLeft = new Vector2(-8.1f, 4.2f);
    static Vector2 MoveLimitButtomRight = new Vector2(4.0f, -4.2f);

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
   
    public static Vector3 GetDirection(float angle)
    {
        return new Vector3
            (
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
            );
    }

    public static Vector3 GetDirection360(float angle360)
    {
        float angle = angle360 * Mathf.Deg2Rad;
        return new Vector3
        (
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        );
    }
    // �����Ɋp�x�i 0 �` 1.0f �j��n���ƃx�N�g���ɕϊ����ĕԂ�
    public static Vector3 GetDirection1(float angle1)
    {
        float angle = angle1 / (3.14f * 2);
        return new Vector3
        (
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0
        );
    }
    // �����Ɋp�x�i 0 �` PI2 �j��n���x�N�g���ɕϊ����ĕԂ�
    public static Vector3 GetDirectionPI2(float angle_pi2)
    {
        return new Vector3
        (
            Mathf.Cos(angle_pi2),
            Mathf.Sin(angle_pi2),
            0
        );
    }
    ///�y�@�\�z�}���`�v���X�v���C�g����X���C�X�����X�v���C�g���擾����
    ///�y��1�����z�X�v���C�g�t�@�C�����i���m�ɂ�Resources �t�H���_����̃X�v���C�g�t�@�C���܂ł̃p�X�j
    ///�y��2�����z�擾�������X���C�X���ꂽ�X�v���C�g��
    ///�y�߂�l�z�擾�����X�v���C�g
    public static Sprite GetSprite(string fileName, string spriteName)
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
        return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
    }
    //�n���ꂽ-ang�`ang�܂ł̃����_���Ȋp�x��Ԃ�
    public static float Rang(float ang)
    {
        return (-ang + ang * 2.0f * (Random.value * 10000.0f) / 10000.0f);
    }
}
