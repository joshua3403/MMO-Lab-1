using UnityEngine;
using UnityEngine.EventSystems;
using static Define;

public abstract class BaseScene : InitBase
{
    public EScene SceneType { get; protected set; } = Define.EScene.Unknown;

    public override bool Initialize()
    {
        if (base.Initialize() == false)
        {
            return false;
        }

        var obj = GameObject.FindObjectOfType(typeof(EventSystem));
        if (obj == null)
        {
            var go = new GameObject() { name = "@EventSystem" };
            go.AddComponent<EventSystem>();
            go.AddComponent<StandaloneInputModule>();
        }

        return true;
    }

    public abstract void Clear();
}
