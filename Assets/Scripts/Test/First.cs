using System;
using Horang.UINavigator.UIView;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
	public class First : UIView
	{
		public Action ButtonEvent
		{
			set => button.onClick.AddListener(() => value?.Invoke());
		}
		
		[SerializeField] private Button button;

		public override void ShowInitialize()
		{
			button.onClick.AddListener(() => {Debug.Log("1번 UI");});
		}

		public override void Show()
		{
			// 트랜지션 중
			VisibleState = VisibleStates.Appearing;
			
			// 일정 시간의 트랜지션이 끝난 후
			VisibleState = VisibleStates.Appeared;
		}

		public override void HideInitialize()
		{
			button.onClick.RemoveAllListeners();
		}

		public override void Hide()
		{
			// 트랜지션 중
			VisibleState = VisibleStates.Disappearing;
			
			// 일정 시간의 트랜지션이 끝난 후
			VisibleState = VisibleStates.Disappeared;
		}
	}
}