using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraRaycast : MonoBehaviour
{

    [SerializeField] private TMP_Text _objectLabel;
    [HideInInspector] public bool enable = false;
    [HideInInspector] public RaycastHit hit;

    [SerializeField] TMP_Text timerText;


    [SerializeField] float timeIntervalScan;
    [SerializeField] float timeUnIntervalScan;

    float o_timeIntervalScan;
    float o_timeUnIntervalScan;

    string nameTarget;
    string nameActiveUI;

    bool useUI;

    Outline tempOutline;
    GameObject tempUI;

    CanvasUI canvasUI;
    private void Start()
    {
        canvasUI = CanvasUI.instance;

        o_timeIntervalScan = timeIntervalScan;
        o_timeUnIntervalScan = timeUnIntervalScan;

        canvasUI.IntervalUI.gameObject.SetActive(false);

        SetFalseUI(false);
    }

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100000f))
        {
            tempOutline = hit.collider.GetComponent<Outline>();
            switch (hit.collider.tag)
            {
                case "batuan":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.Batuan;
                    break;

                case "kawah":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.Kawah;
                    break;

                case "lubang":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.LubangKepundan;
                    break;

                case "dapur":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.DapurMagma;
                    break;

                case "pipa":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.PipaKepundan;
                    break;

                case "awan":
                    _objectLabel.text = $"{hit.collider.name}";
                    tempOutline.enabled = true;
                    tempUI = canvasUI.AwanPanas;
                    break;

                default:

                    break;
            }

            o_timeUnIntervalScan = timeUnIntervalScan;
            canvasUI.UnIntervalUI.fillAmount = o_timeUnIntervalScan / timeUnIntervalScan;
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
                    tempUI.SetActive(true);

                    canvasUI.UnIntervalUI.gameObject.SetActive(true);
                    canvasUI.UnIntervalUI.fillAmount = o_timeUnIntervalScan / timeUnIntervalScan;
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

                o_timeUnIntervalScan = timeUnIntervalScan;
            }

            if (tempUI != null)
            {
                if (tempUI.activeInHierarchy || nameActiveUI != tempUI.name)
                {
                    _objectLabel.text = "UI Akan tertutup dalam " + o_timeUnIntervalScan.ToString("F0");
                }
                else
                {
                    _objectLabel.text = "Raycast tidak terkena apa - apa";
                }


                //------
                if (o_timeUnIntervalScan > 0)
                {
                    o_timeUnIntervalScan -= Time.deltaTime;

                    canvasUI.UnIntervalUI.fillAmount = o_timeUnIntervalScan / timeUnIntervalScan;
                }
                else if (o_timeUnIntervalScan <= 0)
                {
                    o_timeUnIntervalScan = 0;
                    SetFalseUI(false);

                    useUI = false;
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
