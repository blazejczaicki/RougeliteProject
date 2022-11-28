using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectContexts
{
    public class SceneContext : Context
    {
        private void Awake()
        {
            ProjectContext.Install();
            InstallContext();
        }

        public override void InstallContext()
        {
        }

        public override void DisposeContext()
        {
        }
    }
}
