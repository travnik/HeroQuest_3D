using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class GameCursor : MonoBehaviour
    {
        //public Texture2D cursorNormal;
        //public Texture2D cursorEnemy;
        //public Texture2D cursorInfo;
        //public int size = 30; // размер курсора по ширине и высоте
        //private Vector2 offset;
        //private Texture2D cursor;

        public Texture2D cursorTexture;
        public CursorMode cursorMode = CursorMode.Auto;
        public Vector2 hotSpot = Vector2.zero;

        void OnMouseEnter()
        {
            Debug.Log("mouse on" + hotSpot);
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }

        void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }

        void Awake()
        {
            //Cursor.visible = false; // скрываем системный курсор
            //Camera.main.orthographic = true; // для RaycastHit2D, камера должна быть в ортогональном режиме
        }

        //void MainCursor(string tags)
        //{
        //    if (tags == "Enemy" || tags == "Target")
        //    {
        //        offset = new Vector2(-size / 2, -size / 2); // смещение к центру
        //        cursor = cursorEnemy;
        //    }
        //    else if (tags == "Info")
        //    {
        //        offset = new Vector2(-size / 2, -size / 1.2f);
        //        cursor = cursorInfo;
        //    }
        //    else // курсор по умолчанию
        //    {
        //        offset = Vector2.zero;
        //        cursor = cursorNormal;
        //    }
        //}

        //void Update()
        //{
        //    //RaycastHit hit;
        //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    Debug.Log("mouse on" + Input.mousePosition);

        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        //    //if (hit.transform != null)
        //    //{
        //    //    Debug.Log("mouse on" + Input.mousePosition);
        //    //    //MainCursor(hit.transform.tag);

        //    //}

        //    //RaycastHit hit;
        //    //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    //if (Physics.Raycast(ray, out hit))
        //    //{
        //    //    //MainCursor(hit.transform.tag);
        //    //}
        //    //else // если луч никуда не попадет
        //    //{
        //    //    offset = Vector2.zero;
        //    //    //cursor = cursorNormal;
        //    //}
        //}

        //private void Update()
        //{
        //    //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (!Physics.Raycast(ray, out hit))
        //    {
        //        return;
        //    }

        //    var vector = new Vector3(hit.point.x, 0, hit.point.z);
        //    mousePosition = hit.point;
        //    Distance = Vector3.Distance(vector, setTargetOn.transform.position);
        //    if (Distance > 1)
        //    {
        //        TargetImage.SetActive(false);
        //        return;
        //    }

        //    TargetImage.SetActive(true);
        //    TargetImage.transform.position = new Vector3(hit.point.x, 0.75f, hit.point.z);// + hit.normal * surfaceOffset);

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        //if (setTargetOn != null)
        //        //{
        //        //    setTargetOn.SendMessage("SetTarget", transform);
        //        //}
        //    }

        //}

        //void OnGUI()
        //{
        //    Vector2 mousePos = Event.current.mousePosition;
        //    GUI.depth = 999; // поверх остальных элементов
        //    GUI.Label(new Rect(mousePos.x + offset.x, mousePos.y + offset.y, size, size), cursor);
        //}
    }
}