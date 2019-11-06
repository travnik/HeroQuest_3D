using Assets.Travnik.HeroQuest.Scripts.Map;
using System;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    public GameObject FloorPrefab;
    public GameObject WallPrefab;

    public GameMap GameMap;

    public void Initialize()
    {
        GameMap = new GameMap();
        GameMap.Initialize();
        InitializeMapGameObject();
    }

    public GameObject AddPiece(GameObject piece, int col, int row)
    {
        Vector2Int gridPoint = Geometry.GridPoint(col, row);
        Debug.Log("grid point " + gridPoint);
        GameObject newPiece = Instantiate(piece, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
        newPiece.transform.localPosition = Geometry.PointFromGrid(gridPoint);
        Debug.Log("Geometry.PointFromGrid(gridPoint) " + Geometry.PointFromGrid(gridPoint));
        Debug.Log("gameObject.transform " + gameObject.transform);
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

    private void InitializeMapGameObject()
    {
        for (var y = 0; y < GameMap.MapHeight; y++)
        {
            for (var x = 0; x < GameMap.MapWidth; x++)
            {
                var mapElement = GameMap.map[x, y];
                if (mapElement != null)
                {
                    var prefab = GetPrefab(mapElement);
                    mapElement.GameObject = Instantiate(prefab, mapElement.WorldPosition, Quaternion.identity, gameObject.transform);
                }
            }
        }
    }

    private GameObject GetPrefab(MapNode mapNode)
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

