using UnityEngine;

namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        [SerializeField] private ItemType type;


        private DragItem _item;
        private Material _material;
        private Color _defaultColor;


        private void Start() 
        {
            _material = GetComponent<MeshRenderer>().material;
            _defaultColor = _material.color;
        }

        private void OnTriggerStay(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (item != null && item.isDraggable == true)
            {
                _item = item;
                
                if (_item.Type == type)
                {
                    _material.color = Color.green;
                }
                else
                {
                    _material.color = Color.red;
                }

                return;
            }

            if (item.isDraggable == false && _item == item)
            {
                TryGetItem();
                _item = null;
                _material.color = _defaultColor;

                return;
            }
        }

        private void OnTriggerExit(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();
            
            if (_item == item)
            {
                if (item.isDraggable == false)
                    TryGetItem();

                _item = null;
                _material.color = _defaultColor;
            }
        }

        private void TryGetItem()
        {
            if (_item.Type ==type)
                Destroy(_item.gameObject);
        }
    }
}
