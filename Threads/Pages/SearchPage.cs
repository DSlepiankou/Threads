using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using Threads.Controls;
using Threads.Helpers;
using Threads.Models;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;
using ListView = Microsoft.Maui.Controls.ListView;

namespace Threads.Pages;

public partial class SearchPage : BasePage
{
    public SearchPage()
    {
        Shell.SetSearchHandler(this, new SearchHandler
        {
            Placeholder = "Search",
            ShowsResults = false,
            CancelButtonColor = Colors.Black,
            Keyboard = Keyboard.Text
        });

        On<iOS>().SetLargeTitleDisplay(LargeTitleDisplayMode.Always);
    }

    

    public class UserViewCell : ViewCell
    {
        Button followButton;

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext is not AUser user)
                return;

            followButton
                .Text(user.IsFollowing ? "Unfollow" : "Follow");
        }

        public UserViewCell()
        {
            followButton = new Button
            {
                BorderColor = Colors.LightGray,
                BorderWidth = 1
            }
            .Bold()
            .RowSpan(2)
            .Padding(20, 0)
            .Column(2)
            .Height(33)
            .BackgroundColor(Colors.Transparent)
            .TextColor(Colors.Black)
            .CenterVertical();

            View = new Grid
            {
                ColumnDefinitions = Columns.Define(Auto, Star, Auto),
                RowDefinitions = Rows.Define(Auto, Auto, Auto),
                ColumnSpacing = 10,
                RowSpacing = 4,
                Children =
                {
                    new Image()
                    .Bind(Image.SourceProperty, nameof(AUser.Image))
                    .Height(35).Width(35)
                    .Row(0).Column(0)
                    .RowSpan(2)
                    .CenterHorizontal()
                    .Top()
                    .CenterVertical()
                    .Margin(new Thickness(0, 5, 0, 0))
                    .Aspect(Aspect.AspectFill),
                    new HorizontalStackLayoutSpaced(5)
                    {
                        new Label()
                            .Bind(Label.TextProperty,nameof(AUser.UserName))
                            .Bold()
                            .Bottom(),
                        new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.CircleCheck)
                            .TextColor(Colors.Blue)
                            .Bind(Label.IsVisibleProperty, nameof(AUser.IsVerified))
                            .CenterVertical()
                    }.Row(0).Column(1),
                    new Label()
                    .Bind(Label.TextProperty, nameof(AUser.UserName))
                    .Bold()
                    .Column(1),
                    new Label()
                    .Bind(Label.TextProperty, nameof(AUser.DisplayName))
                    .Column(1)
                    .Row(1)
                    .TextColor(Colors.LightGray),
                     new Label()
                    .Bind(Label.TextProperty, nameof(AUser.FollowerCount), stringFormat : "{0} followers")
                    .Column(1)
                    .Row(2),
                     followButton
                }
            }.Padding(10, 10);
        }
    }

    public override void Build()
    {
        Title = "Search";
        var listView = new ListView(ListViewCachingStrategy.RecycleElement);
        listView.HasUnevenRows = true;
        listView.SelectionMode = ListViewSelectionMode.None;
        listView.ItemsSource = new[]
        {
            new AUser
            {
                UserName = "Dima",
                DisplayName = "Name",
                FollowerCount = 1500,
                IsVerified = true,
                IsFollowing = true,
                Image = "profile.jpg"
            },
            new AUser
            {
                UserName = "Dima2",
                DisplayName = "Name2",
                FollowerCount = 1500,
                IsVerified = true,
                IsFollowing = false,
                Image = "profile.jpg"
            }
        };

        listView.ItemTemplate = new DataTemplate(typeof(UserViewCell));
        Content = listView;
    }
}