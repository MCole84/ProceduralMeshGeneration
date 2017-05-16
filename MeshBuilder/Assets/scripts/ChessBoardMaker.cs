using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ChessBoardMaker : MonoBehaviour
{
    public float cellSize = 1f;
    public int width=24;
    public int height=24;



    // Update is called once per frame
    void Update()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        MeshBuilder mb = new MeshBuilder(6);

        CreateCheckerBoard(mb);
        meshFilter.mesh = mb.CreateMesh();

    }

    private void CreateCheckerBoard(MeshBuilder mb)
    {
        //points for our plane
        Vector3[,] points = new Vector3[width,height];

        float halfCellSize = cellSize / 2f;
        int halfWidth = width / 2;
        int halfHeight = height / 2;

        for (int x = -halfWidth; x < halfWidth; x++)
        {
            for (int y = -halfHeight; y < halfHeight; y++)
            {
                points[x+halfWidth, y+halfWidth] = new Vector3((cellSize * x)+halfCellSize, 0, (cellSize * y)+halfCellSize);
            }
        }
        int submesh = 0;

        for (int x = 0; x < width -1; x++)
        {
            for (int y = 0; y < height -1; y++)
            {
                submesh++;
                Vector3 br = points[x,y];
                Vector3 bl = points[x+1,y];
                Vector3 tr = points[x,y+1];
                Vector3 tl=points[x+1,y+1];

                mb.BuildTriangle(bl, tr, tl, submesh%2);
                mb.BuildTriangle(bl, br, tr, submesh%2);
            }

        }



    }
        
}
