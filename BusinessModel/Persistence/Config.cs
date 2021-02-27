#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

#endregion

namespace BusinessModel {

    class Config : ApplicationSettingsBase {

        [UserScopedSetting()]
        [DefaultSettingValue("Sys")]
        public string Database {
            get { return (this["Database"].ToString()); }
            set { this["Database"] = value; }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("None")]
        public string User {
            get { return (this["User"].ToString()); }
            set { this["User"] = value; }
        }
    }
}

