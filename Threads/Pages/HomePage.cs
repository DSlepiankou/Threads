using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using Threads.Helpers;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace Threads.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        var listView = new ListView(ListViewCachingStrategy.RecycleElement)
        {
            HasUnevenRows = true,
            ItemTemplate = new DataTemplate(typeof(ThreadCell)),
            ItemsSource = new[] {
                new AThread {
                    User = "Dima",
                    Message = "Some msg2",
                    IsVerified = false,
                    Likes = 10,
                    Image = "profile.png",
                    Repilies=10,
                    TimeAgo="2 min"
                },
                new AThread {
                    User = "loh",
                    Message = "Some msg2",
                    IsVerified = true,
                    Likes = 11,
                    Repilies=10,
                    TimeAgo="3 min",
                    Image = "profile.png"
                },
                new AThread {
                    User = "DVBC",
                    Message = "Some msg3",
                    IsVerified = false,
                    Likes = 12,
                    Repilies=10,
                    TimeAgo="4 min",
                    Image = "profile.png"
                }
            }
        };

        Content = listView;
        Padding = 10;
    }

    public partial class AThread : ObservableObject
    {
        [ObservableProperty]
        string user;

        [ObservableProperty]
        string message;

        [ObservableProperty]
        string image;

        [ObservableProperty]
        int likes;

        [ObservableProperty]
        int repilies;

        [ObservableProperty]
        bool isVerified;

        [ObservableProperty]
        string timeAgo;
    }

    public class ThreadCell : ViewCell
    {
        public ThreadCell()
        {
            var icons = new HorizontalStackLayout()
            {
                new Label()
                    .Text(FontAwesomeIcons.Heart)
                    .Font("FAS"),
                new Label()
                    .Text(FontAwesomeIcons.Comment)
                    .Font("FAS"),
                new Label()
                    .Text(FontAwesomeIcons.Retweet)
                    .Font("FAS"),
                new Label()
                    .Text(FontAwesomeIcons.PaperPlane)
                    .Font("FAS"),

            };

            View = new Grid
            {
                ColumnDefinitions = Columns.Define(Auto, Star, Auto, Auto),
                RowDefinitions = Rows.Define(Auto, Star, 60, 50),
                ColumnSpacing = 10,
                RowSpacing = 5,
                Children =
                {
                    new Image()
                        .Bind(Image.SourceProperty, nameof(AThread.Image))
                        .Height(35).Width(35)
                        .Row(0).Column(0)
                        .RowSpan(2)
                        .CenterHorizontal()
                        .Top()
                        .CenterVertical()
                        .Margin(new Thickness(0,10,0,0))
                        .Aspect(Aspect.AspectFill),

                    new Label()
                        .Bind(Label.TextProperty,nameof(AThread.User))
                        .Row(0).Column(1)
                        .Bold()
                        .Bottom(),

                    new Label()
                        .Bind(Label.TextProperty,nameof(AThread.TimeAgo))
                        .Row(0).Column(2)
                        .Bold()
                        .Bottom(),

                    new Label()
                        .Text(FontAwesomeIcons.Ellipsis)
                        .Font("FAS")
                        .Row(0).Column(3)
                        .Bottom(),

                    new Label()
                        .Bind(Label.TextProperty, nameof(AThread.Message))
                        .Row(1).Column(1)
                        .ColumnSpan(3),

                    icons.Row(2).Column(1),
                }
            };
        }
    }
}