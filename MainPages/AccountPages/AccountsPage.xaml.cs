namespace Universum.MainPages.AccountPages;

public partial class AccountsPage : ContentPage
{
	public AccountsPage()
	{
		InitializeComponent();

		//Shell.SetTabBarIsVisible(Accounts, false);
		//Shell.SetFlyoutItemIsVisible(Accounts, false);
		//Shell.SetNavBarIsVisible(Accounts, false);
	}

	private void OnAddAccount(object sender, EventArgs e)
	{
		Navigation.PushAsync(new LogIntoAccountPage());
	}
}