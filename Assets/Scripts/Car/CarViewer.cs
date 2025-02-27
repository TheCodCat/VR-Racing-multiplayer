using UnityEngine;

public class CarViewer : MonoBehaviour
{
    [SerializeField] private MeshRenderer BodyRenderer;
    [SerializeField] private MeshRenderer LightRenderer;
    private void OnEnable()
    {
        Acount.OnChangeData += OnChangeFront;
    }
    private void OnDisable()
    {
        Acount.OnChangeData -= OnChangeFront;
    }
    private void Start()
    {
        OnChangeFront(Acount.Instance.LocalData);
    }
    private void OnChangeFront(LocalData localData)//смена внешнего вида
    {
        BodyRenderer.material.color = localData.BodyColor.MyToColor();
        LightRenderer.material.color = localData.LightColor.MyToColor();
    }
}
