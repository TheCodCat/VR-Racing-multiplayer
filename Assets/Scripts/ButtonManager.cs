using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    public void ChangeSceneName(string name)//запуск корутины с ассинхронной загрузкой сцены
    {
        StartCoroutine(Loader(name));
    }
    private IEnumerator Loader(string name)//ассинхронная загрузка сцены
    {
        SceneManager.LoadSceneAsync(name);
        yield return null;
    }
    public void PlayClipButtonDown()//звук UI кнопок и т.д
    {
        if(audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, transform.position, 0.4f);
    }
    public void ExitGame()//выход из игры
    {
        Application.Quit();
    }
}
