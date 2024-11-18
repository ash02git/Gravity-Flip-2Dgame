using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentManager : MonoBehaviour
{
    public List<GameObject> segmentPrefabs;
    public GameObject previousSegment;
    public GameObject currentSegment;
    public GameObject nextSegment;

    private void Awake()
    {
        previousSegment =null;
        //
        nextSegment = null;
    }

    private void Start()
    {
        currentSegment = Instantiate(segmentPrefabs[0]);
    }
    public void LoadNextSegment()
    {
        float offset = currentSegment.GetComponent<SegmentType>().GetOffset();
        Vector3 nextSegmentPosition = currentSegment.transform.position;
        nextSegmentPosition.x = nextSegmentPosition.x +offset;
        nextSegment = Instantiate(segmentPrefabs[Random.Range(0, segmentPrefabs.Count)], nextSegmentPosition,Quaternion.identity);

        previousSegment = currentSegment;
        currentSegment = nextSegment;
        nextSegment = null;
        //StartCoroutine(DestroySegmentTimer(previousSegment));
        Destroy(previousSegment, 5);
    }
}
