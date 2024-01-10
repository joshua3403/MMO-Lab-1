using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;

    public static Managers Instance { get { Initialize(); return s_instance; } }

    public static void Initialize()
    {
        if (s_instance == null)
        {
            if (GameObject.Find("@Managers").IsUnityNull())
            {
                GameObject go = new()
                {
                    name = "@Managers"
                };
                go.AddComponent<Managers>();

                s_instance = go.GetComponent<Managers>();

                DontDestroyOnLoad(go);
            }
        }
    }

    public void ShowUI()
    {
        Debug.Log("Here");
    }
}
