using UnityEngine;

namespace SortItems
{
    public class Getter : MonoBehaviour
    {
        private GameObject _obj;

        private void OnTriggerStay(Collider other) 
        {
            var item = other.attachedRigidbody.GetComponent<DragItem>();

            if (item != null && item.isDraggable == true)
            {
                _obj = item.gameObject;
                return;
            }

            if (item.isDraggable == false && _obj == item.gameObject)
            {
                Destroy(_obj);
                _obj = null;

                return;
            }
        }
    }
}
