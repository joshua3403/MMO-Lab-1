public class UI_PopUp : UI_Base
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

    public virtual void ClosePopUpUI()
    {
        Managers.UIManager.ClosePopupUI(this);
    }
}
