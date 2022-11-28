using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjectContexts
{
	public class ProjectContext : Context
	{
        private static bool _isInstalled;

        public static void Install()
        {
            if (_isInstalled)
            {
                return;
            }

            var projectContextPrefab = Resources.Load<ProjectContext>("ProjectContextPrefab");
            var projectContext = Instantiate(projectContextPrefab);

            projectContext.gameObject.name = nameof(ProjectContext);

            DontDestroyOnLoad(projectContext);
            projectContext.InstallContext();

            _isInstalled = true;
        }

        [SerializeField] private EventSystem _eventSystem;

        public static InputManager InputManager;
        public static EventSystem EventSystem;


        public override void InstallContext()
		{
            EventSystem = _eventSystem;

            InputManager = new InputManager();

        }

		public override void DisposeContext()
		{
            EventSystem = null;
            InputManager = null;

        }
	}
}
