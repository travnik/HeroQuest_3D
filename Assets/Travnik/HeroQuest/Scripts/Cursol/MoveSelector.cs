using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class MoveSelector : MonoBehaviour
    {
        public GameObject moveLocationPrefab;
        public GameObject tileHighlightPrefab;
        public GameObject attackLocationPrefab;

        private GameObject tileHighlight;
        private GameObject movingPiece;
        private List<Vector2Int> moveLocations;
        private List<GameObject> locationHighlights;

        void Start()
        {
            this.enabled = false;
            tileHighlight = Instantiate(tileHighlightPrefab, Geometry.PointFromGrid(new Vector2Int(0, 0)),
                Quaternion.identity, gameObject.transform);
            tileHighlight.SetActive(false);
        }

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 point = hit.point;
                Vector2Int gridPoint = Geometry.GridFromPoint(point);

                tileHighlight.SetActive(true);
                tileHighlight.transform.position = Geometry.PointFromGrid(gridPoint);
                if (Input.GetMouseButtonDown(0))
                {
                    // Reference Point 2: check for valid move location
                    if (!moveLocations.Contains(gridPoint))
                    {
                        return;
                    }

                    if (GameManager.Instance.GetPlayerAtGrid(gridPoint) == null)
                    {
                        //GameManager.Instance.Move(movingPiece, gridPoint);
                    }
                    else
                    {
                        //GameManager.Instance.CapturePieceAt(gridPoint);
                        //GameManager.Instance.Move(movingPiece, gridPoint);
                    }
                    // Reference Point 3: capture enemy piece here later
                    ExitState();
                }
            }
            else
            {
                tileHighlight.SetActive(false);
            }
        }

        private void CancelMove()
        {
            this.enabled = false;

            foreach (GameObject highlight in locationHighlights)
            {
                Destroy(highlight);
            }

            //GameManager.Instance.DeselectPiece(movingPiece);
            TileSelector selector = GetComponent<TileSelector>();
            selector.EnterState();
        }

        public void EnterState(GameObject piece)
        {
            movingPiece = piece;
            this.enabled = true;

            //moveLocations = GameManager.Instance.MovesForPiece(movingPiece);
            locationHighlights = new List<GameObject>();

            if (moveLocations.Count == 0)
            {
                CancelMove();
            }

            foreach (Vector2Int loc in moveLocations)
            {
                GameObject highlight;
                if (GameManager.Instance.GetPlayerAtGrid(loc))
                {
                    highlight = Instantiate(attackLocationPrefab, Geometry.PointFromGrid(loc), Quaternion.identity, gameObject.transform);
                }
                else
                {
                    highlight = Instantiate(moveLocationPrefab, Geometry.PointFromGrid(loc), Quaternion.identity, gameObject.transform);
                }
                locationHighlights.Add(highlight);
            }
        }

        private void ExitState()
        {
            this.enabled = false;
            TileSelector selector = GetComponent<TileSelector>();
            tileHighlight.SetActive(false);
            //GameManager.Instance.DeselectPiece(movingPiece);
            movingPiece = null;
            //GameManager.Instance.NextPlayer();
            selector.EnterState();
            foreach (GameObject highlight in locationHighlights)
            {
                Destroy(highlight);
            }
        }
    }
}