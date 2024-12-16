using JetBrains.Annotations;
using UnityEngine;
//����ġ ������Ʈ�� ������ ��뿡 ���� ó��
public class EXP : MonoBehaviour, IItem
{
    public float expValue;
    public ExpSpawner expSpawner;

    private bool hasBeenUsed = false;

  
    public void Use(GameObject target)
    { 
        if (hasBeenUsed) return;
        
        PlayerInform player = target.GetComponent<PlayerInform>();
        //Ÿ���� �÷��̾ ������ ����ġ ����
        if (player != null) //������Ʈ �������� ���� = �÷��̾� ���� 
        {
            player.GetExp(expValue); //playerInform�� ����ġ ȹ�� �޼��� ����
            Debug.Log("����ġ ��" + expValue);
        }

        hasBeenUsed = true;

        Destroy(gameObject); //���Ǿ����Ƿ� �ڽ��� �ı�

    }

    public void OnDestroy()
    {
        expSpawner.OnOrbDestroyed();
    }
}
