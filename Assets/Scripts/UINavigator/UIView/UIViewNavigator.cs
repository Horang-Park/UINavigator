using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Horang.UINavigator.UIView
{
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(CanvasScaler))]
	[RequireComponent(typeof(GraphicRaycaster))]
	public class UIViewNavigator : MonoBehaviour
	{
		private readonly Dictionary<int, UIView> _views = new();
		private readonly Stack<UIView> _viewStack = new();

		public T Get<T>(string viewGameObjectName) where T : UIView
		{
			var key = viewGameObjectName.GetHashCode();

			if (_views.TryGetValue(key, out var view))
			{
				return view as T;
			}
			
			Debug.LogError($"{viewGameObjectName}이(가) 없습니다.");

			throw new KeyNotFoundException();
		}

		public void Push(UIView uiView)
		{
			if (_viewStack.Contains(uiView))
			{
				Debug.LogWarning($"이미 보여진 UI입니다. -> {uiView.name}");
				
				return;
			}
			
			uiView.ShowInitialize();
			uiView.Show();
			
			_viewStack.Push(uiView);
		}

		public void Pop()
		{
			if (_viewStack.Count < 1)
			{
				Debug.LogWarning("Pop할 UI가 없습니다.");
				
				return;
			}

			var ui = _viewStack.Pop();
			ui.HideInitialize();
			ui.Hide();
		}

		public void PopLeastOne()
		{
			while (_viewStack.Count > 1)
			{
				Pop();
			}
		}
		
		private void Awake()
		{
			var childViews = gameObject.GetComponentsInChildren<UIView>();

			foreach (var childView in childViews)
			{
				var key = childView.gameObject.name.GetHashCode();

				if (_views.TryAdd(key, childView))
				{
					childView.InitializeOnce();
					
					continue;
				}
				
				Debug.LogError($"{childView.gameObject.name}이(가) 중복되었습니다.");

				throw new DuplicateNameException();
			}
		}
	}
}