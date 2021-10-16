using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneratedMeshes
{

    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class TokenEdgeGenerator : MonoBehaviour
    {

        public const float PhisicalHeight = 0.2f;
        private const float FlatBorder = 0.05f;
        private const float Radius = PhisicalHeight / 2;

        public const float PhysicalWidth = (1f + Radius + FlatBorder) * 2f;




        void Start()
        {
            int Detalization = 9;
            int verticesNum = 8 + 4 * Detalization;
            int trianglesNum = 8 * (Detalization + 1);

            GenerateVertecesAndNormals(Detalization, verticesNum, out Vector3[] normals, out Vector3[] vertices);

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = GenerateIndices(Detalization, trianglesNum);
            mesh.normals = normals;
            GetComponent<MeshFilter>().mesh = mesh;

        }

        private static int[] GenerateIndices(int Detalization, int trianglesNum)
        {
            int[] indeces = new int[3 * trianglesNum];
            for (int i = 0; i < Detalization + 1; i++)
            {
                indeces[i * 24] = i * 4;
                indeces[i * 24 + 1] = i * 4 + 4;
                indeces[i * 24 + 2] = i * 4 + 5;
                indeces[i * 24 + 3] = i * 4;
                indeces[i * 24 + 4] = i * 4 + 1;
                indeces[i * 24 + 5] = i * 4 + 5;

                indeces[i * 24 + 6] = i * 4 + 1;
                indeces[i * 24 + 7] = i * 4 + 5;
                indeces[i * 24 + 8] = i * 4 + 2;

                indeces[i * 24 + 9] = i * 4 + 2;
                indeces[i * 24 + 10] = i * 4 + 5;
                indeces[i * 24 + 11] = i * 4 + 6;

                indeces[i * 24 + 12] = i * 4 + 2;
                indeces[i * 24 + 13] = i * 4 + 3;
                indeces[i * 24 + 14] = i * 4 + 7;

                indeces[i * 24 + 15] = i * 4 + 2;
                indeces[i * 24 + 16] = i * 4 + 6;
                indeces[i * 24 + 17] = i * 4 + 7;

                indeces[i * 24 + 18] = i * 4 + 3;
                indeces[i * 24 + 19] = i * 4 + 0;
                indeces[i * 24 + 20] = i * 4 + 7;

                indeces[i * 24 + 21] = i * 4 + 4;
                indeces[i * 24 + 22] = i * 4 + 0;
                indeces[i * 24 + 23] = i * 4 + 7;
            }

            return indeces;
        }

        private static void GenerateVertecesAndNormals(int Detalization, int verticesNum, out Vector3[] normals, out Vector3[] vertices)
        {
            normals = new Vector3[verticesNum];
            normals[0] = Vector3.down;
            normals[1] = Vector3.down;
            normals[2] = Vector3.down;
            normals[3] = Vector3.down;

            vertices = new Vector3[verticesNum];
            vertices[0] = Vector3.forward + Vector3.left;
            vertices[1] = Vector3.forward + Vector3.right;
            vertices[2] = Vector3.back + Vector3.right;
            vertices[3] = Vector3.back + Vector3.left;

            for (int i = 4; i < (Detalization + 1) * 4; i += 4)
            {
                float alpha = (((float)i / 4 - 1) / (float)Detalization) * Mathf.PI;
                float sina = Mathf.Sin(alpha);
                float cosa = Mathf.Cos(alpha);

                vertices[i] = (Vector3.forward + Vector3.left) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 1] = (Vector3.forward + Vector3.right) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 2] = (Vector3.back + Vector3.right) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 3] = (Vector3.back + Vector3.left) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;

                normals[i] = (Vector3.forward * sina + Vector3.left * sina + Vector3.down * cosa).normalized;
                normals[i + 1] = (Vector3.forward * sina + Vector3.right * sina + Vector3.down * cosa).normalized;
                normals[i + 2] = (Vector3.back * sina + Vector3.right * sina + Vector3.down * cosa).normalized;
                normals[i + 3] = (Vector3.back * sina + Vector3.left * sina + Vector3.down * cosa).normalized;
            }


            vertices[4 + 4 * Detalization] = Vector3.forward + Vector3.left + Vector3.up * 2 * Radius;
            vertices[5 + 4 * Detalization] = Vector3.forward + Vector3.right + Vector3.up * 2 * Radius;
            vertices[6 + 4 * Detalization] = Vector3.back + Vector3.right + Vector3.up * 2 * Radius;
            vertices[7 + 4 * Detalization] = Vector3.back + Vector3.left + Vector3.up * 2 * Radius;
            normals[4 + 4 * Detalization] = Vector3.up;
            normals[5 + 4 * Detalization] = Vector3.up;
            normals[6 + 4 * Detalization] = Vector3.up;
            normals[7 + 4 * Detalization] = Vector3.up;
        }
    }
}