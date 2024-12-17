using CodeBase.Infrastructure.AssetsManagement;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;

        public GameFactory(IAssetProvider assets)
        {
            _assets = assets;
        }


        public void CreateHud()
        {
            _assets.Instantiate(AssetsPaths.HudPath);
        }

        public GameObject CreateHero(GameObject target)
        {
            return _assets.Instantiate(AssetsPaths.HeroPath, target.transform.position);
        }
    }
}