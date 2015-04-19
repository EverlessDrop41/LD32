using UnityEngine;

public class SpeechGun : MonoBehaviour {

	public string Message;

	public GameObject TextMeshObject;

	void Update() {
        if (Input.GetButtonDown("Fire") && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GameObject text = Instantiate(TextMeshObject, transform.position, Quaternion.identity) as GameObject; //Create the text

            TextMesh textMesh = text.GetComponent<TextMesh>(); //Get the text mesh

            if (textMesh != null)
            {
                textMesh.text = Message; //Set the text message
            }

            BoxCollider2D coll = text.GetComponent<BoxCollider2D>();
            Renderer rend = text.GetComponent<Renderer>();
            coll.size = new Vector2(rend.bounds.size.x * 4f, rend.bounds.size.y) ;//Size the collider on the box

            text.transform.rotation = transform.rotation; //Rotate the text to the players rotation
            text.transform.Rotate(new Vector3(0, 0, 90)); //Add a rotation offset
		}
	}

    public void UpdateMessage(string Text)
    {
        Message = Text;
    }
}
