using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceRecordWriter.Domain.Model.ValueObjectes;
using Reactive.Bindings;

namespace AttendanceRecordWriter.UI.Model
{
    public class User :DependencyObject
    {

        public User(MUserVo user)
        {
            UserCode = user.UserCode;
            UserName = user.UserName;
            DivisionCode = user.BumonCode;
            PositionName = user.PositionName;
            EmaillAddress = user.EmaillAddress;
            PostNo = user.PostNo;
            AddressName = user.AddressName;
            Tel = user.Tel;
        }

        public User()
        {
        }

        public string UserCode
        {
            get { return (string)GetValue(UserCodeProperty); }
            set { SetValue(UserCodeProperty, value); }
        }
        // Using a DependencyProperty as the backing store for UserCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserCodeProperty =
            DependencyProperty.Register("UserCode", typeof(string), typeof(User), new PropertyMetadata(""));
        

        public string UserName
        {
            get { return (string)GetValue(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserNameProperty =
            DependencyProperty.Register("UserName", typeof(string), typeof(User), new PropertyMetadata(""));
        

        public string DivisionCode
        {
            get { return (string)GetValue(BumonCodeProperty); }
            set { SetValue(BumonCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BumonCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BumonCodeProperty =
            DependencyProperty.Register("BumonCode", typeof(string), typeof(User), new PropertyMetadata(""));

        public string KaCode
        {
            get { return (string)GetValue(KaCodeProperty); }
            set { SetValue(KaCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KaCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KaCodeProperty =
            DependencyProperty.Register("KaCode", typeof(string), typeof(User), new PropertyMetadata(""));




        public string PositionName
        {
            get { return (string)GetValue(YakuNameProperty); }
            set { SetValue(YakuNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for YakuName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YakuNameProperty =
            DependencyProperty.Register("YakuName", typeof(string), typeof(User), new PropertyMetadata(""));




        public string EmaillAddress
        {
            get { return (string)GetValue(EmaillAddressProperty); }
            set { SetValue(EmaillAddressProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EmaillAddress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmaillAddressProperty =
            DependencyProperty.Register("EmaillAddress", typeof(string), typeof(User), new PropertyMetadata(""));




        public string PostNo
        {
            get { return (string)GetValue(PostNoProperty); }
            set { SetValue(PostNoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PostNo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PostNoProperty =
            DependencyProperty.Register("PostNo", typeof(string), typeof(User), new PropertyMetadata(""));



        public string AddressName
        {
            get { return (string)GetValue(JyushoNameProperty); }
            set { SetValue(JyushoNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for JyushoName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JyushoNameProperty =
            DependencyProperty.Register("JyushoName", typeof(string), typeof(User), new PropertyMetadata(""));



        public string Tel
        {
            get { return (string)GetValue(TelProperty); }
            set { SetValue(TelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TelProperty =
            DependencyProperty.Register("Tel", typeof(string), typeof(User), new PropertyMetadata(""));
    }
}
