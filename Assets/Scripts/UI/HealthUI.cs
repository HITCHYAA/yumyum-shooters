using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public GameObject player; //�÷��̾� ���� ������Ʈ
    private PlayerInform hpInform; //ü�� ���� ������ ����

    public Slider hpBar; //ü�� �����̴� UI

    public void Start()
    {
        hpInform = player.GetComponent<PlayerInform>();
        if (hpInform == null ) { return; }

        hpBar.maxValue = hpInform.entireHealth;
    }

    private void Update()
    {
        UpdateHpUI();
    }

    public void UpdateHpUI()
    {
        hpBar.value = hpInform.health;
        hpBar.maxValue = hpInform.entireHealth; 

    }
}
