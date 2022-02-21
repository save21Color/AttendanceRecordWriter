using Prism.Commands;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Timers;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using AttendanceRecordWriter.UI.Views;
using System.Collections.ObjectModel;
using Reactive.Bindings;
using Reactive.Bindings.Interactivity;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using AttendanceRecordWriter.Application.Service;
using Unity;
using Unity.Registration;
using Prism.Regions;
using Reactive.Bindings.Extensions;
using System.Windows;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using AttendanceRecordWriter.Domain.Model.Entity;
using AttendanceRecordWriter.UI.Model;
using System.ComponentModel;

namespace AttendanceRecordWriter.UI.ViewModels
{
    public class LoginShellViewModel : BindableBase, IDisposable, INotifyPropertyChanged
    {

        #region コンストラクタ
        public LoginShellViewModel(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;

            var mode = ReactivePropertyMode.DistinctUntilChanged | ReactivePropertyMode.RaiseLatestValueOnSubscribe;

            LoginCommand = new ReactiveCommand().AddTo(this.Disposable);

            LoginCommand.Subscribe(_ =>
            {
                if (SelectedUser.Value == null)
                {
                    Queue.Value.Enqueue("ユーザーを選択してください");
                    return;
                }

                var targetPassWord = PassWordList.Where(p => p.UserCode == SelectedUser.Value.UserCode).Select(s => s).SingleOrDefault().Password;
                if (string.IsNullOrEmpty(targetPassWord))
                {
                    Queue.Value.Enqueue("該当するパスワードが見つかりません。管理者に問い合わせてください");
                    return;
                }

                if (!targetPassWord.Equals(InputPassWord.Value))
                {
                    Queue.Value.Enqueue("パスワードが違います");
                    return;
                }

                Queue.Value.Enqueue("ログインしました");
                container.Resolve<MainShellViewModel>("MainVM").LoginSuccess(SelectedUser.Value);
            });

            ChenagedPassWordCommand = new ReactiveCommand().AddTo(this.Disposable);

            ChenagedPassWordCommand.Subscribe(_ =>
            {
                var passBox = _ as PasswordBox;
                InputPassWord.Value = passBox.Password.ToString();
            });

            SelectedUser = new ReactivePropertySlim<User>(null, mode).AddTo(this.Disposable);
            InputPassWord = new ReactivePropertySlim<string>("", mode).AddTo(this.Disposable);
            InfoMessage = new ReactivePropertySlim<string>("", mode).AddTo(this.Disposable);
            IsActiveInfo = new ReactivePropertySlim<bool>(false, mode).AddTo(this.Disposable);
            Queue = new ReactivePropertySlim<SnackbarMessageQueue>(new SnackbarMessageQueue(), mode).AddTo(this.Disposable);

            var userService = new ApplicationService(container);
            InitializeUserList = ((IEnumerable<M_USER>)userService.RepositoryServiceExecute("FindAll", "M_USER",null)).Select(_ => new MUserVo(_));
            UserList = new ObservableCollection<User>(InitializeUserList.Select(_ => new User(_)));

            var pwdService = new ApplicationService(container);
            PassWordList = ((IEnumerable<M_PASSWORD>)pwdService.RepositoryServiceExecute("FindAll", "M_PASSWORD", null)).Select(_ => new MPassWordVo(_));

            container.RegisterInstance<IEnumerable<MUserVo>>(InitializeUserList);
            container.RegisterInstance<IEnumerable<MPassWordVo>>(PassWordList);
        }

        #endregion

        #region 変数
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;
        #endregion

        #region プロパティ

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public ObservableCollection<User> UserList
        {
            get { return userList; }
            set { SetProperty(ref userList, value); }
        }

        public ReactivePropertySlim<User> SelectedUser { get; private set; }

        public ReactivePropertySlim<string> InputPassWord { get; private set; }

        public ReactivePropertySlim<string> InfoMessage { get; private set; }

        public ReactivePropertySlim<bool> IsActiveInfo { get; private set; }

        public ReactivePropertySlim<SnackbarMessageQueue> Queue { get; private set; }

        public IEnumerable<MUserVo> InitializeUserList { get; set; }

        public IEnumerable<MPassWordVo> PassWordList { get; set; }

        #endregion

        #region コマンド
        public ReactiveCommand LoginCommand { get; private set; }
        public ReactiveCommand ChenagedPassWordCommand { get; private set; }
        #endregion

        #region メソッド

        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }

        #endregion

        #region 非公開メンバー
        private ObservableCollection<User> userList;
        #endregion

    }
}
