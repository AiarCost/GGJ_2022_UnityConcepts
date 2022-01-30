using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowingSequence : MonoBehaviour
{
    public GameObject SequenceGO;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        SequenceGO.SetActive(true);
        yield return new WaitForSeconds(3f);
        SequenceGO.SetActive(false);
    }

}
