using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    public static CanvasUI instance;

    public GameObject
    LubangKepundan,
    AwanPanas,
    PipaKepundan,
    Kawah,
    DapurMagma,
    Batuan;

    public Image IntervalUI;
    public Image UnIntervalUI;


    private void Awake()
    {
        instance = this;
    }


}
