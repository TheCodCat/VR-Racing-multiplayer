using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    private LocalData data;
    private void Start()
    {
        data = Acount.Instance.LocalData;
    }
    public void BodyChangeColor(Image image)//смена цвета кузова
    {
        data.BodyColor = image.color.ColorToMy();
        Acount.Instance.LocalData = data;
    }
    public void LightChangeColor(Image image)//смена цвета фар
    {
        data.LightColor = image.color.ColorToMy();
        Acount.Instance.LocalData = data;
    }
}
