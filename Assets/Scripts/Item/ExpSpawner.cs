using System.Collections;
using UnityEngine;
//����ġ�� ���ؼ� ����ġ ���갡 ���� ����ġ ���� ������
//�� ������ ����ġ ���갡 �����ǵ��� �� 
public class ExpSpawner : MonoBehaviour
{
    public GameObject expOrbPrefab; //����ġ ������ ������
    public GameObject field; //���� ������ ��(�ʵ�)

    public float spawnInterval = 3f; //���� ����
    public int numberOfOrbsPerSpawn = 10; //�ѹ��� �����ϴ� ����
    public int maxOrbs = 100; //���� ����
    public bool isGameover = false; //���� ���� ���� 
    private int currentOrbs = 0; //���� ���� ����

    private (float value, float size, Color color)[] expOrbOptions = new (float, float, Color)[]
    {
        (5f, 0.4f, Color.yellow),
        (10f, 0.5f, Color.blue),
        (25f, 0.65f, Color.red) //��, ũ�� ������ ���� ~ ���õ� ����ġ�� ���� ��� �ɼ��� �ݿ� 
    };
    private int[] weights = { 60, 25, 15 }; //���� Ȯ�� �����ϴ� ����ġ 


    public void Start()
    {
        StartCoroutine(CheckOrbCount());
    }

    private IEnumerator CheckOrbCount()
    {
        while(!isGameover)
        {
            if (currentOrbs < maxOrbs)
            {
                SpawnExpOrbs();
            }//���� ���Ѻ��� ���� ���� ����

            yield return new WaitForSeconds(spawnInterval); //���͹� ��� 
        }
    }
    private (float value, float size, Color color) GetRandomExp() //� ������ ����ġ�� ������ �����ϴ� �޼���
    {
        int totalWeight = 0;
        foreach (int weight in weights)
        {
            totalWeight += weight; //����ġ�� �� ���
        }

        int randomValue = Random.Range(0, totalWeight);

        int cumulWeight = 0; //���� ����ġ
        for (int i = 0; i < expOrbOptions.Length; i++)
        {
            cumulWeight += weights[i];
            if (randomValue < cumulWeight)
            {
                return expOrbOptions[i];
            }
        }

        return expOrbOptions[0];
    }


    public void SpawnExpOrbs() //���� ��ġ�� ���긦 ������ 
    {
        
        Renderer fieldRenderer = field.GetComponent<Renderer>();
        Vector2 fieldSize = fieldRenderer.bounds.size;
        Vector2 fieldCenter = fieldRenderer.bounds.center; //���� ������� ��� ��ǥ �޾ƿ���

        for (int i = 0; i < numberOfOrbsPerSpawn; i++) //�ִ� ���� ��ŭ�� ����
        {
            if (currentOrbs > maxOrbs)
            {
                break;
            } //�������� ���� �������� �׸�

            float randomX = Random.Range(fieldCenter.x - fieldSize.x / 2, fieldCenter.x + fieldSize.x / 2);
            float randomY = Random.Range(fieldCenter.y - fieldSize.y / 2, fieldCenter.y + fieldSize.y / 2);

            Vector2 spawnPosition = new Vector2(randomX, randomY); //���� ���� ���� 


            var selectedOrb = GetRandomExp(); //���� �ɼ� ����

            GameObject newOrb = Instantiate(expOrbPrefab, spawnPosition, Quaternion.identity);
            newOrb.transform.localScale = Vector3.one * selectedOrb.size; //������ ����
            newOrb.GetComponent<Renderer>().material.color = selectedOrb.color; //���� ����

            EXP orbScript = newOrb.GetComponent<EXP>(); //����ġ �� �Ҵ� , ����ġ 
            if (orbScript != null)
            {
                orbScript.expValue = selectedOrb.value;
                orbScript.expSpawner = this;
            }

            currentOrbs++;
        }
    }

    public void OnOrbDestroyed()
    {
        currentOrbs--;
    }
}
