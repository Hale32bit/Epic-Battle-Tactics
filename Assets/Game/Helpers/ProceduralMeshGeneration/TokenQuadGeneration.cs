using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneratedMeshes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class TokenQuadGeneration : MonoBehaviour
    {
        void Start()
        {
            Mesh mesh = new Mesh();

            mesh.vertices = GenerateVerteces();
            mesh.triangles = GenerateIndices();
            mesh.normals = GenerateNormals();
            mesh.tangents = GenerateTangents();
            mesh.uv = GenerateUV();
            mesh.uv2 = GenerateUV2();

            GetComponent<MeshFilter>().mesh = mesh;

        }

        private static Vector2[] GenerateUV2()
        {
            Vector2[] uv2 = new Vector2[4];
            uv2[0] = new Vector2(0.0f, 0.0f);
            uv2[1] = new Vector2(0.0f, 1.0f);
            uv2[2] = new Vector2(1.0f, 1.0f);
            uv2[3] = new Vector2(1.0f, 0.0f);
            return uv2;
        }

        private static Vector2[] GenerateUV()
        {
            Vector2[] uv = new Vector2[4];
            uv[0] = new Vector2(0.0f, 0.5f);
            uv[1] = new Vector2(0.5f, 1.0f);
            uv[2] = new Vector2(1.0f, 0.5f);
            uv[3] = new Vector2(0.5f, 0.0f);
            return uv;
        }

        private static Vector4[] GenerateTangents()
        {
            Vector4 tangent = new Vector4(1, 0, 0, -1);
            Vector4[] tangents = new Vector4[4]
                {tangent, tangent,tangent,tangent};
            return tangents;
        }

        private static Vector3[] GenerateNormals()
        {
            return new Vector3[4]
                { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
        }

        private static int[] GenerateIndices()
        {
            return new int[6] { 0, 1, 2, 0, 2, 3 };
        }

        private static Vector3[] GenerateVerteces()
        {
            Vector3[] vertices = new Vector3[4];
            vertices[0] = Vector3.forward + Vector3.left;
            vertices[1] = Vector3.forward + Vector3.right;
            vertices[2] = Vector3.back + Vector3.right;
            vertices[3] = Vector3.back + Vector3.left;
            return vertices;
        }
    }
}