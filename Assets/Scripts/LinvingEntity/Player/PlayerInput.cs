using UnityEditor.Build.Content;
using UnityEngine;
//�÷��̾� ĳ���� ������ ���� �Է� ���� ��ũ��Ʈ
//������ �Է°��� ����� �� �ְ� �ϱ�
public class PlayerInput : MonoBehaviour
{
    public string xInputName = "Horizontal"; //�¿��̵� �Է��� �̸�
    public string yInputName = "Vertical"; //�յ��̵� �Է��� �̸�

    public float xSense {  get; private set; }
    public float ySense { get; private set; }

    private void Update()
    {
        //if (GameManager.instance != null && GameManager.instance.isGameover) 
        //{
            //���ӿ��� �����̰ų� ���� �Ŵ����� ���� �� �Է� �������� x
           // xSense = 0;
           // ySense = 0;
           // return;
       // }

        xSense = Input.GetAxis(xInputName);
        ySense = Input.GetAxis(yInputName);
    }
}
 