public class TitleScene : BaseScene
{

    public override bool Initialize()
    {
        if (base.Initialize() == false)
        {
            return false;
        }

        SceneType = Define.EScene.TitleScene;


        return true;
    }

    public override void Clear()
    {

    }
}
