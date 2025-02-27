using Fusion;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerStats : NetworkBehaviour
{
    [Networked] public Color BodyColor { get; set; }//���� ������
    [Networked] public Color LightColor { get; set; }//���� ���
    [Networked] public NetworkString<_16> PlayerName { get; set; }//���
    [SerializeField] private MeshRenderer body;//�����
    [SerializeField] private MeshRenderer Light;//����
    [SerializeField] private TMP_Text nickText;//����� ����
    public override void Spawned()//������������� ���� �������������
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
    public void ExitRoom()//����� �� �����
    {
        if (HasStateAuthority)
        {
            Runner.Shutdown();
        }
    }
}
