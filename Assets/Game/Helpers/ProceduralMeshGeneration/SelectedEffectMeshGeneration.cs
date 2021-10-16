using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralGeneratedMeshes
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class SelectedEffectMeshGeneration : MonoBehaviour
    {
        public const float PhisicalNormalizedWidthOnBottom = 1.4f;
        public const float PhisicalNormalizedWidthOnTop = 1.45f;
        public const float PhysicallNormalizedHeight = 0.4f;

        void Start()
        {
            const int numOfQuads = 4;
            const int indicesPerQuad = 6 * 2;
            const int vertexPerQuad = 4;

            Mesh mesh = new Mesh();
            mesh.vertices = GenerateVerteces(numOfQuads, vertexPerQuad);
            mesh.triangles = GenerateIndices(numOfQuads, indicesPerQuad);
            GetComponent<MeshFilter>().mesh = mesh;
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

                indeces[i * indicesPerQuad + 6] = i * 4;
                indeces[i * indicesPerQuad + 7] = i * 4 + 2;
                indeces[i * indicesPerQuad + 8] = i * 4 + 1;
                indeces[i * indicesPerQuad + 9] = i * 4;
                indeces[i * indicesPerQuad + 10] = i * 4 + 3;
                indeces[i * indicesPerQuad + 11] = i * 4 + 2;
            }

            return indeces;
        }

        private static Vector3[] GenerateVerteces(int numOfQuads, int vertexPerQuad)
        {
            Vector3[] vertices = new Vector3[vertexPerQuad * numOfQuads];

            vertices[0] = Vector3.forward * PhisicalNormalizedWidthOnBottom + Vector3.left * PhisicalNormalizedWidthOnBottom;
            vertices[1] = Vector3.forward * PhisicalNormalizedWidthOnBottom + Vector3.right * PhisicalNormalizedWidthOnBottom;
            vertices[2] = Vector3.forward * PhisicalNormalizedWidthOnTop + Vector3.right * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;
            vertices[3] = Vector3.forward * PhisicalNormalizedWidthOnTop + Vector3.left * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;

            vertices[4] = Vector3.forward * PhisicalNormalizedWidthOnBottom + Vector3.right * PhisicalNormalizedWidthOnBottom;
            vertices[5] = Vector3.back * PhisicalNormalizedWidthOnBottom + Vector3.right * PhisicalNormalizedWidthOnBottom;
            vertices[6] = Vector3.back * PhisicalNormalizedWidthOnTop + Vector3.right * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;
            vertices[7] = Vector3.forward * PhisicalNormalizedWidthOnTop + Vector3.right * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;

            vertices[8] = Vector3.back * PhisicalNormalizedWidthOnBottom + Vector3.right * PhisicalNormalizedWidthOnBottom;
            vertices[9] = Vector3.back * PhisicalNormalizedWidthOnBottom + Vector3.left * PhisicalNormalizedWidthOnBottom;
            vertices[10] = Vector3.back * PhisicalNormalizedWidthOnTop + Vector3.left * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;
            vertices[11] = Vector3.back * PhisicalNormalizedWidthOnTop + Vector3.right * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;

            vertices[12] = Vector3.back * PhisicalNormalizedWidthOnBottom + Vector3.left * PhisicalNormalizedWidthOnBottom;
            vertices[13] = Vector3.forward * PhisicalNormalizedWidthOnBottom + Vector3.left * PhisicalNormalizedWidthOnBottom;
            vertices[14] = Vector3.forward * PhisicalNormalizedWidthOnTop + Vector3.left * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;
            vertices[15] = Vector3.back * PhisicalNormalizedWidthOnTop + Vector3.left * PhisicalNormalizedWidthOnTop + Vector3.up * PhysicallNormalizedHeight;
            return vertices;
        }
    }
}
