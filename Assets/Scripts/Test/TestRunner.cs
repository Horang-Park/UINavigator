using System;
using Horang.UINavigator.UIView;
using UnityEngine;

namespace Test
{
	public class TestRunner : MonoBehaviour
	{
		[SerializeField] private UIViewNavigator uiViewNavigator;

		private void Start()
		{
			new FirstUIEventBinder(uiViewNavigator).BindEvent();
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