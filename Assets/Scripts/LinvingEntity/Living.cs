using System;
using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class Living : MonoBehaviour, IDamageable
{
    public float entireHealth { get; protected set; } //���� ü�� 
    public float health { get; protected set; } //�� ü��
    public bool dead { get; protected set; } //��� ����
    public event Action onDeath; //��� �� �̺�Ʈ
     //Ȱ��ȭ �� �� ����, �ʱ�ȭ ó��
  
    protected virtual void InitializeHealth()//������ �ʱ�ȭ�ϴ� �޼���
    {
        dead = false; //��� == false
        health = entireHealth; //���� ü���� ���� ü������
    }
    public virtual void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        //�������� �޾��� �� ó��
        health -= damage; //���� ��������ŭ ü�� ����
        if (health <= 0 && !dead) //ü���� 0 ����&& ���� �� �׾�����
        {
            Die(); //����
        }
    }

    public virtual void Healing(float newHealth)
    {
        if (dead)
        {
            return;
        }

        //ȸ�� ó��
        health += newHealth; //ȸ������ŭ ü�� ����
        if (health > entireHealth) //���뺸�� ü���� Ŀ���� �ִ� ü������
        {
            health = entireHealth;
        }

    }

    public virtual void Die()
    {
        //���� ó��
        if (onDeath != null) //onDeath �̺�Ʈ�� ��ϵ� �޼��� ������ ����
        {
            onDeath();
        }

        dead = true;

    }
}
