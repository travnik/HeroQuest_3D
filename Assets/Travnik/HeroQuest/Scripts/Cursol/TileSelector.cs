using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class TileSelector : MonoBehaviour
    {
        public GameObject tileHighlightPrefab;

        private GameObject _tileHighlight;

        void Start()
        {
            Vector2Int gridPoint = Geometry.GridPoint(0, 0);
            Vector3 point = Geometry.PointFromGrid(gridPoint);
            _tileHighlight = Instantiate(tileHighlightPrefab, point, Quaternion.identity, gameObject.transform);
            _tileHighlight.SetActive(false);
        }

        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector2Int gridPoint = Geometry.GridFromPoint(hit.point);

                _tileHighlight.SetActive(true);
                var vector3 = Geometry.PointFromGrid(gridPoint);
                vector3.y = 0.6f;
                _tileHighlight.transform.position = vector3;



                if (Input.GetMouseButtonDown(0))
                {
                    GameObject selectedPiece = GameManager.Instance.PieceAtGrid(gridPoint);
                    if (selectedPiece != null)
                    {
                        var playerScript = selectedPiece.AddComponent<PlayerCharacter>();
                        if (playerScript != null)
                        {
                            playerScript.Select();
                        }
                    }


                    Debug.Log("input mouse tileHighlight.transform.position" + _tileHighlight.transform.position);
                    //GameObject selectedPiece = GameManager.Instance.PieceAtGrid(gridPoint);
                    //if (GameManager.Instance.DoesPieceBelongToCurrentPlayer(selectedPiece))
                    //{
                    //    GameManager.Instance.SelectPiece(selectedPiece);
                    //    // Reference Point 1: add ExitState call here later
                    //    ExitState(selectedPiece);
                    //}
                }
            }
            else
            {
                _tileHighlight.SetActive(false);
            }
        }

        public void EnterState()
        {
            enabled = true;
        }

        private void ExitState(GameObject movingPiece)
        {
            this.enabled = false;
            _tileHighlight.SetActive(false);
            MoveSelector move = GetComponent<MoveSelector>();
            move.EnterState(movingPiece);
        }
    }
}