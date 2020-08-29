using Petsy.Cache;
using Petsy.Models.DTO;
using Petsy.Services.APIClient;
using Petsy.Services.FireBaseRealTimeDataBase;
using Petsy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Petsy.ClientModul.Views.MainNavigationPages.ChildrenPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MessagesItemPage : ContentPage
    {
        ICache<User> currentUser;
        IApi clientRestApi;
        IChatApi chatService = RealtimeDatabaseChatService.GetInstance();
        ObservableCollection<ModelMsgItem> messages = new ObservableCollection<ModelMsgItem>(); 
        public MessagesItemPage()
        {
            clientRestApi = Api.GetInstance();
            currentUser = CurrentUser.GetInstance();
            chatService.OnChangeOrAddMsgHandlerNotify += OnGetNewMsg;
            chatService.SubscribeToMsgChanges();
            InitializeComponent();
            Logic();
        }
        private void Logic()
        {
            CollectionView chatView = ChatsCollectionView;
            chatView.SetBinding(ItemsView.ItemsSourceProperty, "Chats");
            chatView.ItemTemplate = new DataTemplate(() =>
            {
                StackLayout stackLayout = new StackLayout { };
                Frame msgBox = new Frame { BackgroundColor = Color.FromHex("#F0CDB1"), Margin = new Thickness(5), CornerRadius = 20, Padding = 20, HorizontalOptions = LayoutOptions.StartAndExpand };
                msgBox.SetBinding(Frame.HorizontalOptionsProperty, "HorizonalOtions");
                StackLayout contentFareme = new StackLayout() {WidthRequest = 200};
                msgBox.Content = contentFareme;
                //contentFareme.SetBinding(StackLayout.HorizontalOptionsProperty, "HorizonalOtions");
                var test = new Label();
                test.SetBinding(Label.TextProperty, "Text");
                contentFareme.Children.Add(test);
                contentFareme.SetBinding(View.HorizontalOptionsProperty, "HorizonalOtions");



                stackLayout.Children.Add(msgBox);
                return stackLayout;
            });

            // Делаю запрос серверу на возрат всех ситтеров по фильтру, получаю ответ в виде списка DTO обьектов, перевожу этот
            // список в список моделей для ViewItem и возарщаю этот список елементу sittersVIew как источник данных
            chatView.ItemsSource = messages;

        }

        private void OnGetNewMsg(Message msg)
        {
            messages.Add(new ModelMsgItem(msg));
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            if (MessegeEntry.Text != null)
                await chatService.SendMsg(MessegeEntry.Text);
            MessegeEntry.Text = null;
                
        }
    }

    public class ModelMsgItem{
        public LayoutOptions HorizonalOtions { get; set; }
        public string Text { get; set; }
        public ModelMsgItem(Message msg)
        {
            this.Text = msg.Text;
            this.HorizonalOtions = (msg.Uid == CurrentUser.GetInstance().Get().UID) ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand;
        }
    }
}