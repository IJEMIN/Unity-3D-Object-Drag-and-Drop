using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// IDragHandler 를 추가하면 반드시 OnDrag 함수를 구현해야 하며, 이벤트 시스템에 의한 이벤트를 받을 수 있다.
// 동작 조건:
// 1. 자신에게 Collider 같은 "광선"을 쐴수 있는 컴포넌트가 붙어 있을것
// 2. 씬 상에 Physics RayCaster 같은 "광선"을 쏠 수 있는 컴포넌트가 있을것
// 3. 씬 상에 이벤트를 전달하는 EventSystem 오브젝트가 있을것
public class DragableObject : MonoBehaviour,IDragHandler,IBeginDragHandler,IEndDragHandler {

	// 드래그를 시작하려는 순간의 카메라와 오브젝트 사이 거리
	// 드래그를 하는 동안 계속해서 카메라와 오브젝트 사이의 거리를 유지해준다.
	float distanceBetCam = 0;

	// 드래그 하는 동안
	// PointerEventData 에는 클릭이나 터치의 위치, 터치나 커서가 이동중인 상대 거리 등의 정보를 가진 이벤트 데이터
	public void OnDrag(PointerEventData data)
	{
		// 커서(터치) 위치
		Vector2 touchPosition = data.position;

		// 화면상의 이 터치 지점이 게임 세상 속에서는 어디 인가?
		// 화면상의 위치를 -> 게임 세상속의 좌표로 변환
		// ScreenToWorldPoint(화면상 x 좌표, 화면상 y 좌표, 카메라와 벌려줄 거리)
		Vector3 touchPositionInWorld = Camera.main.ScreenToWorldPoint(
			new Vector3(
				touchPosition.x,
				touchPosition.y,
				distanceBetCam)
		);

		// 나의 위치를 터치 위치를 게임 세상속의 위치로 변환한 위치로 덮어씌움
		transform.position = touchPositionInWorld;
	}

	// 드래그가 막 시작되는 순간
	public void OnBeginDrag(PointerEventData data)
	{
		Debug.Log("Drag Begin!");
		// 카메라와 오브젝트 사이의 거리를 기억해둬야 함
		distanceBetCam = Vector3.Distance(transform.position,Camera.main.transform.position);
	}

	public void OnEndDrag(PointerEventData data)
	{

	}


}
