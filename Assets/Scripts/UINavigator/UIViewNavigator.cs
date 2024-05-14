using System.Collections.Generic;
using System.Data;
using Horang.UINavigator.Exceptions;
using Horang.UINavigator.UIView;
using UnityEngine;
using UnityEngine.UI;

namespace Horang.UINavigator
{
	[RequireComponent(typeof(RectTransform))]
	[RequireComponent(typeof(Canvas))]
	[RequireComponent(typeof(CanvasScaler))]
	[RequireComponent(typeof(GraphicRaycaster))]
	public class UIViewNavigator : MonoBehaviour
	{
		private readonly Dictionary<int, UIView.UIView> _views = new();
		private readonly Stack<UIView.UIView> _viewStack = new();

		private bool _initialized;
		
		public void Initialize()
		{
			if (_initialized)
			{
				Debug.LogWarning("Already initialized.");
				
				return;
			}
			
			var childViews = gameObject.GetComponentsInChildren<UIView.UIView>();

			foreach (var childView in childViews)
			{
				var key = childView.gameObject.name.GetHashCode();

				if (_views.TryAdd(key, childView))
				{
					childView.InitializeOnce();
					
					continue;
				}
				
				Debug.LogError($"[{childView.gameObject.name}] is duplicated name.");

				throw new DuplicateNameException();
			}

			_initialized = true;
		}

		public T Get<T>(string viewGameObjectName) where T : UIView.UIView
		{
			if (_initialized is false)
			{
				Debug.LogError("Do initialize first.");

				throw new NotInitializedException();
			}
			
			var key = viewGameObjectName.GetHashCode();

			if (_views.TryGetValue(key, out var view))
			{
				return view as T;
			}
			
			Debug.LogError($"Cannot find [{viewGameObjectName}].");

			throw new KeyNotFoundException();
		}

		public void Push(UIView.UIView uiView)
		{
			if (_initialized is false)
			{
				Debug.LogError("Do initialize first.");

				throw new NotInitializedException();
			}
			
			if (_viewStack.Contains(uiView))
			{
				Debug.LogWarning($"[{uiView.name}] is already appeared.");
				
				return;
			}
			
			if (uiView.VisibleState is ViewBase.VisibleStates.Disappearing)
			{
				Debug.LogWarning($"[{uiView.name}] is disappearing now.");
				
				return;
			}
			
			uiView.ShowInitialize();
			uiView.Show();
			
			_viewStack.Push(uiView);
		}

		public void Pop()
		{
			if (_initialized is false)
			{
				Debug.LogError("Do initialize first.");

				throw new NotInitializedException();
			}
			
			if (_viewStack.Count < 1)
			{
				Debug.LogWarning("There is no pop-able UI.");
				
				return;
			}

			var ui = _viewStack.Peek();

			if (ui.VisibleState is ViewBase.VisibleStates.Appearing)
			{
				Debug.LogWarning($"[{ui.name}] is appearing now.");
				
				return;
			}

			ui = _viewStack.Pop();
			ui.HideInitialize();
			ui.Hide();
		}

		public void PopLeastOne()
		{
			if (_initialized is false)
			{
				Debug.LogError("Do initialize first.");

				throw new NotInitializedException();
			}
			
			while (_viewStack.Count > 1)
			{
				Pop();
			}
		}

		public void BindEvent(UIViewEventBinder binder)
		{
			if (_initialized is false)
			{
				Debug.LogError("Do initialize first.");

				throw new NotInitializedException();
			}
			
			binder.Bind(this);
		}
	}
}