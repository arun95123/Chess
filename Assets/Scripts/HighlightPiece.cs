using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightPiece : MonoBehaviour {

    public Material highlightMaterial;
    public Material normalMaterial;
    private bool isSelected;
    private string from;
    private string to;

    private Vector3 fromCoordinate;
    private Vector3 toCoordinate;

    public InputField start;
    public InputField end;

    private GameObject selectedPiece;

    public static string[] chessBoardNotation;
    public static double[] chessBoardCoordinatesx = new double[8] { -32, -23, -14, -5, 5, 14, 23, 32 };
    public static double[] chessBoardCoordinatesz = new double[8] { -32, -23, -14, -5, 5, 14, 23, 32 };
    public static string[] chessBoardNotationx = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };
    public static string[] chessBoardNotationz = new string[8] { "1", "2", "3", "4", "5", "6", "7", "8" };

    //Positions of the selected coins
    private double xPositions;
    private double zPositions;


    // Use this for initialization
    void Start() {
        isSelected = false;
    }

    // Update is called once per frame
    void Update() {

        from = start.text;
        to = end.text;
      
        if (!from.Equals(""))
        {
            //using notation to select the pieces
            fromCoordinate = notationToCoordinatesWithYZero(from);
            toCoordinate = notationToCoordinates(to);

            isSelected = true;
            //TO find the selectPiece from start coordinate
            RaycastHit hit;
            if(Physics.Raycast(fromCoordinate, Vector3.up, out hit,100f))
            {
                Debug.Log("Found an object - distance: " + hit.distance);
                // WHITE PAWN
                selectedPiece = hit.collider.transform.gameObject;
                if (selectedPiece.tag.Equals("WhitePawn"))
                {
                    if (isSelected)
                    {
                        
                        selectedPiece.GetComponent<Renderer>().material = highlightMaterial;

                        selectedPiece.GetComponent<PawnScript>().enabled = true;

                        if (selectedPiece.GetComponent<PawnScript>().isValidPawnMove)
                        {
                            selectedPiece.transform.position = toCoordinate;
                            start.text = "";
                            end.text = "";
                            selectedPiece.GetComponent<Renderer>().material = normalMaterial;
                            isSelected = false;
                            selectedPiece.gameObject.GetComponent<PawnScript>().isValidPawnMove = false;
                            selectedPiece.gameObject.GetComponent<PawnScript>().enabled = false;
                            fromCoordinate = new Vector3(0, 0, 0);
                        }
                    }
                }
            }
        }
        if (from.Equals(""))
        {
            if (!isSelected && selectedPiece!=null)
            {
                isSelected = false;              
                selectedPiece.gameObject.GetComponent<PawnScript>().enabled = false;
                selectedPiece.GetComponent<Renderer>().material = normalMaterial;
                isSelected = true;
            }

        }


    }

    //Helper methods

    public string coordinatesToNotation(double x , double z)
    {
        string notationAlpha = "";
        string notationNumba = "";

        for(int i = 0; i < 8; i++)
        {
            if (x == chessBoardCoordinatesx[i])
            {
                notationAlpha = chessBoardNotationx[i];
            }
            if (z == chessBoardCoordinatesz[i])
            {
                notationNumba = chessBoardNotationz[i];
            }
        }

        return notationAlpha+ notationNumba;
    }

    public Vector3 notationToCoordinates(string notation)
    {
        Vector3 coordinates = new Vector3(0, 0,0);

        if (!notation.Equals(""))
        {
            for (int i = 0; i < 8; i++)
            {
                if (notation.Substring(0, 1) == chessBoardNotationx[i])
                {
                    coordinates.x = (float)chessBoardCoordinatesx[i];
                }

                if (notation.Substring(1, 1) == chessBoardNotationz[i])
                {
                    coordinates.z = (float)chessBoardCoordinatesz[i];
                }
            }
        }

        coordinates.y = (float) 7.2;
        return coordinates;
    }

    public Vector3 notationToCoordinatesWithYZero(string notation)
    {
        Vector3 coordinates = new Vector3(0, 0, 0);

        if (!notation.Equals(""))
        {
            for (int i = 0; i < 8; i++)
            {
                if (notation.Substring(0, 1) == chessBoardNotationx[i])
                {
                    coordinates.x = (float)chessBoardCoordinatesx[i];
                }

                if (notation.Substring(1, 1) == chessBoardNotationz[i])
                {
                    coordinates.z = (float)chessBoardCoordinatesz[i];
                }
            }
        }
        
        coordinates.y = (float)0.0;
        return coordinates;
    }

}
