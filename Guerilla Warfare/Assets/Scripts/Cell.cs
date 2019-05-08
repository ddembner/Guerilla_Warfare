﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{


    public Image mOutlineImage;
    public Vector2Int mBoardPosition = Vector2Int.zero;
    public Board mBoard = null;
    public RectTransform mRectTransform = null;
    public BasePiece mCurrentPiece = null;
    [SerializeField]
    protected PieceManager mPieceManager;

    public void Setup_Cell(Vector2Int newBoardPosition, Board newBoard, PieceManager pieceManager) {
        mBoard = newBoard;
        mBoardPosition = newBoardPosition;
        mRectTransform = GetComponent<RectTransform>();
        mPieceManager = pieceManager;
    }

    public void Place_Piece(GameObject newPiece) {
        mCurrentPiece = Instantiate(mCurrentPiece, transform);
        mCurrentPiece.GetComponent<RectTransform>().position = mRectTransform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData) {
        mOutlineImage.gameObject.SetActive(true);
        //Debug.Log(gameObject.name);
    }

    public void OnPointerExit(PointerEventData eventData) {
        mOutlineImage.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) {

        if(mCurrentPiece != null) {
            Debug.Log("This cell already contains a piece");
            return;
        }

        if (mBoardPosition.y < 4) {
            mPieceManager.Place_Piece(this, Color.blue, new Color32(0, 0, 255, 255), mPieceManager);
        } else if(mBoardPosition.y > 7) {
            mPieceManager.Place_Piece(this, Color.red, new Color32(255, 0, 0, 255), mPieceManager);
        }

    }
}
