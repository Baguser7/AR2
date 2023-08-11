using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Raycast : MonoBehaviour
{
    [SerializeField] private TMP_Text _objectLabel;
    [HideInInspector] public bool enable = false;
    [HideInInspector] public RaycastHit hit;

    [SerializeField] TMP_Text timerText;


    [SerializeField] float timeIntervalScan;

    float o_timeIntervalScan;

    string nameTarget;
    string nameActiveUI;

    bool useUI;

    Outline tempOutline;
    CampuranVolcano campuranVolcano;

    CanvasUI canvasUI;
    private void Start()
    {
        canvasUI = CanvasUI.instance;

        o_timeIntervalScan = timeIntervalScan;

        canvasUI.IntervalUI.gameObject.SetActive(false);

        SetFalseUI(false);
    }

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100000f))
        {
            tempOutline = hit.collider.GetComponent<Outline>();
            switch (hit.collider.gameObject.name)
            {
                case "Batuan":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    campuranVolcano = hit.collider.GetComponent<CampuranVolcano>();
                    break;

                case "Lava":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    campuranVolcano = hit.collider.GetComponent<CampuranVolcano>();
                    break;

                case "Air":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    campuranVolcano = hit.collider.GetComponent<CampuranVolcano>();
                    break;
                default:

                    break;
            }


            //---------- || -----------
            if (nameTarget == null)
            {
                nameTarget = hit.collider.name;
            }
            //
            if (hit.collider.name == nameTarget)
            {
                TimerUI();

                if (o_timeIntervalScan > 0 && !useUI)
                {
                    o_timeIntervalScan -= Time.deltaTime;

                    canvasUI.IntervalUI.gameObject.SetActive(true);
                    canvasUI.IntervalUI.fillAmount = o_timeIntervalScan / timeIntervalScan;
                }
                else if (o_timeIntervalScan <= 0 && !useUI)
                {
                    useUI = true;
                    o_timeIntervalScan = 0;

                    nameActiveUI = hit.collider.name;

                    SetFalseUI(false);
                    campuranVolcano.Set();

                }
            }
            else
            {
                nameTarget = hit.collider.name;

                useUI = false;
            }
        }

        //Tidak ada yang kena Raycast
        else
        {
            canvasUI.IntervalUI.gameObject.SetActive(false);
            o_timeIntervalScan = timeIntervalScan;


            if (tempOutline != null)
            {
                tempOutline.enabled = false;
                tempOutline = null;
            }

            if (campuranVolcano != null)
            {
                if (campuranVolcano.gameObject.activeInHierarchy || nameActiveUI != campuranVolcano.name)
                {

                }
                else
                {
                    _objectLabel.text = "Raycast tidak terkena apa - apa";
                }
            }
        }
    }

    void SetFalseUI(bool value)
    {
        canvasUI.LubangKepundan.SetActive(value);
        canvasUI.AwanPanas.SetActive(value);
        canvasUI.PipaKepundan.SetActive(value);
        canvasUI.Kawah.SetActive(value);
        canvasUI.DapurMagma.SetActive(value);
        canvasUI.Batuan.SetActive(value);

        canvasUI.UnIntervalUI.gameObject.SetActive(value);
    }

    void TimerUI()
    {
        timerText.text = string.Format("{0} {1}", "Timer :", timeIntervalScan.ToString("F2"));
    }
}
