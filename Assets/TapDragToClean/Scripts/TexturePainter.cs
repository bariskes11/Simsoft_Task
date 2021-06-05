
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
	int brushCounter = 0, MAX_BRUSH_COUNT = 1000; 
    private void Start()
    {
		
	}

    void Update()
	{
		if (Input.GetMouseButton(0))
		{
			CleanPoint();
		}
		MoveCleaningObject();
	}

	void CleanPoint()
	{
		
		Vector3 uvWorldPosition = Vector3.zero;
		if (HitTestUVPosition(ref uvWorldPosition))
		{
			GameObject brushObj;
		

				brushObj = (GameObject)Instantiate(brush); //Paint a brush
				brushObj.GetComponent<SpriteRenderer>().color = brushColor; //Set the brush color
			
			brushColor.a = brushSize * 2.0f; // Brushes have alpha to have a merging effect when painted over.
			brushObj.transform.parent = brushContainer.transform; //Add the brush to our container to be wiped later
			brushObj.transform.localPosition = uvWorldPosition; //The position of the brush (in the UVMap)
			brushObj.transform.localScale = Vector3.one * brushSize;//The size of the brush
		}
		brushCounter++; //Add to the max brushes
		if (brushCounter >= MAX_BRUSH_COUNT)
		{ //If we reach the max brushes available, flatten the texture and clear the brushes
			brushCursor.SetActive(false);
			

		}
	}
	//To update at realtime the painting cursor on the mesh
	void MoveCleaningObject()
	{
		Vector3 uvWorldPosition = Vector3.zero;
		if (HitTestUVPosition(ref uvWorldPosition) )
		{
			brushCursor.SetActive(true);
			brushCursor.transform.position = uvWorldPosition + brushContainer.transform.position;
		}
		else
		{
			brushCursor.SetActive(false);
		}
	}
	//Returns the position on the texuremap according to a hit in the mesh collider
	bool HitTestUVPosition(ref Vector3 uvWorldPosition)
	{
		RaycastHit hit;
		Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
		Ray cursorRay = sceneCamera.ScreenPointToRay(cursorPos);
		if (Physics.Raycast(cursorRay, out hit, 200))
		{
			MeshCollider meshCollider = hit.collider as MeshCollider;
			if (meshCollider == null || meshCollider.sharedMesh == null)
				return false;
			Vector2 pixelUV = new Vector2(hit.textureCoord.x, hit.textureCoord.y);
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
