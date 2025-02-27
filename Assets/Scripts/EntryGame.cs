using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntryGame : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;//���� ��� ����
    [SerializeField] private Button multipleButton;//������ ������ ���� ��� ����� ����
    public void ChangeNamePlayer(string value)//����� ���� � �������� �� �������
    {
        if (string.IsNullOrEmpty(value))
        {
            multipleButton.interactable = false;
        }
        else
        {
            multipleButton.interactable = true;
            Acount.Instance.PlayerName = value;
        }
    }
}
