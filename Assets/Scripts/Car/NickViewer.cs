using UnityEngine;

public class NickViewer : MonoBehaviour
{
    [SerializeField] private Transform panel;
    private Transform target;
    private void Start()
    {
        target = Camera.main.transform;//установка камеры
    }
    private void LateUpdate()//поворот за камерой
    {
        panel.LookAt(target);
    }
}
