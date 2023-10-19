using CommunityToolkit.Mvvm.ComponentModel;

namespace Threads.Models
{
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
}
