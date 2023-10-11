using CommunityToolkit.Maui.Markup;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace Threads.Pages;

public class HomePage : ContentPage
{
    public HomePage()
    {
        var listView = new ListView(ListViewCachingStrategy.RecycleElement)
        {
            HasUnevenRows = true,
            ItemTemplate = new DataTemplate(typeof(ThreadCell)),
            ItemsSource = new[] { "Name", "dotnet", "smth" }
        };

        Content = listView;
    }
    public class ThreadCell : ViewCell
    {
        public ThreadCell()
        {
            View = new Grid
            {
                ColumnDefinitions = Columns.Define(50, Star, Auto, 50),
                RowDefinitions = Rows.Define(50, Star, 60, 50),

                Children =
                {
                    new Image()
                    .Source("profile.jpg")
                    .Height(50).Width(50)
                    .Row(0).Column(0)
                    .RowSpan(2)
                    .CenterHorizontal()
                    .CenterVertical()
                    .Aspect(Aspect.AspectFill),

                    new Label()
                    .Bind(Label.TextProperty,".")
                    .Row(0).Column(1)
                    .Bold()
                    .End(),

                    new Label()
                        .Text("1")
                        .Row(0).Column(1),
                     new Label()
                        .Text("2")
                        .Row(0).Column(1),
                      new Label()
                        .Text("3")
                        .Row(0).Column(2),
                       new Label()
                        .Text("4")
                        .Row(1).Column(0),
                        new Label()
                        .Text("5")
                        .Row(1).Column(1),
                        new Label()
                        .Text("6")
                        .Row(1).Column(2),
                }
            };
        }
    }
}


