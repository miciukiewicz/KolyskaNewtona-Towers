using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCircle : MonoBehaviour {
    Rigidbody2D rigidbody;
    Vector3 offset;
    Vector3 mousePosition;
    bool isDragging;

    private void OnMouseDown() {
        isDragging = true;
    }

    private void OnMouseUp() {
        isDragging = false;
    }


    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(isDragging) {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if(targetObject) {
                offset = rigidbody.transform.position - mousePosition;
            }
        }
    }

    void FixedUpdate() {
        if(isDragging) {
            rigidbody.MovePosition(mousePosition + offset);
        }
    }
}
