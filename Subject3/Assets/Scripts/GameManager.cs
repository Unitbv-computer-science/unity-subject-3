using Assets.Scripts;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Private Fields
    // Camera principală din scenă
    private Camera _camera;

    // Componenta folosită pentru redarea sunetelor în joc.
    private AudioSource _audioSource;

    // Variabilă folosită pentru stocarea becurilor în format matrice.
    private List<List<Bulb>> _bulbsMatrix;
    #endregion


    #region Serialized Fields
    // Becurile stocate în format listă.
    [SerializeField] private List<Bulb> _BulbsList;

    // Sunetul redat la apăsarea unui bec.
    [SerializeField] private AudioClip _SwitchSound;

    // Caseta de text vizibilă la finalizarea unui joc.
    [SerializeField] private TextMeshProUGUI _TextBox;
    #endregion


    #region Methods
    // Metodă folosită la inițializarea membrilor clasei.
    private void Start()
    {
        _camera = Camera.main;
        _audioSource = GetComponent<AudioSource>();
        InitializeBulbArray();
        InitializeBulbNeighbours();
        InitializeGameConfiguration();
    }

    // Metodă folosită pentru plasarea becurilor din _BulbsList în _bulbsMatrix.
    private void InitializeBulbArray()
    {
        _bulbsMatrix = new List<List<Bulb>>();
        int squareRoot = (int)Mathf.Sqrt(_BulbsList.Count);
        for (int index1 = 0; index1 < squareRoot; ++index1)
        {
            _bulbsMatrix.Add(new List<Bulb>());
            for (int index2 = 0; index2 < squareRoot; ++index2)
            {
                _bulbsMatrix[index1].Add(_BulbsList[index1 * squareRoot + index2]);
            }
        }
    }

    // Metodă folosită pentru setarea vecinilor fiecărui bec.
    private void InitializeBulbNeighbours()
    {
        for (int index1 = 0; index1 < _bulbsMatrix.Count; ++index1)
        {
            for (int index2 = 0; index2 < _bulbsMatrix[index1].Count; ++index2)
            {
                // Exercițiul 1B.
            }
        }
    }

    // Metodă folosită pentru a aprinde becuri la întâmplare, la începutul unui joc.
    private void InitializeGameConfiguration()
    {
        foreach (List<Bulb> bulbRows in _bulbsMatrix)
        {
            foreach (Bulb bulb in bulbRows)
            {
                // Exercițiul 1C
            }
        }
    }

    // Metodă apelată la fiecare frame.
    // Folosită pentru a înregistra click stânga de la mouse.
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FindBulb();
        }
    }

    // Verifică dacă mouseul se află peste un bec, și ia acțiunile necesare.
    private void FindBulb()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);
        Collider collider = hitInfo.collider;
        if (collider != null)
        {
            Bulb bulb = collider.GetComponent<Bulb>();
            if (bulb != null)
            {
                // Exercițiul 2C
            }
        }
    }

    // Verifică dacă toate becurile sunt stinse, și ia acțiunile necesare.
    private void CheckWinCondition()
    {
        // Exercițiul 2B
    }

    // Dezactivează componentele collider pentru toate becurile.
    private void DisableBulbColliders()
    {
        foreach (List<Bulb> bulbRows in _bulbsMatrix)
        {
            foreach (Bulb bulb in bulbRows)
            {
                bulb.DisableCollider();
            }
        }
    }

    // Face vizibil mesajul de victorie.
    private void EnableWinMessage()
    {
        _TextBox.gameObject.SetActive(true);
    }

    // Redă clipu audio primit ca parametru.
    private void PlayAudioClip(AudioClip audioClip)
    {
        // Exercițiul 2A
    }

    // Resetează scena curentă.
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Lasă aprins doar primul bec și vecinii săi,
    // astfel încât prin apăsarea primului bec, să se termine jocul.
    public void AutoSolve()
    {
        for (int index1 = 0; index1 < _bulbsMatrix.Count; ++index1)
        {
            for (int index2 = 0; index2 < _bulbsMatrix[index1].Count; ++index2)
            {
                if ((index1 == 0 && index2 == 0) || (index1 == 0 && index2 == 1) || (index1 == 1 && index2 == 0))
                {
                    _bulbsMatrix[index1][index2].TurnOn();
                } else
                {
                    _bulbsMatrix[index1][index2].TurnOff();
                }
            }
        }
    }
    #endregion
}
