using UnityEngine;

public static class Extension
{
    public static Color MyToColor(this MyColor myColor)//цвет из моего цвета / преобразование
    {
        Color newColor = new Color(myColor.r, myColor.g, myColor.b);
        return newColor;
    }
    public static MyColor ColorToMy(this Color color)//мой цвет из цвета / преобразование
    {
        MyColor newColor = new MyColor(color.r, color.g, color.b);
        return newColor;
    }

}
