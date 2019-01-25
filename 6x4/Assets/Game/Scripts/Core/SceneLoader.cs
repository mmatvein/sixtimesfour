using System;
using JetBrains.Annotations;

namespace Game.Scripts.Core
{
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