using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    public void ChangeSceneName(string name)//������ �������� � ������������ ��������� �����
    {
        StartCoroutine(Loader(name));
    }
    private IEnumerator Loader(string name)//������������ �������� �����
    {
        SceneManager.LoadSceneAsync(name);
        yield return null;
    }
    public void PlayClipButtonDown()//���� UI ������ � �.�
    {
        if(audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.4f);
    }
    public void ExitGame()//����� �� ����
    {
        Application.Quit();
    }
}
