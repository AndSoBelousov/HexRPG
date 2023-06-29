using System;
using UnityEngine;
using UnityEngine.UI;

namespace HEXRPG.GUI
{
    public class UIBloodScroll : MonoBehaviour
    {
        [SerializeField] private float _verticalSpeed;
        [SerializeField] private float _horizontalSpeed;
        private RawImage _myRawImage;

        void Start()
        {
            _myRawImage = GetComponent<RawImage>();
        }

        // Update is called once per frame
        void Update()
        {
            Rect currentUV = _myRawImage.uvRect;
            currentUV.x -= Time.deltaTime * _horizontalSpeed;
            currentUV.y -= Time.deltaTime * _verticalSpeed;

            if (currentUV.x <= -1f || currentUV.x >= 1f)
                currentUV.x = 0f;

            if (currentUV.y <= -1f || currentUV.y >= 1f)
                currentUV.y = 0f;

            _myRawImage.uvRect = currentUV;
        }
    }
}