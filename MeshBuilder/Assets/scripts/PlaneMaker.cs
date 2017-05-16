using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PlaneMaker : MonoBehaviour
{
    public float cellSize = 1f;
    public int width=24;
    public int height=24;



    // Update is called once per frame
    void Update()
    {
        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        MeshBuilder mb = new MeshBuilder(6);

        //points for our plane
        Vector3[,] points = new Vector3[width,height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                points[x, y] = new Vector3(cellSize * x, Mathf.PingPong(x,1), cellSize * y);
            }
        }

        int submesh = 0;

        for (int x = 0; x < width -1; x++)
        {
            for (int y = 0; y < height -1; y++)
            {
                Vector3 br = points[x,y];
                Vector3 bl = points[x+1,y];
                Vector3 tr = points[x,y+1];
                Vector3 tl=points[x+1,y+1];

                mb.BuildTriangle(bl, tr, tl, submesh%6);
                mb.BuildTriangle(bl, br, tr, submesh%6);
            }
            submesh++;
        }
        meshFilter.mesh = mb.CreateMesh();
		
    }
}
