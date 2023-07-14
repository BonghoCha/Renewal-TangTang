using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class ResourceManager
{
    public void LoadAsync<T>(string key, Action onCallback = null) where T : MonoBehaviour
    {
        var a = Addressables.LoadAssetAsync<T>(key);
        a.Completed += (result) =>
        {
        };
    }
}
