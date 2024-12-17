using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetsManagement
{
    public class AssetsProvider : IAssetProvider
    {
        public GameObject Instantiate(string path, Vector3 position)
        {
            var prefab = Object.Instantiate(Resources.Load<GameObject>(path), position,
                Quaternion.identity);
            return prefab;
        }

        public void Instantiate(string path)
        {
            Object.Instantiate(Resources.Load<GameObject>(path));
        }
    }
}