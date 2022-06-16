//2018.3.0f2

//moving
public float speed;

void Update()
{
	//Input class used for anything dealing with wanting to read a users input on a key
	bool isPressingRight = Input.GetKey(KeyCode.RightArrow);
	bool isJumping = Input.GetKey(KeyCode.Space);
	//move on a input from user
	if (isPressingRight)
	{
		//vector3 used for anything with movement
		Vector3 currentPosition = this.gameObject.transform.position;
		Vector3 newPosition = currentPosition + Vector3.right * speed;
		this.gameObject.transform.position = newPosition;
	}

	//jumping
	if(isJumping)
	{
		//Can also Rigidbody2D thisRigidbody = this.gameObject.GetComponent<Rigidbody2D>();
		//Vector3 currentVelocity = thisRigidbody.velocity()
		//Vector3 newVelocity = currentVelocity + Vector3D.up * jumpSpeed;
		Vector3 currentVelocity = this.gameobject.GetComponent<Rigifbody2D>().velocity;
		Vector newVelocity = currentVelocity + Vector3.up * jumpSpeed;
		this.gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
	}
	
}

void FixedUpdate()
{
	//doesn't play well with input class, input class should only be used with update
	//print(Time.fixedDeltaTime);	//print console time (s) between physics engine
}

/*
//to get around input not working well with FixedUpdate
private MovingDirection currentDirection;
private enum MovingDirection { Left, Right, Neither};
void Start()
{
	currentDirection = MovingDirection.Neither;
}
//switch on MovingDirecstion variable in Fixed Update 
//moving logic is move....
//pass information from update to fixed update 
*/

/*
Make something you create show up in inpsector
*declare public Myclass object at top of script too
[System.Serializable]
public class MyClass
{
	public int number;
	public string name;
}
*/

//null reference exception: you have pointer that isn't pointing to anything
//Solve: make public and assign in inspector or ex. myFloats = new List<float>();

//member extraction
public Transform otherTransform;
can drag ground to it in inspector and it extracts its transform or click on the dot and it will pull up avail options

//getting input
Input class

//getting data
public GameObject otherGameObject; 	//reference to object 
otherGameObject = GameObject.Find or gameObject.transform.FindChild

Rigidbody otherRB = null;
otherRB = otherGameObject.GetComponent<Rigidbody>();	//template function gets what's in <>, function so that it can return null if nothing to return 
Transform otherTransform = otherGameObject.transform; 	//written this way cause transform is guaranteed to be there 
/*
foreach(var nearObject)
{
	if (nearObject.GetComponent<Interactable>()) 	//attach interactable script, null in if is same as false
	//optimization feature
*/
//
var gameManager = GameObject.FindObject, FindObjectOfType 
//var lets you define variables without taking up a lot of space, auto fills type to reference

//create prefab
public GameObject myPrefab;
if(Input.GetKeyDown(KeyCode.I))
var myNewGo gameObject.Instantiate(myPrefab) //create prefab, .destroy
myNewGO.transform.position = Vector3.zero 	//vector3.zero so it doesn't end up in some random place
//then fill in from inspector

//collision detection 
private bool canJump;
canJump = true;

if (isJumping && canJump)
	//set canJump to false 
//then in collision detection function 
void OnCollisionEnter2D(Collision2D col)
{
	//fires when 2d engine detects collision
	if(col.collider.gameObject.name.Equals("Ground")	//whatever your "ground" is name, can replace name with tag and tag object with whatever name you want/need
	{
		this.canJump = true;
	}
}
//