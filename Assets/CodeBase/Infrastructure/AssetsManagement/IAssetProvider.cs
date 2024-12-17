using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetsManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 position);
        void Instantiate(string path);
    }
}