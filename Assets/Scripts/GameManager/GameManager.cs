using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance; //�̱��� �Ҵ��� ��������
    public bool isGameover = false; //���� ���� ����




    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
        }

  
    }



    void Update()
    {
        if (isGameover)
        {

        }
    }

    public void OnPlayerDead()
    {
        isGameover = true;
    }
}
