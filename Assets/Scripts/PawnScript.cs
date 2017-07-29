using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnScript : MonoBehaviour {

    public bool isValidPawnMove;
    public GameObject Board;
    private GameObject enemyPiece;


	// Use this for initialization
	void Start () {
        isValidPawnMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("This script is attached to the object -----> " + gameObject.tag);
        Vector3 endCoordinate = Board.GetComponent<HighlightPiece>().notationToCoordinatesWithYZero(Board.GetComponent<HighlightPiece>().end.text);
        RaycastHit hit;
        if(Physics.Raycast(endCoordinate, Vector3.up, out hit, 100f))
        {
            enemyPiece = hit.collider.transform.gameObject;
        }

        if (gameObject.tag.Equals("WhitePawn"))
        {
            string tempFirstHalfFrom = Board.GetComponent<HighlightPiece>().start.text.Substring(0, 1);
            string tempFirstHalfTo = Board.GetComponent<HighlightPiece>().end.text.Substring(0, 1);
            string tempSecondHalfFrom = Board.GetComponent<HighlightPiece>().start.text.Substring(1, 1);
            string tempSecondHalfTo = Board.GetComponent<HighlightPiece>().end.text.Substring(1, 1);


            if (tempFirstHalfFrom.Equals(tempFirstHalfTo))
            {
                if(((int.Parse(tempSecondHalfTo) - int.Parse(tempSecondHalfFrom)) == 1) && enemyPiece==null)
                {
                    isValidPawnMove = true;
                }

                else if(((int.Parse(tempSecondHalfTo) - int.Parse(tempSecondHalfFrom)) == 2) && enemyPiece == null)
                {
                    if (tempSecondHalfFrom.Equals("2"))
                    {
                        isValidPawnMove = true;
                    }
                    else
                    {
                        isValidPawnMove = false;
                    }                   
                }
                else
                {
                    //Debug.Log("Invalid Move");
                }
            }
            else if((tempFirstHalfFrom.IndexOf(tempFirstHalfTo) == -1) && ((int.Parse(tempSecondHalfTo) - int.Parse(tempSecondHalfFrom)) == 1))
            {
                if (enemyPiece != null)
                {
                    isValidPawnMove = true;
                }
                else
                {
                    isValidPawnMove = false;
                }

            }
        }
	}
}
