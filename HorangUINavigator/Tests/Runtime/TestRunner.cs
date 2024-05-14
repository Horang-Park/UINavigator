using System;
using Horang.UINavigator;
using Horang.UINavigator.UIView;
using Test.EventBinders;
using UnityEngine;

namespace Test
{
	public class TestRunner : MonoBehaviour
	{
		[SerializeField] private UIViewNavigator uiViewNavigator;

		private void Awake()
		{
			uiViewNavigator.Initialize();
		}

		private void Start()
		{
			uiViewNavigator.BindEvent(new FirstUIEventBinder());
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F1))
			{
				var first = uiViewNavigator.Get<First>("1");
				
				uiViewNavigator.Push(first);
			}
			
			if (Input.GetKeyDown(KeyCode.F3))
			{
				var third = uiViewNavigator.Get<Third>("3");
				
				uiViewNavigator.Push(third);
			}
			
			if (Input.GetKeyDown(KeyCode.F4))
			{
				uiViewNavigator.Pop();
			}

			if (Input.GetKeyDown(KeyCode.F5))
			{
				uiViewNavigator.PopLeastOne();
			}
		}
	}
}