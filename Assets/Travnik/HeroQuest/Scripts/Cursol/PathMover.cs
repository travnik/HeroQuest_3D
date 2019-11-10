using System.Collections;
using System.Collections.Generic;
using Travnik.HeroQuest;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public static PathMover Instance;

    public GameObject TileMovePrefab;
    private List<GameObject> _pathTiles = new List<GameObject>();

    void Awake()
    {
        Instance = this;
    }

    public void FillMovesNode()
    {
        foreach (var node in GameManager.Instance.GameBoard.GameMap.Map)
        {
            if (node != null && PathFinder.IsMove(node))
            {
                _pathTiles.Add(AddPath(node));
            }
        }
    }

    private GameObject AddPath(MapNode node)
    {
        Vector3 point = new Vector3(node.WorldPosition.x, 0.6f, node.WorldPosition.z);
        GameObject newPiece = Instantiate(TileMovePrefab, point, Quaternion.identity, gameObject.transform);
        return newPiece;
    }

    public void ClearMovesNode()
    {
        foreach(var path in _pathTiles)
        {
            Destroy(path);
        }
        _pathTiles.Clear();
    }
}
