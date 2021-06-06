
using UnityEngine;
using System.Collections;

public class TexturePainter : MonoBehaviour
{
    public GameObject brushCursor, brushContainer;
    public Camera sceneCamera, canvasCam;
    public Sprite cursorPaint;
    public RenderTexture canvasTexture;
    public Material baseMaterial;
    public float brushSize = 1.4f;
    public GameObject brush;
    public Color brushColor;
    int brushCounter = 0;
    const int MAX_BRUSH_COUNT = 1000;
    private void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0)) // start clean detected
        {
            CleanPoint();
        }
        MoveCleaningObject();
    }

    private Vector3 uvWorldPosition = Vector3.zero;
    void CleanPoint()
    {

        // cleaned objects renders a UvMap so returning uvworlPosition  and instantiating the brush at suitable position
        if (HitTestUVPosition(ref uvWorldPosition))
        {
            GameObject brushObj;
            brushObj = (GameObject)Instantiate(brush); // instantiates cleaner brush
            brushObj.GetComponent<SpriteRenderer>().color = brushColor; //Set the brush color

            brushColor.a = brushSize * 2.0f; // sets brush alpha
            brushObj.transform.parent = brushContainer.transform; // add brush in to brushcontainer
            brushObj.transform.localPosition = uvWorldPosition; //brush position in uvmap
            brushObj.transform.localScale = Vector3.one * brushSize;//The size of the brush
        }
        brushCounter++; //Add to the max brushes
        if (brushCounter >= MAX_BRUSH_COUNT)
        { 
            // brush max size reached so stop cleaning
            brushCursor.SetActive(false);


        }
    }
    // painting cursor position
    void MoveCleaningObject()
    {
        Vector3 uvWorldPosition = Vector3.zero;
        if (HitTestUVPosition(ref uvWorldPosition))
        {
            brushCursor.SetActive(true);
            brushCursor.transform.position = uvWorldPosition + brushContainer.transform.position;
        }
        else
        {
             // no point to hit
            brushCursor.SetActive(false);
        }
    }
    //Returns the position on the texuremap according to a hit in the mesh collider
    RaycastHit hit;
    Ray cursorRay;
    bool HitTestUVPosition(ref Vector3 uvWorldPosition)
    {
        
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
        cursorRay = sceneCamera.ScreenPointToRay(cursorPos);
        if (Physics.Raycast(cursorRay, out hit, 200))
        {
            MeshCollider meshCollider = hit.collider as MeshCollider;
            if (meshCollider == null || meshCollider.sharedMesh == null)
                return false;
            Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
            //  sets the position on uvworldposition;
            uvWorldPosition.x = pixelUV.x - canvasCam.orthographicSize;//To center the UV on X
            uvWorldPosition.y = pixelUV.y - canvasCam.orthographicSize;//To center the UV on Y
            uvWorldPosition.z = 0.0f;
            return true;
        }
        else
        {
            return false;
        }

    }


}
