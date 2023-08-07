using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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

    public TextMeshProUGUI text;

    private void Awake()
    {
        instance = this;
    }


}
