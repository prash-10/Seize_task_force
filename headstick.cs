using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class headstick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
	private Image bgimg;
	private Image joystickImg;
	public Vector3 InputDirection{set;get;}
	
	private void Start()
	{
	  bgimg=GetComponent<Image>();
      joystickImg=transform.GetChild(0).GetComponent<Image>();	 
      InputDirection = Vector3.zero;	  
	}
	
    public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgimg.rectTransform,ped.position,ped.pressEventCamera,out pos))
		{
			pos.x=(pos.x/bgimg.rectTransform.sizeDelta.x);
		pos.y=(pos.y/bgimg.rectTransform.sizeDelta.y);
		float x=(bgimg.rectTransform.pivot.x == 1) ? pos.x*2+1 : pos.x*2-1;
		float y =(bgimg.rectTransform.pivot.y == 1) ? pos.y*2+1 : pos.y*2-1;
		InputDirection = new Vector3 (x,0,y);
		InputDirection = (InputDirection.magnitude>1)?InputDirection.normalized:InputDirection;
		joystickImg.rectTransform.anchoredPosition= new Vector3 (InputDirection.x*(bgimg.rectTransform.sizeDelta.x/3),InputDirection.z*(bgimg.rectTransform.sizeDelta.y/3));
	
		}	
															   
														
	}
    public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
		
	}		
	
    public virtual void OnPointerUp(PointerEventData ped)
	{
		InputDirection=Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
		InputDirection = new Vector3 (0,0,0);
		
	}	
public float Horizontal()
{
	
	

		if (InputDirection.x > 0.3f||InputDirection.x < -0.3f) {
			return InputDirection.x;
		} else {
			return 0;
		}
		//return InputDirection.x;
	
	
	
		
	
	
}	

public float Vertical()
{
	

		if (InputDirection.z > 0.3f||InputDirection.z < -0.3f) {
			return InputDirection.z;
		} else {
			return 0;
		}
	
		/*
	if(Input.GetKey("u"))
		{
			up=-5;
			
		}
		if(Input.GetKey("j"))
		{
			up=5;
			
		}
		 if(Input.GetKeyUp("u") || Input.GetKeyUp("j"))
		{up=0;}
	return up;*/
	
}	
}
