using UnityEngine;
//DA�� ������ �����ϴ� ��ũ���ͺ� ������Ʈ
[CreateAssetMenu(menuName = "Scriptable/DAData", fileName = "DAData")]
public class DAData : ScriptableObject
{
    public AudioClip shotClip; //DA �߻� �Ҹ�

    public float damage = 20; //DA�� �⺻ ���ݷ�
    public float timeBetShot = 2.0f; //DA�� �⺻ �߻� ���� 
}
