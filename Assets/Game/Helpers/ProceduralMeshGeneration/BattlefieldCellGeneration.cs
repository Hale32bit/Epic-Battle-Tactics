using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneratedMeshes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class BattlefieldCellGeneration : MonoBehaviour
    {
        public const float PhisicalNormalizedWidth = 1.5f;
        public const float PhysicallNormalizedHeight = 5;

        void Start()
        {
            const int numOfQuads = 5;
            const int indicesPerQuad = 6;
            const int vertexPerQuad = 4;

            Mesh mesh = new Mesh();

            mesh.vertices = GenerateVerteces(numOfQuads, vertexPerQuad);
            mesh.triangles = GenerateIndices(numOfQuads, indicesPerQuad);
            mesh.normals = GenerateNormals(numOfQuads);
            mesh.uv = GenerateUV(numOfQuads);
            GetComponent<MeshFilter>().mesh = mesh;

        }

        private static Vector2[] GenerateUV(int numOfQuads)
        {
            Vector2[] uv = new Vector2[4 * numOfQuads];
            uv[0] = new Vector2(0.0f, 1.0f);
            uv[1] = new Vector2(0.5f, 1.0f);
            uv[2] = new Vector2(0.5f, 0.0f);
            uv[3] = new Vector2(0.0f, 0.0f);

            for (int i = 1; i < numOfQuads; i++)
            {
                uv[i * 4] = new Vector2(0.5f, 1.0f * PhysicallNormalizedHeight);
                uv[i * 4 + 1] = new Vector2(1.0f, 1.0f * PhysicallNormalizedHeight);
                uv[i * 4 + 2] = new Vector2(1.0f, 0.0f);
                uv[i * 4 + 3] = new Vector2(0.5f, 0.0f);
            }

            return uv;
        }

        private static Vector3[] GenerateNormals(int numOfQuads)
        {
            return new Vector3[4 * numOfQuads]
             {
                 Vector3.up, Vector3.up, Vector3.up, Vector3.up ,
                 Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward ,
                 Vector3.right, Vector3.right, Vector3.right, Vector3.right ,
                 Vector3.back, Vector3.back, Vector3.back, Vector3.back,
                 Vector3.left, Vector3.left, Vector3.left, Vector3.left
             };
        }

        private static int[] GenerateIndices(int numOfQuads, int indicesPerQuad)
        {
            int[] indeces = new int[indicesPerQuad * numOfQuads];
            for (int i = 0; i < numOfQuads; i++)
            {
                indeces[i * indicesPerQuad] = i * 4;
                indeces[i * indicesPerQuad + 1] = i * 4 + 1;
                indeces[i * indicesPerQuad + 2] = i * 4 + 2;
                indeces[i * indicesPerQuad + 3] = i * 4;
                indeces[i * indicesPerQuad + 4] = i * 4 + 2;
                indeces[i * indicesPerQuad + 5] = i * 4 + 3;
            }

            return indeces;
        }

        private static Vector3[] GenerateVerteces(int numOfQuads, int vertexPerQuad)
        {
            Vector3[] vertices = new Vector3[vertexPerQuad * numOfQuads];
            vertices[0] = Vector3.forward * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;
            vertices[1] = Vector3.forward * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;
            vertices[2] = Vector3.back * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;
            vertices[3] = Vector3.back * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;

            vertices[4] = Vector3.forward * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[5] = Vector3.forward * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[6] = Vector3.forward * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;
            vertices[7] = Vector3.forward * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;

            vertices[8] = Vector3.forward * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[9] = Vector3.back * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[10] = Vector3.back * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;
            vertices[11] = Vector3.forward * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;

            vertices[12] = Vector3.back * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[13] = Vector3.back * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[14] = Vector3.back * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;
            vertices[15] = Vector3.back * PhisicalNormalizedWidth + Vector3.right * PhisicalNormalizedWidth;

            vertices[16] = Vector3.back * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[17] = Vector3.forward * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth + Vector3.down * PhysicallNormalizedHeight;
            vertices[18] = Vector3.forward * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;
            vertices[19] = Vector3.back * PhisicalNormalizedWidth + Vector3.left * PhisicalNormalizedWidth;
            return vertices;
        }
    }
}