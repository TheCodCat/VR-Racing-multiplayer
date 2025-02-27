using UnityEngine;

public class NickViewer : MonoBehaviour
{
    [SerializeField] private Transform panel;
    private Transform target;
    private void Start()
    {
        target = Camera.main.transform;//��������� ������
    }
    private void LateUpdate()//������� �� �������
    {
        panel.LookAt(target);
    }
}
