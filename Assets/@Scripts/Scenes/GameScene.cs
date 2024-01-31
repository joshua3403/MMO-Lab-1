using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Define;

public class GameScene : BaseScene
{
	public override bool Init()
	{
		if (base.Init() == false)
			return false;

		SceneType = EScene.GameScene;

		var map = Managers.Resource.Instantiate("BaseMap");
		map.transform.position = Vector3.zero;
		map.name = "@BaseMap";

        var heroCamp = Managers.Object.Spawn<HeroCamp>(new Vector3Int(-10, -5, 0), 0);


        for (int i = 0; i < 5; i++)
        {
            //int heroTemplateID = HERO_WIZARD_ID + Random.Range(0, 5);
            int heroTemplateID = HERO_KNIGHT_ID;
            //int heroTemplateID = HERO_WIZARD_ID;
            Hero hero = Managers.Object.Spawn<Hero>(new Vector3Int(-10 + Random.Range(-5, 5), -5 + Random.Range(-5, 5), 0), heroTemplateID);
        }

        var camera = Camera.main.GetOrAddComponent<CameraController>();
		camera.Target = heroCamp;

		Managers.UI.ShowBaseUI<UI_Joystick>();


        {
            Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_BEAR_ID);
            Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_GOBLIN_ARCHER_ID);
            //Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_SLIME_ID);
            Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_SPIDER_COMMON_ID);
            Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_WOOD_COMMON_ID);

        }


        {
            Managers.Object.Spawn<Env>(new Vector3Int(0, 2, 0), ENV_TREE1_ID);
        }

        // TODO

        return true;
	}

	public override void Clear()
	{

	}
}
