using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampuranVolcano : MonoBehaviour
{
    public string code;
    Animator animator;

    public bool use;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnMouseUp()
    {

        Set();
    }

    public void Set()
    {
        CanvasUI.instance.text.text = gameObject.name;

        if (!use)
        {
            use = true;

            animator.SetTrigger(code);
            Gameplay.instance.SetLava();
            GetComponent<BoxCollider>().enabled = false;

            StartCoroutine(coroutine());
            IEnumerator coroutine()
            {
                yield return new WaitForSeconds(1);
                Destroy(gameObject);
            }
        }
    }
}
