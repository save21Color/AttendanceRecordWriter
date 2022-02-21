using Prism.Mvvm;
using Unity;
using System.Threading.Tasks;
using Prism.Regions;
using Reactive.Bindings;
using Reactive;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections.Generic;
using Prism.Commands;
using AttendanceRecordWriter.UI.Views;
using AttendanceRecordWriter.UI.Model;
using System.ComponentModel;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Controls;
using MaterialDesignThemes.Wpf;
using System.Linq;

namespace AttendanceRecordWriter.UI.ViewModels
{
    public class MainShellViewModel : BindableBase, IDisposable, INotifyPropertyChanged
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="regionManager">リージョンマネージャー</param>
        /// <param name="container">Unityコンテナ</param>
        public MainShellViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            var mode = ReactivePropertyMode.DistinctUntilChanged | ReactivePropertyMode.RaiseLatestValueOnSubscribe;

            this.regionManager = regionManager;
            this.container = container;

            _title = "AttendanceRecordWriter";
            UserList = new ObservableCollection<User>();

            LoginUser = new ReactivePropertySlim<User>(null, mode).AddTo(this.Disposable);
            NowMounth = new ReactivePropertySlim<DateTime>(new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1), mode).AddTo(this.Disposable);
            NowMounth.Subscribe(_ =>
            {
                if (!container.IsRegistered<AttendanceRecordShellViewModel>("AttendanceRecord"))
                {
                    return;
                }
                container.Resolve<AttendanceRecordShellViewModel>("AttendanceRecord").Refresh();

            });


            IsMenuVisible = new ReactivePropertySlim<Visibility>(Visibility.Hidden, mode).AddTo(this.Disposable);
            SelectIndex = new ReactivePropertySlim<int>(0, mode).AddTo(this.Disposable);
            IsDialogOpen = new ReactivePropertySlim<bool>(false, mode).AddTo(this.Disposable);
            InputPassWord = new ReactivePropertySlim<string>(string.Empty, mode).AddTo(this.Disposable);
            MainMessageQueue = new ReactivePropertySlim<SnackbarMessageQueue>(new SnackbarMessageQueue(), mode).AddTo(this.Disposable);

            ChangeUserCommand = new ReactiveCommand<SelectionChangedEventArgs>().AddTo(this.Disposable);
            ChangeUserCommand.Subscribe<SelectionChangedEventArgs>(e =>
            {
                if (!e.AddedItems.Cast<User>().Any() || !e.RemovedItems.Cast<User>().Any())
                {
                    return;
                }

                if (e.AddedItems.Cast<User>().First().UserCode.Equals(InitializeLoginUser.UserCode))
                {
                    return;
                }
                tempUser =  e.RemovedItems.Cast<User>().First();
                IsDialogOpen.Value = true;
            });

            ExecuteChangeUserCommand = new ReactiveCommand<DialogClosingEventArgs>().AddTo(this.Disposable);
            ExecuteChangeUserCommand.Subscribe(e =>
            {
                if (((Border)e.Content).DataContext.GetType().Name != "MainShellViewModel") return;

                if(!(bool)e.Parameter)
                {
                    LoginUser.Value = tempUser;
                    InputPassWord.Value = string.Empty;
                    tempUser = null;
                    e.Handled = true;
                    return;
                }

                var targetPassWord = container.Resolve<IEnumerable<MPassWordVo>>().Where(p => p.UserCode == LoginUser.Value.UserCode).Select(s => s).SingleOrDefault().Password;
                if (!targetPassWord.Equals(InputPassWord.Value))
                {
                    MainMessageQueue.Value.Enqueue("パスワードが違います");
                    LoginUser.Value = tempUser;
                    InputPassWord.Value = string.Empty;
                    tempUser = null;
                    return;
                }

                // ToDo 以下ユーザー変更に成功したときの勤務表再取得処理

            });

            ChenagedPassWordCommand = new ReactiveCommand().AddTo(this.Disposable);
            ChenagedPassWordCommand.Subscribe(_ => 
            {
                var passBox = _ as PasswordBox;
                InputPassWord.Value = passBox.Password.ToString();
            });

            NavigationAttendanceRecordCommand = new ReactiveCommand().AddTo(this.Disposable);
            NavigationAttendanceRecordCommand.Subscribe(_ => regionManager.RequestNavigate("MainRegion", "AttendanceRecordShell"));

            NavigationTransportationExpensesCommand = new ReactiveCommand().AddTo(this.Disposable);
            NavigationTransportationExpensesCommand.Subscribe(_ => regionManager.RequestNavigate("MainRegion", "TransportationExpensesShell"));

            NavigationTemporaryPaymentCommand = new ReactiveCommand().AddTo(this.Disposable);
            NavigationTemporaryPaymentCommand.Subscribe(_ => regionManager.RequestNavigate("MainRegion", "TemporaryPaymentShell"));

            container.RegisterInstance<MainShellViewModel>("MainVM", this);
        }

        /// <summary>
        /// ログイン画面でログイン成功時
        /// </summary>
        /// <param name="user"></param>
        public void LoginSuccess(User user)
        {
            IsMenuVisible.Value = Visibility.Visible;
            UserList = new ObservableCollection<User>(container.Resolve<IEnumerable<MUserVo>>().Select(_ => new User(_)));
            InitializeLoginUser = user;
            LoginUser.Value = user;
            SelectIndex.Value = UserList.IndexOf(UserList.Where(_ => _.UserCode.Equals(user.UserCode)).First());
            container.RegisterInstance<User>("LoginUser",user);
            regionManager.RequestNavigate("MainRegion", "AttendanceRecordShell");
        }
        #endregion

        #region 変数
        private readonly IRegionManager regionManager;
        private IUnityContainer container;
        private User tempUser;
        #endregion

        #region プロパティ

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ReactivePropertySlim<DateTime> NowMounth { get; private set; }

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set { SetProperty(ref userList, value); }
        }

        public User InitializeLoginUser { get; set; }

        public ReactivePropertySlim<User> LoginUser { get; private set; }

        public ReactivePropertySlim<string> InputPassWord { get; private set; }

        public ReactivePropertySlim<SnackbarMessageQueue> MainMessageQueue { get; }

        public ReactivePropertySlim<int> SelectIndex { get; private set; }

        public ReactivePropertySlim<Visibility> IsMenuVisible { get; }

        public ReactivePropertySlim<bool> IsDialogOpen { get; }

        #endregion

        #region コマンド
        public ReactiveCommand InitializeCommand { get; }
        public ReactiveCommand ChenagedPassWordCommand { get; }
        public ReactiveCommand<DialogClosingEventArgs> ExecuteChangeUserCommand { get; }
        public ReactiveCommand<SelectionChangedEventArgs> ChangeUserCommand { get; }
        public ReactiveCommand NavigationAttendanceRecordCommand { get; }
        public ReactiveCommand NavigationTransportationExpensesCommand { get; }
        public ReactiveCommand NavigationTemporaryPaymentCommand { get; }
        #endregion

        #region メソッド
        public void Dispose()
        {
            Disposable.Dispose();
        }

        public void InvokeMessageQueue(string message)
        {
            MainMessageQueue.Value.Enqueue(message);
        }

        #endregion

        #region 非公開メンバー
        private string _title;
        private ObservableCollection<User> userList;
        #endregion

    }
}
