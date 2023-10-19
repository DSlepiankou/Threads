using Threads.Controls;

namespace Threads.Pages;

public class ThreadCell : ViewCell
{
    const int iconSize = 20;
    public ThreadCell()
    {
        View = new ThreadView();
    }
}
public partial class HomePage : BasePage
{
    public HomePage()
    {
    }

    public override void Build()
    {
        var listView = new ListView(ListViewCachingStrategy.RetainElement)
        {
            HasUnevenRows = true,
            ItemTemplate = new DataTemplate(typeof(ThreadCell)),
            IsPullToRefreshEnabled = true,
            SelectionMode = ListViewSelectionMode.None,
            SeparatorVisibility = SeparatorVisibility.None,
            ItemsSource = ThreadsGenerator.CreateThreads()
        };

        Content = listView;
    }
}