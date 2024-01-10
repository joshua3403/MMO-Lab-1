using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public BaseScene CurrentScene => GameObject.FindObjectOfType<BaseScene>();

    public void LoadScene(Define.EScene type)
    {
        SceneManager.LoadScene(GetSceneName(type));
    }

    private string GetSceneName(Define.EScene type)
    {
        return System.Enum.GetName(typeof(Define.EScene), type);
    }

    public void Clear()
    {
        CurrentScene.Clear();
    }
}
