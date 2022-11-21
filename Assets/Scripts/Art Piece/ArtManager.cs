using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    private void Awake()
    {
        if (instance == null)
            instance = GetComponent<T>();
    }

    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        TYPE_03,
        BEACH,
        SNOW
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType artType)
    {
       return artSetups.Find(i => i.artType == artType);
    }

}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;
}
