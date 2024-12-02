using UnityEngine;
//������ ����. �ν��� �� �������� ������. ���ڴ� ������ �ð� �������� �ʿ� n���� ������.
//Ȯ���� ���� ����, ����ġ ������ ������, ���۽��� ��ȭ��(����)�� ���� ������.
public class ItemBox : MonoBehaviour, IDamageable //������ ���� �� ����
{
    public GameObject healPackPrefab;
    public ItemBoxSpawner boxSpawner;
    public int myNumber; //������ �ڽ� �ڽ��� ��ȣ 

    private void Awake()
    {
        boxSpawner = FindFirstObjectByType<ItemBoxSpawner>();
    }
    public void OnDamage(float damage, Vector2 hitPoint, Vector2 hitnormal)
    {
        //���� ����
        SpawnHealPack();
        Destroy(gameObject);
    }

    public void SpawnHealPack()
    {
        Quaternion rotation = Quaternion.identity; //�⺻ ȸ��
        Vector2 position = transform.position; //���� ������Ʈ (����)�� ��ġ
        GameObject newHealPack = Instantiate(healPackPrefab, position, rotation); //���� ����
    }

    public void OnDestroy()
    {
        boxSpawner.OnBoxDestroyed(myNumber);
        Debug.Log(myNumber + "��ġ�� �ڽ� �ı�");
    }

}

