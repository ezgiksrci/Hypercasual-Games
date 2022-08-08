using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> collectedPaperList = new();
    [SerializeField] Transform collectedPaperPoint;
    private static float paperAxisY = 0;

    private void OnEnable()
    {
        TriggerManager.OnPaperCollect += TakePaper;
    }

    private void OnDisable()
    {
        TriggerManager.OnPaperCollect -= TakePaper;
    }

    void TakePaper()
    {
        GameObject lastPaper = TriggerManager.printerManager.GiveLastPaper();

        if (lastPaper != null)
        {
            lastPaper.transform.parent = collectedPaperPoint;
            lastPaper.transform.position = collectedPaperPoint.position + new Vector3(0, paperAxisY, 0);
            lastPaper.transform.localRotation = Quaternion.Euler(0, 0, 0);
            collectedPaperList.Add(lastPaper);
            TriggerManager.printerManager.RemoveLastPaper();
            paperAxisY += 0.12f;
        }

    }

}
