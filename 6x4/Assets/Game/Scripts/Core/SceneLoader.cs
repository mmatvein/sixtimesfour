namespace Game.Scripts.Core
{
	using System;
	using JetBrains.Annotations;

	public interface ISceneLoader
    {
        void LoadNextGameScene();
    }

    [UsedImplicitly]
    public class SceneLoader : ISceneLoader
    {
        public void LoadNextGameScene()
        {
            throw new NotImplementedException();
        }
    }
}