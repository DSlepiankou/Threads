using CommunityToolkit.Mvvm.ComponentModel;

namespace Threads.Models
{
    public partial class AUser : ObservableObject
    {
        [ObservableProperty]
        string userName;
        [ObservableProperty]
        string displayName;
        [ObservableProperty]
        int followerCount;
        [ObservableProperty]
        string image;
        [ObservableProperty]
        bool isVerified;
        [ObservableProperty]
        bool isFollowing;
    }
}
