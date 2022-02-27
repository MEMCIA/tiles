using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Life { get; protected set; } = 7; 
    public bool Win { get; protected set; } = false;
    public bool Dead { get; protected set; } = false;
    [SerializeField] Text text;
    public Vector3 PlayerPositionBeforeStart;
    [SerializeField] MainTilemap _mainTilemap;
    [SerializeField] Tilemap tilemap;
    CircleCollider2D cc;
    public Vector3 StartPlayerPos;
    [SerializeField] CollectableSymbols _collectableSymbols;

    private void Awake()
    {
        cc = GetComponent<CircleCollider2D>();
        PlayerPositionBeforeStart = transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {    
        SetStartPositionOfPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        LoseGame();
        WinGame();
    }

    void SetStartPositionOfPlayer()
    {
        float offsetF = cc.radius + 0.35f;
        Vector3 offsetV = new Vector3(0, offsetF, 0);
        Vector3 startPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(_mainTilemap.startXSpaceForPlayer, _mainTilemap.startYSpaceForPlayer, 0));
        Vector3 endPosOfPlayerSpace = tilemap.CellToWorld(new Vector3Int(_mainTilemap.endXSpaceForPlayer, _mainTilemap.endYSpaceForPlayer, 0));
        StartPlayerPos = endPosOfPlayerSpace - startPosOfPlayerSpace;
        StartPlayerPos = new Vector3(StartPlayerPos.x / 2, 0);
        StartPlayerPos = startPosOfPlayerSpace + StartPlayerPos + offsetV;
        transform.position = StartPlayerPos;
    }

    public void WinGame()
    {
        if (_collectableSymbols.SymbolsOfCollectable.Count != 0) return;
        if (Dead) return;
        text.color = Color.green;
        text.text = "W I N";
        Win = true;
    }
   
    void LoseGame()
    {
        if (Life <= 0)
        {
            if (Win) return;
            text.text = "G A M E   O V E R";
            Dead = true;
        }
    }

    public void TakeDamage()
    {
        Life--;
    }

}
