using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public static GameManager instance { get; private set; } //�̱��� �Ҵ��� �������� ������Ƽ�� �����
    public bool isGameover = false; //���� ���� ����
    [SerializeField] private GameObject mainParent;
    


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            mainParent.SetActive(false);
            
        }

        else
        {
            Destroy(gameObject);
            return;
        }

  
    }

    private void OnSceneLoaded (Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main") 
        {
            StartCoroutine(DelayActivation()); //���� �� �ε�� �� Ȱ��ȭ
        }
    }

    private IEnumerator DelayActivation()
    {
        yield return null; 
        ActivateMainScene();
    }

    private void ActivateMainScene()
    {
        
        if (mainParent != null)
        {
            mainParent.SetActive(true);
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
