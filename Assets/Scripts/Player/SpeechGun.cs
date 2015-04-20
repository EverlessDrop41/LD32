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
            MeshRenderer rend = text.GetComponent<MeshRenderer>();
            coll.size = new Vector2(rend.bounds.size.x / 0.155f, rend.bounds.size.y / 0.155f) ;//Size the collider on the box
            coll.offset = new Vector2((rend.bounds.size.x / 0.155f )/ 2f, 0);

            text.transform.rotation = transform.rotation; //Rotate the text to the players rotation
            text.transform.Rotate(new Vector3(0, 0, 90)); //Add a rotation offset
		}
	}

    public void UpdateMessage(string Text)
    {
        Message = Text;
    }
}
