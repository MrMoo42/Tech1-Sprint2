using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTiles : MonoBehaviour
{
    private Vector3Int position;

    private TileData data;

    private VoidTileManager voidManager;

    private bool isVoid, canDisappear;

    public void MakeDisappear(Vector3Int position, TileData data, VoidTileManager vm)
    {
        this.position = position;
        this.data = data;
        voidManager = vm;

        canDisappear = data.canDisappear;
    }
}
