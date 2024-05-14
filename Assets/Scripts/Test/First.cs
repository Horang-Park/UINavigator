using System;
using Horang.UINavigator.UIView;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Task = System.Threading.Tasks.Task;

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

		public override async void Show()
		{
			// 트랜지션 중
			VisibleState = VisibleStates.Appearing;

			await Task.Delay(TimeSpan.FromMilliseconds(1000.0f));
			
			// 일정 시간의 트랜지션이 끝난 후
			VisibleState = VisibleStates.Appeared;
		}

		public override void HideInitialize()
		{
			button.onClick.RemoveAllListeners();
		}

		public override async void Hide()
		{
			// 트랜지션 중
			VisibleState = VisibleStates.Disappearing;

			await Task.Delay(TimeSpan.FromMilliseconds(1000.0f));
			
			// 일정 시간의 트랜지션이 끝난 후
			VisibleState = VisibleStates.Disappeared;
		}
	}
}