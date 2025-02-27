using Fusion;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStats : NetworkBehaviour
{
    [Networked] public Color BodyColor { get; set; }//Цвет кузова
    [Networked] public Color LightColor { get; set; }//Цвет фар
    [Networked] public NetworkString<_16> PlayerName { get; set; }//Ник
    [SerializeField] private MeshRenderer body;//кузов
    [SerializeField] private MeshRenderer Light;//Фары
    [SerializeField] private TMP_Text nickText;//Текст Ника
    public override void Spawned()//синхранизация всех характеристик
    {
        if (HasStateAuthority)
        {
            BodyColor = Acount.Instance.LocalData.BodyColor.MyToColor();
            LightColor = Acount.Instance.LocalData.LightColor.MyToColor();
            PlayerName = Acount.Instance.PlayerName.ToString();
        }
        body.material.color = BodyColor;
        Light.material.color = LightColor;
        nickText.text = PlayerName.ToString();
    }
    public void ExitRoom()//Выход из гонки
    {
        if (HasStateAuthority)
        {
            Runner.Shutdown();
        }
    }
}
