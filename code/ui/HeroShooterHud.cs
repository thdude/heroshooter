using Sandbox.UI;

//
// You don't need to put things in a namespace, but it doesn't hurt.
//
namespace HeroShooter
{
	/// <summary>
	/// This is the HUD entity. It creates a RootPanel clientside, which can be accessed
	/// via RootPanel on this entity, or Local.Hud.
	/// </summary>
	public partial class HeroShooterHud : Sandbox.HudEntity<RootPanel>
	{
		public HeroShooterHud()
		{
			if ( IsClient )
			{
				RootPanel.StyleSheet.Load( "/ui/HeroShooterHud.scss" );
				RootPanel.StyleSheet.Load( "/ui/HeroMenu.scss" );

				RootPanel.SetTemplate("ui/base.html");
				mainUI();
			}
		}
		public void SelectorUI()
		{
			if(IsClient)
			{
				RootPanel.DeleteChildren();

				RootPanel.AddChild<HeroSelector>();
			}
		}
		public void mainUI()
		{
			if(IsClient)
			{
				RootPanel.DeleteChildren();

				RootPanel.AddChild<ChatBox>();
				RootPanel.AddChild<KillFeed>();
				RootPanel.AddChild<Scoreboard<ScoreboardEntry>>();
				RootPanel.AddChild<Health>();
			}
		}
	}

}
