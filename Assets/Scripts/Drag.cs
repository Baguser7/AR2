using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public bool use;
    public bool click;
    public bool stay;

    public Transform target;
    Vector3 posisiAwal;
    Vector3 mousePosition;
    Vector3 distance;
    float startDistance;

    [Range(0f, 1f)]
    public float value;
    private void Start()
    {

        posisiAwal = transform.position;
    }
    private void OnMouseDown()
    {
        click = true;
        
        mousePosition = Input.mousePosition - GetMousePos();
    }
    private void Update()
    {
        distance = target.position - posisiAwal;

        Vector3 dis = posisiAwal + distance * value;

        transform.position = new Vector3
            (transform.position.x, 
            transform.position.y,
            dis.z);
    }
    private void OnMouseDrag()
    {
        transform.position = new Vector3
            (Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).x,
            Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition).y,
            transform.position.z);

        value += Input.GetAxis("Mouse X") * Time.deltaTime;
        value = Mathf.Clamp(value, 0f, 1f);
    }

    private void OnMouseUp()
    {
        click = false;
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}
