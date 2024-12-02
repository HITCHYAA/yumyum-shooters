using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class DASpawner : MonoBehaviour
{   //DA���� / DA �߻� ���� ���� / ���� �߻� ó��
    public GameObject daPrefab;
    public DAData daData;
    
    //�߻� ���� = spawner������Ʈ�� transform.position
     
   
    private float timeAfterShot; //������ �߻� ���� ���� �ð�


    void Strat()
    {
        timeAfterShot = 0f;
       
    }

    void Update()
    {
        timeAfterShot += Time.deltaTime; 

        if(timeAfterShot >= daData.timeBetShot)
        {
            timeAfterShot = 0f; //�ٽ� �ʱ�ȭ

            //ī�޶� ������ ���콺 ��ǥ�� ��ũ�� ��ǥ�� ��ȯ
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            Vector2 direction = (mousePos - transform.position).normalized; //���� ���ϱ�

            transform.up = direction; 
            GameObject da = Instantiate(daPrefab, transform.position, transform.rotation);
            
        }
        
    }

}

