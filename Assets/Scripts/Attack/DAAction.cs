using Unity.VisualScripting;
using UnityEngine;
//ź���� ����, ����, �Ҹ� ó��
public class DAAction : MonoBehaviour
{
    //������Ʈ��
    
    private Rigidbody2D daRigidbody;

    private float speed = 10f; //źȯ�� �߻� �ӷ�
    private float distance = 20f; //�����Ÿ�
    
    public DAData daData; //���� DA�� ����

    public void Awake()
    {   //źȯ�� �¾ �� ���콺 �����͸� �ٶ󺸸鼭 �¾�ϱ� �������� �̵��� �ϸ� ��
        daRigidbody = GetComponent<Rigidbody2D>(); //������ٵ� ������Ʈ �Ҵ�(�̵��� ���)
        
        daRigidbody.linearVelocity = transform.up.normalized * speed; //** transform*right �� ���콺 ������ ��ǥ�� �ٲ���� �� 
        Destroy(gameObject, (distance/speed)); //2�� ���� ��Ÿ� ���� ���� -> �ı�
        
    }

    public void OnTriggerEnter2D(Collider2D other) //�浹 ó�� �޼��� 
    {
        IDamageable target = other.GetComponent<IDamageable>();
        //����, ���ϰ� �浹�ϰ��ϰ� ���Ϳ��Ը� ������ ����
        //źȯ, ��ų, �÷��̾�� �浹 ����

        Vector2 hitPoint = other.ClosestPoint(transform.position);
        Vector2 hitNormal = (hitPoint - (Vector2)transform.position).normalized;
        if (target != null && other.tag != "Player") //�浹 ����� �÷��̾ �ƴϸ� ������ ������
        {
            target.OnDamage(daData.damage, hitPoint, hitNormal);
            Destroy(gameObject);
        }
        if (other.CompareTag("Obstacle")) //�浿 ����� ��ֹ� �±׸� ������ ���� �� źȯ �ı��ϱ�
        {
            Destroy(gameObject);
        }


    }

}

