using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Mvvm.ComponentModel;
using Threads.Controls;
using Threads.Helpers;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace Threads.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        var listView = new ListView(ListViewCachingStrategy.RetainElement)
        {
            HasUnevenRows = true,
            ItemTemplate = new DataTemplate(typeof(ThreadCell)),
            IsPullToRefreshEnabled = true,
            SelectionMode = ListViewSelectionMode.None,
            SeparatorVisibility = SeparatorVisibility.None,
            ItemsSource = new[] {

                new AThread {
                    User = "Dima Slepiankou",
                    Message = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd",
                    IsVerified = true,
                    Likes = 10,
                    Image = "profile.png",
                    Replies=10,
                    TimeAgo="2 min"
                },
                new AThread {
                    User = "loh",
                    Message = "Some msg2",
                    IsVerified = true,
                    Likes = 11,
                    Replies=10,
                    TimeAgo="3 min",
                    Image = "profile.png"
                },
                new AThread {
                    User = "DVBC",
                    Message = "Some msg3",
                    IsVerified = false,
                    Likes = 12,
                    Replies=10,
                    TimeAgo="4 min",
                    Image = "profile.png"
                }
            }
        };

        Content = listView;
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
        [NotifyPropertyChangedFor(nameof(HasLikes))]
        int likes;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasReplies))]

        int replies;

        [ObservableProperty]
        bool isVerified;

        [ObservableProperty]
        string timeAgo;

        public bool HasReplies => Replies > 0;
        public bool HasLikes => Likes > 0;
    }

    public class ThreadCell : ViewCell
    {
        const int iconSize = 20;
        public ThreadCell()
        {
            View = new Grid
            {
                ColumnDefinitions = Columns.Define(Auto, Star, Auto, Auto),
                RowDefinitions = Rows.Define(Auto, Auto, Auto, Auto),
                ColumnSpacing = 10,
                RowSpacing = 5,
                Padding = 10,
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
                    new HorizontalStackLayoutSpaced(5)
                    {
                        new Label()
                            .Bind(Label.TextProperty,nameof(AThread.User))
                            .Bold()
                            .Bottom(),
                        new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.CircleCheck)
                            .TextColor(Colors.Blue)
                            .Bind(Label.IsVisibleProperty, nameof(AThread.IsVerified))
                            .Bottom()
                    }.Row(0).Column(1),

                    new Label()
                        .Bind(Label.TextProperty,nameof(AThread.TimeAgo))
                        .Row(0).Column(2)
                        .Bold()
                        .Bottom(),

                    new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.Ellipsis)
                        .Row(0).Column(3)
                        .Bottom(),

                    new Label()
                        .Bind(Label.TextProperty, nameof(AThread.Message))
                        .Row(1).Column(1)
                        .Padding(1)
                        .ColumnSpan(3),
                    new HorizontalStackLayoutSpaced
                    {
                        new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.Heart)
                            .FontSize(iconSize),
                        new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.Comment)
                            .FontSize(iconSize),
                        new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.Retweet)
                            .FontSize(iconSize),
                        new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.PaperPlane)
                            .FontSize(iconSize),
                    }.Row(2).Column(1),

                    new HorizontalStackLayoutSpaced
                    {
                        new Label()
                            .Bind(Label.TextProperty, nameof(AThread.Replies),stringFormat:"{0} replies")
                            .Bind(Label.IsVisibleProperty, nameof(AThread.HasReplies))
                            .CenterVertical(),
                        new Label()
                            .Bind(Label.TextProperty, nameof(AThread.Likes),stringFormat:"{0} likes")
                            .Bind(Label.IsVisibleProperty, nameof(AThread.HasLikes))
                            .CenterVertical()
                    }.Row(3).Column(1).ColumnSpan(3),
                }
            };
        }
    }
}