using UnityEngine;

namespace Diwide.Ziggurat
{
    public class UnitSelector : MonoBehaviour
    {
        [SerializeField] private GameObject selectionCircle;

        public void SelectUnit()
        {
            selectionCircle.SetActive(true);
        }

        public void DeselectUnit()
        {
            selectionCircle.SetActive(false);
        }
    }
}