using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiGoalPuzzlePiece : MonoBehaviour
{
    public GameObject[] goal;
    public float snapRate;
    private bool placed = false;
    public GameObject SnappedObject = null;
    public int PuzzlePlace;
    // Start is called before the first frame update

    public bool Placed()
    {
        return placed;
    }

    public bool Snap()
    {
        foreach (GameObject go in goal)
        {
            if (((this.transform.position - go.transform.position).magnitude <= this.transform.localScale.x * snapRate / 100) &&
                (((this.transform.eulerAngles - go.transform.eulerAngles).magnitude <= snapRate) ||
                ((this.transform.eulerAngles - go.transform.eulerAngles).magnitude - 360 <= snapRate)) )
            {
                if (go.GetComponent<SnapPos>().IsFull != true)
                {
                    this.transform.position = go.transform.position + new Vector3(0, 0, -0.1f);
                    this.transform.eulerAngles = go.transform.eulerAngles;
                    placed = true;

                    go.GetComponent<SnapPos>().CircleCorrectPosition = PuzzlePlace;
                    go.GetComponent<SnapPos>().IsFull = true;
                    SnappedObject = go;
                    return true;
                }
            }
        }

        return false;
    }

    public void Unsnap()
    {
        if (SnappedObject)
        {
            SnappedObject.GetComponent<SnapPos>().IsFull = false;
            SnappedObject.GetComponent<SnapPos>().CircleCorrectPosition = 0;
            SnappedObject = null;
        }

    }
}
