using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject roomObject;
    public Transform baseBlock;

    public Transform blocksParent;
    public Transform[] blocks;

    private void Start()
    {
        blocks = new Transform[blocksParent.childCount];

        for (int i = 0; i < blocksParent.childCount; i++)
        {
            blocks[i] = blocksParent.GetChild(i);
        }
    }
}
