using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Travnik.HeroQuest
{
    public class PlayerCharacter : MovingObject
    {
        private Outline _outline;
        private bool _isSelect;

        void Start()
        {
            _outline = GetComponent<Outline>();
            GameManager.Instance.AddPlayerToList(this);
        }

        public void Select()
        {
            if (!_isSelect)
            {
                _outline.OutlineMode = Outline.Mode.OutlineAll;
                _isSelect = true;
            }
        }

        public void UnSelect()
        {
            if (_isSelect)
            {
                _isSelect = false;
                _outline.OutlineMode = Outline.Mode.Disable;
            }
        }
    }
}