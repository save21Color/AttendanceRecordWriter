using Prism.Commands;
using MaterialDesignThemes.Wpf;
using System.Windows.Controls;
using System.Timers;
using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using Reactive.Bindings;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using AttendanceRecordWriter.Application.Service;
using Unity;
using Prism.Regions;
using Reactive.Bindings.Extensions;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using AttendanceRecordWriter.Domain.Model.Entity;
using AttendanceRecordWriter.UI.Factory;
using AttendanceRecordWriter.UI.Model;
using AttendanceRecordWriter.UI.Extension;
using AttendanceRecordWriter.UI.Common;
using System.ComponentModel;

namespace AttendanceRecordWriter.UI.ViewModels
{
    public class AttendanceRecordShellViewModel : BindableBase, IDisposable, INotifyPropertyChanged
    {
        public AttendanceRecordShellViewModel(IRegionManager regionManeger, IUnityContainer container)
        {
            var mode = ReactivePropertyMode.DistinctUntilChanged | ReactivePropertyMode.RaiseLatestValueOnSubscribe;

            this.regionManeger = regionManeger;
            this.container = container;

            States = new ObservableCollection<string>(AttendanceStateFactory.Create());
            SelectedState = new ReactivePropertySlim<Attendance>(Attendance.Working, mode).AddTo(this.Disposable);
            IsTekkiyouClick = new ReactivePropertySlim<bool>(false, mode).AddTo(this.Disposable);
            TempTekiyouContent = new ReactivePropertySlim<string>(string.Empty, mode).AddTo(this.Disposable);
            SelectedWorkPlan = new ReactivePropertySlim<WorkingPlan>(new WorkingPlan(), mode).AddTo(this.Disposable);
            TempSelectedWork = new ReactivePropertySlim<AttendanceWork>(new AttendanceWork(), mode).AddTo(this.Disposable);
            IsPlanWorkAttendane = new ReactivePropertySlim<bool>(false, mode).AddTo(this.Disposable);
            IsKanriEditClick = new ReactivePropertySlim<bool>(false, mode).AddTo(this.Disposable);
            SelectedKanriCode = new ReactivePropertySlim<AttendanceWork>(null, mode).AddTo(this.Disposable);
            SelectedAttendanceWork = new ReactivePropertySlim<AttendanceWork>(null, mode).AddTo(this.Disposable);
            SelectKanriCode = new ReactiveProperty<KanriCodes>(null, mode).AddTo(this.Disposable);

            SelectedPlanKanriCommand = new ReactiveCommand().AddTo(this.Disposable);
            SelectedPlanKanriCommand.Subscribe(_ =>
            {
                var tempKanriCodes = (KanriCodes)_;
                tempKanriCodes.IsChecked = !tempKanriCodes.IsChecked;

            });

            TekiyouClickedCommand = new ReactiveCommand().AddTo(this.Disposable);
            TekiyouClickedCommand.Subscribe(_ =>
            {
                var nowDay = (int)_;
                this.SelectedWorkPlan.Value = AttendanceWork.Where(w => w.Day == nowDay).Select(s => (WorkingPlan)s).FirstOrDefault();
                TempAttendanceWork.Add(new AttendanceWork());
                TempAttendanceWork.Add(new AttendanceWork());
                TempAttendanceWork.Add(new AttendanceWork());
                TempAttendanceWork.Add(new AttendanceWork());
                TempAttendanceWork.Add(new AttendanceWork());
                TempTekiyouContent.Value = this.SelectedWorkPlan.Value.Summarry;
                IsTekkiyouClick.Value = true;
            });

            KanriEditClickedCommand = new ReactiveCommand().AddTo(this.Disposable);
            KanriEditClickedCommand.Subscribe(_ =>
            {
                if (TempAttendanceWork != null) TempAttendanceWork.Clear();

                TempKanriCodes = new ObservableCollection<AttendanceWork>(InitializePastWorks);
                InitializePastWorks.Add(new AttendanceWork());
                IsKanriEditClick.Value = true;
            });

            KanriAddedCommand = new ReactiveCommand().AddTo(this.Disposable);
            KanriAddedCommand.Subscribe(_ =>
            {
                InitializePastWorks.Add(new AttendanceWork());
                InitializePastWorks = new ObservableCollection<AttendanceWork>(InitializePastWorks);
            });

            ExecuteTekiyouInputCommand = new ReactiveCommand<DialogClosingEventArgs>().AddTo(this.Disposable);
            ExecuteTekiyouInputCommand.Subscribe(e =>
            {
                TempAttendanceWork.Clear();
                if (!(bool)e.Parameter)
                {
                    e.Handled = true;
                    TempTekiyouContent.Value = string.Empty;
                    return;
                }
                SelectedWorkPlan.Value.Summarry = TempTekiyouContent.Value;
            });

            ExecuteKanriEditCommand = new ReactiveCommand<DialogClosingEventArgs>().AddTo(this.Disposable);
            ExecuteKanriEditCommand.Subscribe(e =>
            {
                if (!(bool)e.Parameter)
                {
                    TempKanriCodes.Clear();
                    e.Handled = true;
                    return;
                }
                InitializePastWorks = new ObservableCollection<AttendanceWork>(TempKanriCodes);
                TempKanriCodes.Clear();
            });

            PlanHolidayCheckedCommand = new ReactiveCommand().AddTo(this.Disposable);
            PlanHolidayCheckedCommand.Subscribe(_ =>
            {
                var day = (int)_;
                var checkedWork = AttendanceWork.Where(w => w.Day == day).FirstOrDefault();
                checkedWork.IsHoliday = AttendancePlan.Where(p => p.Day == day).Select(s => !s.IsHoliday).FirstOrDefault();
            });

            AttendanceSelectCommand = new ReactiveCommand().AddTo(this.Disposable);
            AttendanceSelectCommand.Subscribe(_ =>
            {
                InitializePastWorks.Add(new AttendanceWork());
            });

            CheckedCommand = new ReactiveCommand().AddTo(this.Disposable);
            CheckedCommand.Subscribe(_ =>
            {
                var tempItem = (KanriCodes)(((ComboBox)_).SelectedItem);
                this.InitializAttendanceWorks.Add(new AttendanceWork() { KanriCode = tempItem.KanriCode, KanriName = tempItem.KanriCode });
            });

            UnCheckedCommand = new ReactiveCommand().AddTo(this.Disposable);
            UnCheckedCommand.Subscribe(_ =>
            {
                var tempItem = (KanriCodes)(((ComboBox)_).SelectedItem);
                this.InitializAttendanceWorks.Remove(new AttendanceWork() { KanriCode = tempItem.KanriCode, KanriName = tempItem.KanriCode });
            });

            SelectedCommand = new ReactiveCommand<SelectionChangedEventArgs>().AddTo(this.Disposable);
            SelectedCommand.Subscribe(e =>
            {
                var tempComboBox = ((ListBox)e.OriginalSource);

                var tempItem = (KanriCodes)tempComboBox.SelectedItem;

                if (!tempItem.IsChecked)
                {
                    this.InitializePastWorks.Add(new AttendanceWork() { KanriCode = tempItem.KanriCode, KanriName = tempItem.KanriCode });
                    return;
                }
                this.InitializePastWorks.Remove(new AttendanceWork() { KanriCode = tempItem.KanriCode, KanriName = tempItem.KanriCode });
                SelectedKanriCodes.Where(_ => _.KanriCode == tempItem.KanriCode).Select(s => s.IsChecked = !s.IsChecked);

            });

            Refresh();

            var borderDate = DateTime.Now.AddMonths(-12).ToString("yyyyMMdd");

            var param = new Dictionary<string, Object>();
            param.Add("USER_CD", container.Resolve<MainShellViewModel>("MainVM").LoginUser.Value.UserCode);
            TempKanriCodes = new ObservableCollection<AttendanceWork>();

            var workTimeService = new ApplicationService(container);
            InitializeWorkTime = ((IEnumerable<T_WORKTIME>)workTimeService.RepositoryServiceExecute("FindBySearchCondition", "T_WORKTIME", param))
                                 .Select(_ => new TWorkTimeVo(_)).GroupBy(_ => _.No).Select(s => s.Last())
                                 .Where(w => DateTime.ParseExact(w.Date, "yyyyMMdd", null) > DateTime.ParseExact(borderDate, "yyyyMMdd", null));

            var kanriService = new ApplicationService(container);
            InitializeKanriCodes = new ObservableCollection<MBusinessVo>(((IEnumerable<M_BUSINESS>)kanriService.RepositoryServiceExecute("FindAll", "M_JYUKANRI")).Select(_ => new MBusinessVo(_)));
            InitializAttendanceWorks = new ObservableCollection<AttendanceWork>(InitializeKanriCodes.Select(_ => new AttendanceWork() { KanriCode = _.No, KanriName = _.ProjectName }));

            SelectedKanriCodes = new ObservableCollection<KanriCodes>(InitializAttendanceWorks.Select(_ => new KanriCodes() { KanriCode = _.KanriCode, KanriName = _.KanriName, IsChecked = false }));
            InitializePastWorks = new ObservableCollection<AttendanceWork>(InitializeWorkTime.Join(InitializeKanriCodes, wt => wt.No, kc => kc.No, (wt, kc) => new AttendanceWork() { KanriCode = kc.No, KanriName = kc.ProjectName }));

            SelectedKanriCodes = new ObservableCollection<KanriCodes>(SelectedKanriCodes.Select(_ =>
            {
                if (InitializePastWorks.Where(w => w.KanriCode == _.KanriCode).Any())
                {
                    _.IsChecked = true;
                }
                return _;
            }));

            TempAttendanceWork = new ObservableCollection<AttendanceWork>();
            container.RegisterInstance<AttendanceRecordShellViewModel>("AttendanceRecord", this);
        }

        #region 変数
        private IRegionManager regionManeger;
        private IUnityContainer container;
        #endregion

        #region プロパティ

        private CompositeDisposable Disposable { get; } = new CompositeDisposable();

        public IEnumerable<TWorkPlanVo> InitializeWorkPlan { get; set; }

        public ObservableCollection<WorkingPlan> AttendancePlan
        {
            get { return attendacePlan; }
            set { SetProperty(ref attendacePlan, value); }
        }

        public ObservableCollection<WorkingPlan> AttendanceWork
        {
            get { return attendanceWork; }
            set { SetProperty(ref attendanceWork, value); }
        }

        public ObservableCollection<string> States
        {
            get { return states; }
            set { SetProperty(ref states, value); }
        }

        public ObservableCollection<AttendanceWork> TempAttendanceWork
        {
            get { return tempAttendanceWork; }
            set { SetProperty(ref tempAttendanceWork, value); }
        }

        public ObservableCollection<AttendanceWork> InitializAttendanceWorks
        {
            get { return initializAttendanceWorks; }
            set { SetProperty(ref initializAttendanceWorks, value); }
        }

        public ReactivePropertySlim<AttendanceWork> SelectedAttendanceWork { get; }

        public ObservableCollection<AttendanceWork> InitializePastWorks
        {
            get { return initializePastWorks; }
            set { SetProperty(ref initializePastWorks, value); }
        }

        public ObservableCollection<MBusinessVo> InitializeKanriCodes
        {
            get { return initializeKanriCodes; }
            set { SetProperty(ref initializeKanriCodes, value); }
        }

        public ObservableCollection<AttendanceWork> TempKanriCodes
        {
            get { return tempKanriCodes; }
            set { SetProperty(ref tempKanriCodes, value); }
        }

        public ObservableCollection<KanriCodes> SelectedKanriCodes
        {
            get { return selectedKanriCodes; }
            set { SetProperty(ref selectedKanriCodes, value); }
        }

        public ReactiveProperty<KanriCodes> SelectKanriCode { get; }

        public ReactiveCommand AttendanceSelectCommand { get; }

        public ReactivePropertySlim<Attendance> SelectedState { get; }

        public ReactivePropertySlim<WorkingPlan> SelectedWorkPlan { get; }

        public ReactivePropertySlim<bool> IsTekkiyouClick { get; }

        public ReactivePropertySlim<bool> IsPlanWorkAttendane { get; }

        public ReactivePropertySlim<bool> IsKanriEditClick { get; }

        public ReactivePropertySlim<string> TempTekiyouContent { get; }

        public ReactivePropertySlim<AttendanceWork> TempSelectedWork { get; }

        public ReactivePropertySlim<AttendanceWork> SelectedKanriCode { get; }

        public ReactiveCommand TekiyouClickedCommand { get; }

        public ReactiveCommand PlanHolidayCheckedCommand { get; }

        public ReactiveCommand SelectedPlanKanriCommand { get; }

        public ReactiveCommand KanriEditClickedCommand { get; }

        public ReactiveCommand KanriAddedCommand { get; }

        public ReactiveCommand CheckedCommand { get; }

        public ReactiveCommand UnCheckedCommand { get; }

        public ReactiveCommand<SelectionChangedEventArgs> SelectedCommand { get; }

        public ReactiveCommand<DialogClosingEventArgs> ExecuteTekiyouInputCommand { get; }

        public ReactiveCommand<DialogClosingEventArgs> ExecuteKanriEditCommand { get; }

        public ObservableCollection<string> PastKanriCodes { get; set; }

        public IEnumerable<TWorkTimeVo> InitializeWorkTime { get; set; }

        #endregion

        #region メソッド
        public void Dispose()
        {
            // まとめてDisposeする
            Disposable.Dispose();
        }

        public void Refresh()
        {
            var mainVm = container.Resolve<MainShellViewModel>("MainVM");

            var _param = new Dictionary<string, Object>();
            _param.Add("USER_CD", mainVm.LoginUser.Value.UserCode);
            _param.Add("YMD", mainVm.NowMounth.Value.ToString("yyyyMM"));

            var workPlanService = new ApplicationService(container);
            InitializeWorkPlan = ((IEnumerable<T_WORKPLAN>)workPlanService.RepositoryServiceExecute("FindBySearchCondition", "T_WORKPLAN", _param)).Select(_ => new TWorkPlanVo(_));

            AttendancePlan = new ObservableCollection<WorkingPlan>(InitializeWorkPlan.Select(_ => _.PlanCreate()).Where(_ => _ != null));
            AttendanceWork = new ObservableCollection<WorkingPlan>(InitializeWorkPlan.Select(_ => _.WorkCreate()).Where(_ => _ != null));

        }

        #endregion

        #region 非公開メンバー
        private ObservableCollection<WorkingPlan> attendacePlan;
        private ObservableCollection<WorkingPlan> attendanceWork;
        private ObservableCollection<string> states;
        private ObservableCollection<AttendanceWork> initializePastWorks;
        private ObservableCollection<MBusinessVo> initializeKanriCodes;
        private ObservableCollection<AttendanceWork> initializAttendanceWorks;
        private ObservableCollection<AttendanceWork> tempAttendanceWork;
        private ObservableCollection<AttendanceWork> tempKanriCodes;
        private ObservableCollection<KanriCodes> selectedKanriCodes;
        #endregion
    }
}
