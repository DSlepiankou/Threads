using CommunityToolkit.Maui.Markup;
using Threads.Helpers;
using Threads.Models;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace Threads.Controls
{
    public class ThreadView : Grid
    {

        const int iconSize = 20;
        public ThreadView()
        {

            ColumnDefinitions = Columns.Define(Auto, Star, Auto, Auto);
            RowDefinitions = Rows.Define(Auto, Auto, Auto, Auto);
            ColumnSpacing = 10;
            RowSpacing = 5;
            Padding = 10;
            Children.Add(
                new Image()
                    .Bind(Image.SourceProperty, nameof(AThread.Image))
                    .Height(35).Width(35)
                    .Row(0).Column(0)
                    .RowSpan(2)
                    .CenterHorizontal()
                    .Top()
                    .CenterVertical()
                    .Margin(new Thickness(0, 10, 0, 0))
                    .Aspect(Aspect.AspectFill));
            Children.Add(new HorizontalStackLayoutSpaced(5)
            {
                new Label()
                    .Bind(Label.TextProperty,nameof(AThread.User))
                    .Bold()
                    .Bottom(),
                new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.CircleCheck)
                    .TextColor(Colors.Blue)
                    .Bind(Label.IsVisibleProperty, nameof(AThread.IsVerified))
                    .Bottom()
            }.Row(0).Column(1));

            Children.Add(new Label()
                .Bind(Label.TextProperty, nameof(AThread.TimeAgo))
                .Row(0).Column(2)
                .Bold()
                .Bottom());

            Children.Add(new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.Ellipsis)
                        .Row(0).Column(3)
                        .Bottom());

            Children.Add(new Label()
                .Bind(Label.TextProperty, nameof(AThread.Message))
                .Row(1).Column(1)
                .Padding(1)
                .ColumnSpan(3));

            Children.Add(new HorizontalStackLayoutSpaced
            {
                new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.Heart)
                    .FontSize(iconSize),
                new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.Comment)
                    .FontSize(iconSize),
                new FontAwesomeLabel(FontAwesomeStyle.Solid, FontAwesomeIcons.Retweet)
                    .FontSize(iconSize),
                new FontAwesomeLabel(FontAwesomeStyle.Regular, FontAwesomeIcons.PaperPlane)
                    .FontSize(iconSize),
            }.Row(2).Column(1).Margin(0,8));

            Children.Add(
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
                }.Row(3).Column(1).ColumnSpan(3));
        }
    };

}