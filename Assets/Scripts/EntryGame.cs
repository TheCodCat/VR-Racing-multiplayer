using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EntryGame : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInput;//поле для ника
    [SerializeField] private Button multipleButton;//кнопка начала игры для общей игры
    public void ChangeNamePlayer(string value)//смена ника и проферка на пустоту
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
