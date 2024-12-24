using UnityEngine;
using System.Collections.Generic;

public class MonPool : MonoBehaviour
{
    public GameObject prefab; //������ ������ ������
    public int poolSize; //Ǯ ũ��

    private List<GameObject> pool = new List<GameObject>();

    public void InitializePool(GameObject prefab, int initialPoolSize) //Ǯ �ʱ�ȭ �Լ� 
    {
        this.prefab = prefab;
        this.poolSize = initialPoolSize;
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(prefab); //���� ������Ʈ ����
            obj.SetActive(false);
            pool.Add(obj); //������Ʈ Ǯ�� ���������� ������ ���� ������Ʈ �߰�
        }
    }


    public GameObject GetObject() //������Ʈ Ǯ���� ������Ʈ�� �������� �޼���
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy) 
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(prefab); //Ǯ�� ������ ������ �� ��ü �߰�
        newObj.SetActive(false);
        pool.Add(newObj); //�� ��ü�� Ǯ�� �߰��� 
        return newObj;
    }


    public void ReturnObject(GameObject obj) //������Ʈ�� Ǯ�� ��ȯ�ϴ� �޼���
    {
        obj.SetActive(false);
    }
    
}
