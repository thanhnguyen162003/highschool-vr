using UnityEngine;

public class HeadFollow : MonoBehaviour
{
	[SerializeField] private Vector3 offset;
	[SerializeField] private float smoothAmount = 1;

	private Transform head;
	private bool isPaused = false;

    void Start()
    {
        head = Camera.main.transform;
        UpdateTransform();
    }

    private void OnEnable()
	{
		head = Camera.main.transform;
		UpdateTransform();
	}

	void Update()
	{
		if (!isPaused) UpdateTransform();
	}

	private void UpdateTransform()
	{
        //Vector3 targetPos = head.TransformPoint(offset);
        //Quaternion targetRot = Quaternion.Euler(new Vector3(30, head.eulerAngles.y, 0));

        //transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothAmount);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothAmount);
        if (head == null) return; // Check if the head is assigned

        Vector3 targetPos = head.TransformPoint(offset);
        Quaternion targetRot = head.rotation; // Directly use the camera's rotation

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * smoothAmount);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * smoothAmount);
    }

	public void Pause() => isPaused = true;

	public void Resume() => isPaused = false;

	public void DestroyScript() => Destroy(this);
}