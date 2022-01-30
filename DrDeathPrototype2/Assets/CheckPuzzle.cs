using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPuzzle : MonoBehaviour
{
    public SnapPos[] SnapPosInfo;
    private bool Correct = true;
    public TextMeshProUGUI textMesh;

    public void CheckPuzzleCorrect()
    {
        foreach(SnapPos sp in SnapPosInfo)
        {
            if(sp.CircleCorrectPosition == sp.SnapPosition && Correct)
            {
                Correct = true;
            }
            else
            {
                Correct = false;
            }
        }

        if (Correct)
        {
            
            StartCoroutine(TextPlacement("Correct Sequence!"));
        }
        else
        {
            StartCoroutine(TextPlacement("Puzzle is incorrect..."));
        }

        Correct = true;
    }

    IEnumerator TextPlacement(string TextChange)
    {
        textMesh.text = TextChange;
        yield return new WaitForSeconds(3f);
        textMesh.text = "";
    }
}


