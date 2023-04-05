using Universum.MainPages.AccountPages;

namespace Universum;

public partial class AccountPage : ContentPage
{
    public AccountPage()
    {
        InitializeComponent();
    }

    private void OnAccountsBtn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AccountsPage());
    }

    private void OnInformationBtn(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InformationPage());
    }
}