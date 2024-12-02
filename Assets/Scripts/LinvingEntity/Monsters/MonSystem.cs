using Unity.VisualScripting;
using UnityEngine;


//���Ϳ� �̵��� ���� ����, ���ݰ� ������ �߻�޼���� �� ���� ������Ʈ�� ����ϵ���
public class MonSystem : Living //Living�� MonoBehaviour�� �̹� ����ϹǷ� ǥ���� �ʿ� x
{
    //2d�̸� ���������� �����Ƿ� ����Ž� ���� ���� ���� ����

    public GameObject target; //������ ���, �÷��̾�
    protected Rigidbody2D monRigidbody; //���͵��� ������ٵ� ������Ʈ
    public float monSpeed { get; protected set; } //������ �̵� �ӵ�
    public float monDamage { get ; protected set; } //������ ���ݷ�
    protected float attackCoolTime = 1f; //���� ������ �̷���� ��Ÿ��(����)
    protected float lastAttackTime; //������ ���� ���� ����
    

    protected void GetTarget()
    {
        target = GameObject.FindGameObjectWithTag("Player"); //�÷��̾� �±� ���� ���� ������Ʈ�� Ÿ�ٿ� �Ҵ�
        if (target == null)
        {
            Debug.Log("Ÿ�� ����!");
            return;
        }
        monRigidbody = GetComponent<Rigidbody2D>(); //������ ������ٵ� ������Ʈ�� ��������    
    }

    protected virtual void Move()
    {
        if(target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized; //���Ͱ� �̵��Ϸ��� ����
            monRigidbody.linearVelocity = moveDirection * monSpeed;
        }
    }

    public override void Die()
    {
        base.Die();
        Destroy(gameObject);
        //�����鼭 ����ġ�� ���� ������ ����ϴ� ���� �߰�
    }

    public override void OnDamage(float damage, Vector2 hitPoint, Vector2 hitNormal)
    {
        base.OnDamage(damage, hitPoint, hitNormal);
        Debug.Log("�ƾ�");
    }

    protected virtual void Attack() //������ ���� ��ų, �÷��̾ �����ϱ�
    {

    }

    protected virtual void BumpAttack(Collider2D other)
    {
        if (Time.time - lastAttackTime < attackCoolTime) //��Ÿ���� �������� �˻�
        {
            return;
        }
        Vector2 hitPoint = other.ClosestPoint(transform.position);
        Vector2 hitNormal = (hitPoint - (Vector2)transform.position).normalized;

        PlayerInform player = other.GetComponent<PlayerInform>(); //�浹 ����� �÷��̾����� �˻�
        if (player != null) 
        {
            player.OnDamage(monDamage, hitPoint, hitNormal);
            lastAttackTime = Time.time;
        }

    }


}
