using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CataTombs.Battle
{
    public class PunchCancel : MonoBehaviour
    {
        private Animator _animator;
        private DamageBox[] _boxes;
        private int _punchCancelID;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxes = GetComponentsInChildren<DamageBox>();
            foreach (var box in _boxes)
                box.OnHitStart.AddListener(BreakPunch);
            _punchCancelID = Animator.StringToHash("PunchCanceled");
        }

        private void BreakPunch(Collider col)
        {
            if (col != null)
                _animator?.SetBool(_punchCancelID, true);
        }

        public void ResetCancel()
        {
            _animator?.SetBool(_punchCancelID, false);
        }
    }
}