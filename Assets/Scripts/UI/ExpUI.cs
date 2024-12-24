using UnityEngine;
using UnityEngine.UI;
using TMPro;
//����ġ ��, �ؽ�Ʈ�� �����ϴ� ó�� ���� 
public class ExpUI : MonoBehaviour
{
    public GameObject player; //�÷��̾� ������Ʈ
    private PlayerInform expInform; //����ġ ���� ������ ����
    
    public Slider expBar; //����ġ �����̴� UI
    public TextMeshProUGUI levelText; //���� �ؽ�Ʈ UI, TextMeshPro�� �̿��ϹǷ� �̷��� ����
    public TextMeshProUGUI expText; //����ġ �ؽ�Ʈ UI
    public void Start()
    {
        expInform = player.GetComponent<PlayerInform>();
        if (expInform == null) { return; }
        expBar.maxValue = expInform.entireExp;
        
    }

    private void Update()
    {
        UpdateExpUI();
    }

    public void UpdateExpUI()
    {
        expBar.value = expInform.exp;
        expBar.maxValue = expInform.entireExp; //����ġ���� �ִ񰪵� ���� ��������ߴ�.

        expText.text = expInform.exp + " / " + expInform.entireExp;
        levelText.text = "LV : " + expInform.level.ToString();
    }
}
