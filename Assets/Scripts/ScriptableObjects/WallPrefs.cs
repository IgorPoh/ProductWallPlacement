using UnityEngine;

namespace WallFitter
{
    [CreateAssetMenu]
    public class WallPrefs : SelectablePrefs
    {
        //size in meters
        [SerializeField]
        private float width;

        [SerializeField]
        private float height;

        //Position of the center of the wall in glodal coordinates
        [SerializeField]
        private Vector3 centralPoint;



        float Width { get { return width; } }
        float Height { get { return height; } }

        public Vector3 CentralPoint
        {
            get { return centralPoint; }
            set { centralPoint = value; }
        }


    }
}