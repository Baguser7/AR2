using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    public static Gameplay instance;

    int campuran;
    private void Awake()
    {
        instance = this;
    }

    public void SetLava()
    {
        campuran++;
        if (campuran == 3)
        {
            StartCoroutine(coroutine());
            IEnumerator coroutine()
            {
                yield return new WaitForSeconds(1);
                GunungBerapi.instance.lavaSystem.Play();
            }

        }
    }
}
