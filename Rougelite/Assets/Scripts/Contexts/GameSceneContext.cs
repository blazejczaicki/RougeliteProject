using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectContexts
{
	public class GameSceneContext : SceneContext
	{
        public override void InstallContext()
        {
            ProjectContext.InputManager.inputControls.Player.Enable();
        }

        public override void DisposeContext()
        {

        }
    }
}
