using Unity.VisualScripting;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_instance;

    public static Managers Instance { get { Initialize(); return s_instance; } }

    #region Core
    private DataManager _dataDataManager = new();
    private PoolManager _poolManager = new();
    private ResourceManager _resourceManager = new();
    private SceneManagerEx _sceneManager = new();
    private SoundManager _soundManager = new();
    private UIManager _uiManager = new();

    public static DataManager DataManager => Instance?._dataDataManager;
    public static PoolManager PoolManager => Instance?._poolManager;
    public static ResourceManager ResourceManager => Instance?._resourceManager;
    public static SceneManagerEx SceneManagerEx => Instance?._sceneManager;
    public static SoundManager SoundManager => Instance?._soundManager;
    public static UIManager UIManager => Instance?._uiManager;
    #endregion



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
}
