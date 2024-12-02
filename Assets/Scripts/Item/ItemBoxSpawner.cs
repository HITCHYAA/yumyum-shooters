using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections;
using Unity.VisualScripting;

//�����۹ڽ��� �� ���� ��ġ�� ���� �ð��� ���� ������ �����ǰ� ��
//���� ��ġ 10�� �� ������ 3 ��ġ�� ���� �� 


public class ItemBoxSpawner : MonoBehaviour
{   
     
    public GameObject itemBoxPrefab; //������ �ڽ� ������
    
    public Transform parentOfPoints; //���� ����Ʈ���� �θ� ������Ʈ, �̹� �Ҵ� �Ǿ� ����
    public Transform[] spawnPoints; //���� ����Ʈ �迭 
    public static HashSet<int> activePoints = new HashSet<int>();//Ȱ��ȭ�� ����Ʈ�� �����ϴ� �ؽü�
    //static���� ����� ����: �ν������� �����ؼ� �� ������ �Կ� 
    public float spawnInterval = 30f; //�ڽ� ���� ����
    public int numberOfBoxSpawn = 3; //�� ���� �����ϴ� �ڽ� ����
    public int maxBox = 16; //�ִ� ���� ����
    public bool isGameover = false; //���� ���� ����

    private int currentBox = 0; //���� �ʿ� �ִ� �ڽ� ��

    private void Awake() //���� ����Ʈ���� �迭�� �ڵ� �Ҵ�����
    {
        if (parentOfPoints != null)
        {
            spawnPoints = parentOfPoints.GetComponentsInChildren<Transform>();
            spawnPoints = System.Array.FindAll(spawnPoints, t => t != parentOfPoints); //�θ� ������Ʈ ����
            //Debug.Log("�� ���� ����Ʈ :" + spawnPoints.Length); �Ҵ� ok
        
        }
    }

    private void Start()
    {
        StartCoroutine(CheckBoxCount());
    }

    private IEnumerator CheckBoxCount()
    {
        while (!isGameover)
        {
            if (currentBox < maxBox) //�ڽ��� �ִ� �������� ���� ���� ����
            {
                SpawnItemBox();
            }
            yield return new WaitForSeconds(spawnInterval); //���͹� ���
        }
    }

    public void SpawnItemBox() //�ڽ� ������
    {
        
        int[] selectedPositiontValues = GeneratreRandInts(0, spawnPoints.Length, numberOfBoxSpawn); //0���� 15���� ������ �� 3���� ����
        //Debug.Log("���õ� ����Ʈ ��: " + selectedPositiontValues.Length); �Ҵ� ok
        //�޾ƿ� �������� �ش��ϴ� ��������Ʈ �����ǿ� �ڽ� ����
        foreach (int i in selectedPositiontValues)
        {
            if (currentBox >= maxBox) { 
                break;
            }

            //Debug.Log("���õ� �ڸ� : " + i); ����
            Transform spawnPosition = spawnPoints[i]; //��ġ �� �޾ƿ���, ���⼭ i�� selectedPositionValues[i]�� ����
            GameObject newBox = Instantiate(itemBoxPrefab, spawnPosition.position, Quaternion.identity); //������@����

            ItemBox box = newBox.GetComponent<ItemBox>(); //��ũ��Ʈ �����ϰ� ��������
            box.myNumber = i; //�����Ǵ� �ڽ��� ��ȣ �ο� 
            currentBox++;
        }

    }
    
    public int[] GeneratreRandInts(int min, int max, int count) //���� ���� 3�� ����� �迭�� ��ȯ�ϴ� �޼���
    {
        HashSet<int> selectedPositions = new HashSet<int>(); //���õ� ���� ���� �ؽü�

        while (selectedPositions.Count < count)
        {
            int randNumber = UnityEngine.Random.Range(min,max); //������ �� ����
            if (!activePoints.Contains(randNumber)) //Ȱ��ȭ�� ����Ʈ �׷쿡 ������ �������� ���� 
            {
                selectedPositions.Add(randNumber); //���� �迭�� �߰�
                activePoints.Add(randNumber); //Ȱ��ȭ ����Ʈ�� �߰�
            }
           
        }

        return selectedPositions.ToArray();
    }

    public void OnBoxDestroyed(int boxNumber)
    {
        currentBox--; //���� �ڽ� ���� ����
        activePoints.Remove(boxNumber); //Ȱ��ȭ ����Ʈ �ݷ��ǿ��� �ش� ��ȣ ����
    }
  

}
