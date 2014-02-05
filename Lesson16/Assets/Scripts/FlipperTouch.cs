using UnityEngine;
using System.Collections;

public class FlipperTouch: MonoBehaviour {
	
	public float touchRectX;
	public float touchRectY;
	public float touchRectW;
	public float touchRectH;
	

	private Flipper flipper;
	private Rect touchArea;
	private bool touching;
	private int touchId = -1;
	
	void Start() {
		
		if (Application.platform == RuntimePlatform.IPhonePlayer
			|| Application.platform == RuntimePlatform.Android ) {
			
			// smart phone
			this.enabled = true;
			
			flipper = GetComponent<Flipper>();
			
			float left = Screen.width * touchRectX;
			float top = Screen.height * touchRectY;
			float width = Screen.width * touchRectW;
			float height = Screen.height * touchRectH;
			touchArea = new Rect(left, top, width, height);
			
		} else {
			
			// other
			this.enabled = false;
		}
		
	}
		
	void Update() {
		
		int count = Input.touchCount;
	
		if ( count == 0 ) {
			touching = false;
			touchId = -1;
		} else {
			for(int i = 0;i < count; i++) {
				Touch touch = Input.GetTouch(i);
				
				if (touchArea.Contains(touch.position)
					&& (touchId == -1 || touchId != touch.fingerId)) {
	
					touchId = touch.fingerId;
					
				}
		
				if ( touchId == touch.fingerId ) {
					
					if ( touch.phase == TouchPhase.Ended 
						|| touch.phase == TouchPhase.Canceled ) {
						
						touching = false;				
						touchId = -1;		
					} else {
						touching = true;
					}
				}			
			}
		}
		
		if (touching) {
			flipper.FlipperUp();
		} else {
			flipper.FlipperDown();
		}
	}
	

}
