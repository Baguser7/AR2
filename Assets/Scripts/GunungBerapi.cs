using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunungBerapi : MonoBehaviour
{
    public static GunungBerapi instance;

    public ParticleSystem lavaSystem;

    private void Awake()
    {
        instance = this;
    }
}
