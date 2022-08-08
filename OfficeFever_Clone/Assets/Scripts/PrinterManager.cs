using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManager : MonoBehaviour
{
    [SerializeField] public List<GameObject> paperList = new();
    [SerializeField] private GameObject paperPrefab;
    [SerializeField] private Transform paperExitPoint;
    [SerializeField] private Transform printerTransform;
    [SerializeField] private int stackLimit = 10;
    Vector3 lastPaperposition;


    private void Start()
    {
        StartCoroutine(PrintPaper());
    }

    IEnumerator PrintPaper()
    {
        while (true)
        {
            if (paperList.Count == 0 || GiveLastPaper() == null)
            {
                GameObject paper = Instantiate(paperPrefab, paperExitPoint.position, Quaternion.identity);
                paper.transform.parent = printerTransform;
                paperList.Add(paper);
            }
            else if (paperList.Count < stackLimit && GiveLastPaper() != null)
            {
                lastPaperposition = GiveLastPaper().transform.position;
                lastPaperposition = new Vector3(lastPaperposition.x, (lastPaperposition.y + 0.12f), lastPaperposition.z);
                GameObject paper = Instantiate(paperPrefab, lastPaperposition, Quaternion.identity);
                paper.transform.parent = printerTransform;
                paperList.Add(paper);
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void RemoveLastPaper()
    {
        if (paperList.Count > 0)
        {
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

    public GameObject GiveLastPaper()
    {
        if (paperList.Count > 0)
        {
            GameObject lastPaper = paperList[^1];
            return lastPaper;
        }
        else return null;
    }
}
