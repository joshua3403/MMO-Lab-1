using UnityEngine;

public class InitBase : MonoBehaviour
{
    protected bool _init = false;

    public virtual bool Initialize()
    {
        if (_init)
        {
            return false;
        }

        _init = true;
        return true;
    }

    private void Awake()
    {
        Initialize();
    }
}
