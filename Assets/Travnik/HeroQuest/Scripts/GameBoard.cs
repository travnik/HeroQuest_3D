using Assets.Travnik.HeroQuest.Scripts.Map;
using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    public Transform FloorPrefab;
    public Transform WallPrefab;

    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        GameObject newPiece = Instantiate(piece, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        return newPiece;
    }

    public void RemovePiece(GameObject piece)
    {
        Destroy(piece);
    }

    public void MovePiece(GameObject piece, Vector2Int gridPoint)
    {
        piece.transform.position = Geometry.PointFromGrid(gridPoint);
    }

    public void SelectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = selectedMaterial;
    }

    public void DeselectPiece(GameObject piece)
    {
        MeshRenderer renderers = piece.GetComponentInChildren<MeshRenderer>();
        renderers.material = defaultMaterial;
    }

    public void DrawMap()
    {
        for (var y = 0; y < GameMap.MapHeight; y++)
        {
            for (var x = 0; x < GameMap.MapWidth; x++)
            {
                if (GameMap.map[x, y] != null)
                {
                    var transform = GetPrefab(GameMap.map[x, y]);
                    Instantiate(transform, GameMap.map[x, y].WorldPosition, Quaternion.identity);
                }
            }
        }
    }

    private Transform GetPrefab(MapNode mapNode)
    {
        switch (mapNode.Type)
        {
            case NodeType.Floor:
                return FloorPrefab;
            case NodeType.Wall:
                return WallPrefab;
            default:
                throw new NotImplementedException();
        }
    }
}

