public class UI_Scene : UI_Base
{
    public override bool Initialize()
    {
        if (base.Initialize() == false)
        {
            return false;
        }

        Managers.UIManager.SetCanvas(gameObject, false);
        return true;
    }
}
