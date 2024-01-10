public class GameScene : BaseScene
{


    public override bool Initialize()
    {
        if (base.Initialize() == false)
        {
            return false;
        }

        SceneType = Define.EScene.GameScene;

        // TODO

        return true;
    }

    public override void Clear()
    {

    }

}
