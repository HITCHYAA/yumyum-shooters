using UnityEngine;

public class HealPack : MonoBehaviour, IItem
{
    public float healthValue = 50f;
   
    public void Use(GameObject target)
    {
        PlayerInform player = target.GetComponent<PlayerInform>();
        //Ÿ���� �÷��̾ ������ ü�� ȸ��
        if (player != null) //������Ʈ �������� ���� = �÷��̾� ���� 
        {
            player.Healing(healthValue); //playerInform�� Healing �޼��� ����
            Debug.Log("ȸ���Ǿ��� : " + healthValue);
        }

        Destroy(gameObject); //���Ǿ����Ƿ� �ڽ��� �ı�
    }
}
