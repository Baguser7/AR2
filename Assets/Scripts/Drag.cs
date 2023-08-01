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
        print(mousePosition);
    }
    private void Update()
    {

    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);

        
        if (startDistance == 0) startDistance = Vector2.Distance(transform.position, target.position);
        float distanceV3 = Vector2.Distance(transform.position, target.position);
        value = distanceV3 / startDistance;
        print("distanceV3 " + distanceV3 + " startDistance " + startDistance + " per " + distanceV3 / startDistance);
        value = Mathf.Clamp(value, 0f, 1f);

        float distanceZ = target.position.z - posisiAwal.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, posisiAwal.z + distanceZ * value);
    }

    private void OnMouseUp()
    {
        click = false;


        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(0.1f);
            if (stay) use = true;
            else use = false;
        }

    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}
