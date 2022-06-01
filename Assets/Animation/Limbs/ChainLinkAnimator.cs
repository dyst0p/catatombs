using DG.Tweening;
using UnityEngine;

namespace CataTombs.Limbs
{
    public class ChainLinkAnimator : MonoBehaviour
    {
        [SerializeField] Vector3 finalRotation;
        [SerializeField] float duration;

        // Start is called before the first frame update
        void Start()
        {
            DoAnimation();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoAnimation()
        {
            transform.DOLocalRotate(finalRotation, duration, RotateMode.LocalAxisAdd);
        }
    }
}