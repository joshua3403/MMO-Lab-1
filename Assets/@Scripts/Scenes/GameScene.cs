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


		for(int i = 0; i < 5; i++)
		{
            var hero2 = Managers.Object.Spawn<Hero>(new Vector3Int(-10 + Random.RandomRange(-5, 5), -5 + Random.RandomRange(-5, 5), 0), HERO_KNIGHT_ID);
        }

		var camera = Camera.main.GetOrAddComponent<CameraController>();
		camera.Target = heroCamp;

		Managers.UI.ShowBaseUI<UI_Joystick>();


        {
            Monster monster = Managers.Object.Spawn<Monster>(new Vector3Int(0, 1, 0), MONSTER_BEAR_ID);
            monster.CreatureState = ECreatureState.Idle;
        }


        {
            Env monster = Managers.Object.Spawn<Env>(new Vector3Int(0, 2, 0), ENV_TREE1_ID);
            monster.EnvState = EEnvState.Idle;
        }

        // TODO

        return true;
	}

	public override void Clear()
	{

	}
}
