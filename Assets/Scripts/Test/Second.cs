using Horang.UINavigator.UIView;

namespace Test
{
	public class Second : UIView
	{
		public override void ShowInitialize()
		{
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
		}

		public override void Hide()
		{
			// 트랜지션 중
			VisibleState = VisibleStates.Disappearing;
			
			// 일정 시간의 트랜지션이 끝난 후
			VisibleState = VisibleStates.Disappeared;
		}

		public void BindEvents()
		{
			
		}
	}
}