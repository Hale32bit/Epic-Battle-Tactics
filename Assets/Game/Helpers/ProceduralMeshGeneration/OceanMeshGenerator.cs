using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneratedMeshes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class OceanMeshGenerator : MonoBehaviour
    {
        public const float PhisicalWidth = 60f;
        private const int VertexPerUnit = 4;
        private const int VertecesPerLine = (int)PhisicalWidth * VertexPerUnit;
        private const int VertecesCount = VertecesPerLine * VertecesPerLine;
        private const int QuadsCount = (VertecesCount - VertecesPerLine * 2 ) + 1;
        private const float PhisicalStepPerVertex = 1f / (float) VertexPerUnit;

        void Start()
        {
            GenerateVertexData(out Vector3[] normals, out Vector4[] tangents, out Vector2[] uv);

            Mesh mesh = new Mesh();
            mesh.vertices = GenerateVertices();
            mesh.triangles = GenerateIndices();
            mesh.normals = normals;
            mesh.tangents = tangents;
            mesh.uv = uv;
            GetComponent<MeshFilter>().mesh = mesh;
        }

        private static void GenerateVertexData(out Vector3[] normals, out Vector4[] tangents, out Vector2[] uv)
        {
            normals = new Vector3[VertecesCount];
            Vector4 tangent = new Vector4(1, 0, 0, 1);
            tangents = new Vector4[VertecesCount];
            uv = new Vector2[VertecesCount];
            for (int i = 0; i < VertecesCount; i++)
            {
                normals[i] = Vector3.up;
                tangents[i] = tangent;
                uv[i] = new Vector2(
                    (float)(i % VertecesPerLine) / (float)VertecesPerLine,
                    (float)(i / VertecesPerLine) / (float)VertecesPerLine);
            }
        }

        private static int[] GenerateIndices()
        {
            int[] indeces = new int[QuadsCount * 6];
            for (int i = 0; i < QuadsCount; i++)
            {
                int numOfQuadInLine = i % (VertecesPerLine - 1);
                int numOfLine = i / (VertecesPerLine - 1);
                int numOfKeyIndex = numOfLine * VertecesPerLine + numOfQuadInLine;
                indeces[i * 6] = numOfKeyIndex;
                indeces[i * 6 + 1] = numOfKeyIndex + 1;
                indeces[i * 6 + 2] = numOfKeyIndex + VertecesPerLine;
                indeces[i * 6 + 3] = numOfKeyIndex + 1;
                indeces[i * 6 + 4] = numOfKeyIndex + VertecesPerLine + 1;
                indeces[i * 6 + 5] = numOfKeyIndex + VertecesPerLine;
                Debug.Log(numOfQuadInLine);
            }

            return indeces;
        }

        private static Vector3[] GenerateVertices()
        {
            Vector3[] vertices = new Vector3[VertecesCount];

            Vector3 forwardLeftCornerOffset = (Vector3.forward + Vector3.left) * PhisicalWidth / 2f;
            for (int i = 0; i < VertecesCount; i++)
            {
                vertices[i] = forwardLeftCornerOffset +
                    (Vector3.right * (i % VertecesPerLine) + Vector3.back * (i / VertecesPerLine)) * PhisicalStepPerVertex;
            }

            return vertices;
        }
    }
}