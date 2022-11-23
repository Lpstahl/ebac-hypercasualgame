using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    public Transform container;
    public List<GameObject> levels;

    public List<LevelPieceBaseSetup> levelPieceBaseSetups;
   
    public float timeBetweenPIeces = .3f;

    [SerializeField] private int _index;
    private GameObject _currentLevel;

    [SerializeField] private List<LevelPieceBase> _spawnedPieces = new List<LevelPieceBase>();
    private LevelPieceBaseSetup _currSetup;

    [Header("Animation")]
    public float scaleDuration = .2f;
    public float scaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        //SpawnNextLevel();
        CreateLevelPieces();
    }

    private void SpawnNextLevel()
    {
        if(_currentLevel != null)
        {
            Destroy(_currentLevel);
            _index++;

            if(_index >= levels.Count)
            {
                ResetLevelIndex();
            }
        }

        _currentLevel = Instantiate(levels[_index], container);
        _currentLevel.transform.localPosition = Vector3.zero;
    
    }

    private void ResetLevelIndex()
    {
        _index = 0;
    }
    #region
    private void CreateLevelPieces()
    {
        CleanSpawnedPices();

        _currSetup = levelPieceBaseSetups[Random.Range(0, levelPieceBaseSetups.Count)];

        if (_currSetup != null)
        {
            _index++;

            if (_index >= levelPieceBaseSetups.Count)
            {
                ResetLevelIndex();
            }
        }

        for (int i = 0; i < _currSetup.pieceNumberStart; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesStart);
        }        
        
        for (int i = 0; i < _currSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
        }

        for (int i = 0; i < _currSetup.pieceNumberEnd; i++)
        {
            CreateLevelPiece(_currSetup.levelPiecesEnd);
        }

        ColorManager.instance.ChangeColorByType(_currSetup.artType);
        StartCoroutine(ScalePiecesByTime());
        
    }

    IEnumerator ScalePiecesByTime()
    {
        foreach(var p in _spawnedPieces)
        {
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for(int i = 0; i < _spawnedPieces.Count; i++) 
        {
            _spawnedPieces[i].transform.DOScale(1, scaleDuration).SetEase(ease);
            yield return new WaitForSeconds(scaleTimeBetweenPieces);
        }
        CoinsAnimatorManager.instance.StartAnimations();
    }

    private void CreateLevelPiece(List<LevelPieceBase> list)
    {
        var piece = list[Random.Range(0, list.Count)];
        var spawnedPiece = Instantiate(piece, container);

        if(_spawnedPieces.Count > 0)
        {
            var lastPiece = _spawnedPieces[_spawnedPieces.Count - 1];

            spawnedPiece.transform.position = lastPiece.endPiece.position;
        }
        else
        {
            spawnedPiece.transform.localPosition = Vector3.zero;
        }

        foreach(var p in spawnedPiece.GetComponentsInChildren<ArtPiece>())
        {
            p.ChangePiece(ArtManager.instance.GetSetupByType(_currSetup.artType).gameObject);
        }

        
            _spawnedPieces.Add(spawnedPiece);
    }

    private void CleanSpawnedPices()
    {
        for(int i = _spawnedPieces.Count - 1; i >= 0; i--)
        {
            Destroy(_spawnedPieces[i].gameObject);
        }

        _spawnedPieces.Clear();
    }

    IEnumerator CreateLevelPiecesCoroutine()
    {
        _spawnedPieces = new List<LevelPieceBase>();

        for (int i = 0; i < _currSetup.pieceNumber; i++)
        {
            CreateLevelPiece(_currSetup.levelPieces);
            yield return new WaitForSeconds(timeBetweenPIeces);
        }
    }
    #endregion
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            CreateLevelPieces();
        }
    }
}

