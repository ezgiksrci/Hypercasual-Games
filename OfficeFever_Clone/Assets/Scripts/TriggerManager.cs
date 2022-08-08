using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public static PrinterManager printerManager;

    private bool isCollecting;

    private void Start()
    {
        StartCoroutine(CollectingCoroutine());
    }

    IEnumerator CollectingCoroutine()
    {
        while (true)
        {
            if (isCollecting)
            {
                OnPaperCollect?.Invoke();
            }
            yield return new WaitForSeconds(1f);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PrinterManager printer))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<PrinterManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isCollecting = false;
        printerManager = null;
    }
}