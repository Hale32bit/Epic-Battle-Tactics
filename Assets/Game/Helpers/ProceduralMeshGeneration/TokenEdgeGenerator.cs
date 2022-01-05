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
            int verticesNum = 10 + 5 * Detalization;
            int trianglesNum = 8 * (Detalization + 1);

            GenerateVertecesAndNormals(Detalization, verticesNum, out Vector3[] normals, out Vector3[] vertices, out Vector2[] uvs);

            Mesh mesh = new Mesh();
            mesh.vertices = vertices;
            mesh.triangles = GenerateIndices(Detalization, trianglesNum);
            mesh.normals = normals;
            mesh.uv = uvs;
            GetComponent<MeshFilter>().mesh = mesh;

        }

        private static int[] GenerateIndices(int Detalization, int trianglesNum)
        {
            int[] indeces = new int[3 * trianglesNum];
            for (int i = 0; i < Detalization + 1; i++)
            {
                indeces[i * 24] = i * 5;
                indeces[i * 24 + 1] = i * 5 + 5;
                indeces[i * 24 + 2] = i * 5 + 6;

                indeces[i * 24 + 3] = i * 5;
                indeces[i * 24 + 4] = i * 5 + 1;
                indeces[i * 24 + 5] = i * 5 + 6;

                indeces[i * 24 + 6] = i * 5 + 1;
                indeces[i * 24 + 7] = i * 5 + 6;
                indeces[i * 24 + 8] = i * 5 + 2;

                indeces[i * 24 + 9] = i * 5 + 2;
                indeces[i * 24 + 10] = i * 5 + 6;
                indeces[i * 24 + 11] = i * 5 + 7;

                indeces[i * 24 + 12] = i * 5 + 2;
                indeces[i * 24 + 13] = i * 5 + 3;
                indeces[i * 24 + 14] = i * 5 + 8;

                indeces[i * 24 + 15] = i * 5 + 2;
                indeces[i * 24 + 16] = i * 5 + 7;
                indeces[i * 24 + 17] = i * 5 + 8;

                indeces[i * 24 + 18] = i * 5 + 3;
                indeces[i * 24 + 19] = i * 5 + 4;
                indeces[i * 24 + 20] = i * 5 + 8;

                indeces[i * 24 + 21] = i * 5 + 9;
                indeces[i * 24 + 22] = i * 5 + 4;
                indeces[i * 24 + 23] = i * 5 + 8;
            }

            return indeces;
        }

        private static void GenerateVertecesAndNormals(int Detalization, int verticesNum, out Vector3[] normals, out Vector3[] vertices, out Vector2[] uvs)
        {
            uvs = new Vector2[verticesNum];
            uvs[0] = new Vector2(0, 0);
            uvs[1] = new Vector2(0.25f, 0);
            uvs[2] = new Vector2(0.5f, 0);
            uvs[3] = new Vector2(0.75f, 0);
            uvs[4] = new Vector2(1f, 0);


            normals = new Vector3[verticesNum];
            normals[0] = Vector3.down;
            normals[1] = Vector3.down;
            normals[2] = Vector3.down;
            normals[3] = Vector3.down;
            normals[4] = Vector3.down;


            vertices = new Vector3[verticesNum];
            vertices[0] = Vector3.forward + Vector3.left;
            vertices[1] = Vector3.forward + Vector3.right;
            vertices[2] = Vector3.back + Vector3.right;
            vertices[3] = Vector3.back + Vector3.left;
            vertices[4] = vertices[0];

            for (int i = 5; i < (Detalization + 1) * 5; i += 5)
            {
                float alpha = (((float)i / 5 - 1) / (float)Detalization) * Mathf.PI;
                float sina = Mathf.Sin(alpha);
                float cosa = Mathf.Cos(alpha);

                vertices[i] = (Vector3.forward + Vector3.left) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 1] = (Vector3.forward + Vector3.right) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 2] = (Vector3.back + Vector3.right) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 3] = (Vector3.back + Vector3.left) * (1 + FlatBorder + sina * Radius) + Vector3.up * (1 - cosa) * Radius;
                vertices[i + 4] = vertices[i];


                normals[i] = (Vector3.forward * sina + Vector3.left * sina + Vector3.down * cosa).normalized;
                normals[i + 1] = (Vector3.forward * sina + Vector3.right * sina + Vector3.down * cosa).normalized;
                normals[i + 2] = (Vector3.back * sina + Vector3.right * sina + Vector3.down * cosa).normalized;
                normals[i + 3] = (Vector3.back * sina + Vector3.left * sina + Vector3.down * cosa).normalized;
                normals[i + 4] = normals[i];

                float uvStep = 1f / (5 * (float)(Detalization + 1));

                uvs[i] = new Vector2(0, (float)i * uvStep);
                uvs[i + 1] = new Vector2(0.25f, (float)i * uvStep);
                uvs[i + 2] = new Vector2(0.5f, (float)i * uvStep);
                uvs[i + 3] = new Vector2(0.75f, (float)i * uvStep);
                uvs[i + 4] = new Vector2(1f, (float)i * uvStep);
            }


            vertices[5 + 5 * Detalization] = Vector3.forward + Vector3.left + Vector3.up * 2 * Radius;
            vertices[6 + 5 * Detalization] = Vector3.forward + Vector3.right + Vector3.up * 2 * Radius;
            vertices[7 + 5 * Detalization] = Vector3.back + Vector3.right + Vector3.up * 2 * Radius;
            vertices[8 + 5 * Detalization] = Vector3.back + Vector3.left + Vector3.up * 2 * Radius;
            vertices[9 + 5 * Detalization] = vertices[5 + 5 * Detalization];

            normals[5 + 5 * Detalization] = Vector3.up;
            normals[6 + 5 * Detalization] = Vector3.up;
            normals[7 + 5 * Detalization] = Vector3.up;
            normals[8 + 5 * Detalization] = Vector3.up;
            normals[9 + 5 * Detalization] = Vector3.up;

            uvs[5 + 5 * Detalization] = new Vector2(0, 1f);
            uvs[6 + 5 * Detalization] = new Vector2(0.25f, 1f);
            uvs[7 + 5 * Detalization] = new Vector2(0.5f, 1f);
            uvs[8 + 5 * Detalization] = new Vector2(0.75f, 1f);
            uvs[9 + 5 * Detalization] = new Vector2(1f, 1f);
        }
    }
}