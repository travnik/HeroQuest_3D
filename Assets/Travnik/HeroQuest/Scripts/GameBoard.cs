using System;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class GameBoard : MonoBehaviour
    {
        public Material defaultMaterial;
        public Material selectedMaterial;

        public GameObject FloorPrefab;
        public GameObject WallPrefab;

        public GameObject PlayerPrefab;

        public GameMap GameMap;
        //public List<GameObject> Characters;

        public void Initialize()
        {
            //Characters = new List<GameObject>();
            GameMap = new GameMap();
            GameMap.Initialize();
            InitializeMapGameObject();

            AddCharacter(PlayerPrefab, 2, 2);
            AddPiece(PlayerPrefab, 1, 5);
        }

        public GameObject AddCharacter(GameObject prefab, int col, int row)
        {
            Vector2Int gridPoint = Geometry.GridPoint(col, row);
            GameObject character = Instantiate(prefab, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
            character.transform.localPosition = Geometry.PointFromGrid(gridPoint);
            //Characters.Add(character);
            return character;
        }

        public GameObject AddPiece(GameObject prefab, int col, int row)
        {
            Vector2Int gridPoint = Geometry.GridPoint(col, row);
            GameObject newPiece = Instantiate(prefab, Geometry.PointFromGrid(gridPoint), Quaternion.identity, gameObject.transform);
            newPiece.transform.localPosition = Geometry.PointFromGrid(gridPoint);
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
}