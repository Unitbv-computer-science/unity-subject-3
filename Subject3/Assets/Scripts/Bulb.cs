using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Bulb : MonoBehaviour
    {
        #region Private Fields
        // Variabilă ce reține dacă becul este aprins sau stins.
        private bool _isOn;

        // Becurile vecine.
        private List<Bulb> _neighbours;

        // Materialul becului, obținut din _MeshRenderer.
        private Material _material;

        // Componenta animator a becului.
        private Animator _animator;

        // Componenta BoxCollider a becului.
        private BoxCollider _boxCollider;
        #endregion


        #region Serialized Fields
        // Componenta MeshRenderer, obținută din obiectul Glass, obiect copil al becului.
        [SerializeField] private MeshRenderer _MeshRenderer;
        #endregion


        #region Properties
        // Proprietate ce returnează câmpul _isOn.
        public bool IsOn => _isOn;
        #endregion


        #region Methods
        // Metodă folosită la inițializarea membrilor clasei.
        private void Awake()
        {
            _material = _MeshRenderer.material;
            _animator = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider>();
        }

        // Setează becurile vecine.
        public void SetNeighbours(List<Bulb> neighbours)
        {
            _neighbours = neighbours;
        }

        // Aprinde becul dacă acesta este stins și viceversa.
        // În funcție de parametrul shouldSwitchNeighbours, apelează sau nu metoda Switch și pentru vecini.
        public void Switch(bool shouldSwitchNeighbours)
        {
            UpdateMaterialDirectly();
            _isOn = !_isOn;

            if (shouldSwitchNeighbours)
            {
                foreach (Bulb bulb in _neighbours)
                {
                    bulb.Switch(false);
                }
            }
        }

        // Schimbă direct culoarea materialului pentru a marca stingerea/aprinderea becului.
        private void UpdateMaterialDirectly()
        {
            if (_isOn)
            {
                _material.color = Color.white;
            }
            else
            {
                _material.color = Color.green;
            }
        }

        // Schimbă materialul prin animație pentru a marca stingerea/aprinderea becului.
        private void UpdateMaterialThroughAnimation()
        {
            // Exercițiul 3B.
        }

        // Stinge becul.
        public void TurnOff()
        {
            if (_isOn)
            {
                Switch(false);
            }
        }

        // Aprinde becul.
        public void TurnOn()
        {
            if (!_isOn)
            {
                Switch(false);
            }
        }

        // Dezactivează componenta collider.
        public void DisableCollider()
        {
            _boxCollider.enabled = false;
        }
        #endregion
    }
}
